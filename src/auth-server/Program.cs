using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/register", (
    [FromQuery(Name = "flow_type")] [Required]string flowType,
    [FromQuery(Name = "redirect_uri")] [Required] string redirectUri,
    [FromQuery(Name = "client_name")] [Required] string clientName) => 
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
