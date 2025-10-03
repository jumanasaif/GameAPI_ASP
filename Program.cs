using WebApp1_GameStore.DTOs;


var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

const string GetGameEndPoint = "GetGame";

List<GameDto> games = [
    new(
        1,
        "Street Fighter II",
        "Fighting",
        19.99M,
        new DateOnly(1999,7,15)
    ),
     new(
        2,
        "Final Fantasy XIV",
        "RolePlaying",
        59.99M,
        new DateOnly(2010,9,30)
    ),
       new(
        3,
        "FIFA 23",
        "Sports",
        69.99M,
        new DateOnly(2022,9,27)
    ),
];

// Get All Games:
app.MapGet("games", () => games);


// Get Specific Game:
app.MapGet("games/{id}", handler: (int id) => games.Find(game => game.ID == id))
    .WithName(GetGameEndPoint);


// Add New Game:
app.MapPost("games", (CreateGameDto NewGame) =>
  {
      GameDto game = new(
      games.Count + 1,
      NewGame.GameName,
      NewGame.Kind,
      NewGame.Price,
      NewGame.ReleaseDate

      );
      games.Add(game);
      return Results.CreatedAtRoute(GetGameEndPoint, new { id = game.ID }, game);


  }

);


// Update Game:
app.MapPut("games/{id}", (int id, UpdateGameDto UpdatedGame) =>
{
    int Index = games.FindIndex(game => game.ID == id);
    games[Index] = new GameDto(
         id,
         UpdatedGame.GameName,
         UpdatedGame.Kind,
         UpdatedGame.Price,
         UpdatedGame.ReleaseDate
    );

    return Results.NoContent();



});


// Delete Game:
app.MapDelete("games/{id}", (int id) =>
{
    games.RemoveAll(game => game.ID == id);
    return Results.NoContent();
});


// Delete All Games
app.MapDelete("games", () =>
{
    games.Clear();
    return Results.NoContent();
});


app.Run();
