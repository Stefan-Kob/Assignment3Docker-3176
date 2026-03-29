using System.Net;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/verify", () =>
{
    var runner = Environment.GetEnvironmentVariable("RUN_BY") ?? "NOT_FOUND";
    var builderName = "Assignment 3 builder";

    var response = new
    {
        builder = builderName,
        runner = runner,
        timestamp = DateTime.UtcNow.ToString("o"),
        machineName = Dns.GetHostName()
    };

    return Results.Json(response);
});

app.Run("http://0.0.0.0:8080");