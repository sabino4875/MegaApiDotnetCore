using Api.Megaman.EndPoints;
using Api.Megaman.IoC;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.AddInfraStructure();

var app = builder.Build();
app.MapInfraStructure();
app.MapRobotEndPoints();

app.Run("http://localhost:3000");