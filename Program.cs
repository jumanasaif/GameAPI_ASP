using WebApp1_GameStore.DTOs;
using WebApp1_GameStore.Endpoints;


var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();


app.MapGameEndPoints();

app.Run();
