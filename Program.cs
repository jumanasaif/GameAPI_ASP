using WebApp1_GameStore.DTOs;


var builder = WebApplication.CreateBuilder(args);


var app = builder.Build(); 

app.MapGet("/", () => "Hello World!");

app.Run();
