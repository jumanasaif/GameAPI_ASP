using WebApp1_GameStore.Data;
using WebApp1_GameStore.DTOs;
using WebApp1_GameStore.Endpoints;


var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);
var app = builder.Build();


app.MapGameEndPoints();
app.MigrateDb();
app.Run();
