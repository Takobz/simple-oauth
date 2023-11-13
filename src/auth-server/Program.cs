using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/authorize", (
    [FromQuery(Name = "response_type")]string responsetype,
    [FromQuery(Name = "client_id")]string clientId,
    [FromQuery(Name = "redirect_uri")]string redirectUri,
    string state,
    string scope) => 
    {
        
    });

app.Run();
