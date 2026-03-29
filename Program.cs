using System.Net;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Verify endpoint to return builder and runner information along with timestamp and machine name
app.MapGet("/verify", () =>
{
    var runner = Environment.GetEnvironmentVariable("RUN_BY") ?? "NOT_FOUND";
    var builderName = "Assignment 3 builder";

    // Create a response object with builder, runner, timestamp, and machine name
    var response = new
    {
        builder = builderName,
        runner = runner,
        timestamp = DateTime.UtcNow.ToString("o"),
        machineName = Dns.GetHostName()
    };

    return Results.Json(response);
});

// Run the application on port 8080
app.Run("http://0.0.0.0:8080");