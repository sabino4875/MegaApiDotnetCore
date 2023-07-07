namespace Api.Megaman.EndPoints
{
    using Api.Megaman.Application.DTO;
    using Api.Megaman.Application.Services;
    using FluentValidation;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public static class RobotEndPoint
    {
        public static void MapRobotEndPoints(this WebApplication app)
        {
            var defaultUrl = "api/v1/robots";
            
            app.MapGet(defaultUrl, ([FromServices]IRobotServices service) => {
                try
                {
                    var robotItems = service.SearchAll();
                    return Results.Ok(robotItems);
                }
                catch(Exception ex)
                {
                    return Results.Problem(statusCode: 500, title: "robot list", detail: ex.Message);
                }
            });

            app.MapGet(String.Concat(defaultUrl,"/{id}"), ([FromRoute]String id, [FromServices] IRobotServices service) => {
                try
                {
                    Int32 _id;
                    if(Int32.TryParse(id, out _id))
                    {
                        var robot = service.SearchById(_id);
                        if (robot == null) return Results.NotFound(new { message = "Nenhum robo encontrado." });
                        return Results.Ok(robot);
                    }
                    return Results.BadRequest(new { message = "Id informado inválido." });
                }
                catch (Exception ex)
                {
                    return Results.Problem(statusCode: 500, title: "robot search", detail: ex.Message);
                }
            });

            app.MapPost(defaultUrl, async ([FromBody]RobotCreateDTO entity,[FromServices] IValidator<RobotCreateDTO> validator, [FromServices]IRobotServices service) => {
                try
                {
                    if (entity!=null)
                    {
                        var result = await validator.ValidateAsync(entity);
                        if(!result.IsValid)
                        {
                            return Results.ValidationProblem(result.ToDictionary());
                        }

                        var id = 0;
                        service.AddRobot(entity);
                        return Results.Created(String.Concat(defaultUrl, $"/{id}"), entity);
                    }
                    return Results.BadRequest(new { message = "Por favor, preencha todos os campos." });
                }
                catch (Exception ex)
                {
                    return Results.Problem(statusCode: 500, title: "robot create", detail: ex.Message);
                }
            });
        }
    }
}
