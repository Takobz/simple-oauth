using SimpleAuthServer.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthServer.ServiceCollectionExtensions;
using SimpleAuthServer.Services.Orchestrator;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSimpleAuthServices();
builder.Services.AddRepo();
var app = builder.Build();

app.MapPost("/register", (
    [FromBody] ClientRegistrationRequest request,
    IRegistrationOrchestrator registrationOrchestrator) => 
    {
        //TODO: move handlers to another directory to make this class small and clean.
    });

app.MapGet("/authorize", (
    [FromQuery(Name = "response_type")]string responsetype,
    [FromQuery(Name = "client_id")]string clientId,
    [FromQuery(Name = "redirect_uri")]string redirectUri,
    string state,
    string scope) => 
    {
        
    });

app.Run();
