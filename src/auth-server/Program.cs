using SimpleAuthServer.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthServer.ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSimpleAuthServices();
builder.Services.AddRepo();
var app = builder.Build();

app.MapPost("/register", ([FromBody] ClientRegistrationRequest request) => 
    {
        
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
