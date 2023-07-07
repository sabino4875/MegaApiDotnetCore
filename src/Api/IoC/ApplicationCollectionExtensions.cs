using Api.Megaman.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;

namespace Api.Megaman.IoC
{
    public static class ApplicationCollectionExtensions
    {
        private static IApplicationBuilder MapMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<MiddlewareLog>();
            app.UseMiddleware<ETagMiddleware>();
            return app;
        }

        private static IApplicationBuilder MapCors(this IApplicationBuilder app)
        {
            app.UseCors(p =>
            {
                p.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowCredentials()
                .WithMethods("GET", "POST", "PATCH", "DELETE");
            });
            return app;
        }

        private static IApplicationBuilder MapResponseHeaders(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("accept-ranges", "bytes");
                context.Response.Headers.Add("access-control-allow-origin", "*");
                context.Response.Headers.Add("connection", "keep-alive");
                context.Response.Headers.Add("cross-origin-embedder-policy", "credentialless");
                context.Response.Headers.Add("cross-origin-opener-policy", "same-origin");
                context.Response.Headers.Add("cross-origin-resource-policy", "cross-origin");
                context.Response.Headers.Add("date", DateTimeOffset.Now.ToUniversalTime().ToString("r"));//Thu, 08 Jun 2023 22:24:55 GMT
                context.Response.Headers.Add("keep-alive", "timeout=5");
                context.Response.Headers.Add("access-control-allow-headers", "Content-Type, X-CSRF-Token, X-Requested-With, Accept, Accept-Version, Accept-Encoding, Content-Length, Content-MD5, Date, X-Api-Version, X-File-Name");
                context.Response.Headers.Add("access-control-allow-credentials", "true");
                await next();
            });
            return app;
        }

        private static IApplicationBuilder MapExtensions(this IApplicationBuilder app)
        {
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            return app;
        }

        private static IApplicationBuilder MapExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config => config.Run(async context => await Results.Problem().ExecuteAsync(context)));
            return app;    
        }

        public static IApplicationBuilder MapInfraStructure(this IApplicationBuilder app)
        {
            //exception configuration
            app.MapExceptionHandler();
            //middlewares configuration
            app.MapMiddlewares();
            //cors configuration
            app.MapCors();
            //response headers configuration
            app.MapResponseHeaders();
            //extensions configuration
            app.MapExtensions();
            return app;
        }
    }
}
