using System;
using WebApp1_GameStore.DTOs;

namespace WebApp1_GameStore.Endpoints;

public static class GameEndpoints
{

    const string GetGameEndPoint = "GetGame";

    private static readonly List<GameDto> games = [
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

    public static WebApplication MapGameEndPoints(this WebApplication app)
    {
        // Get All Games:
        app.MapGet("games", () => games);


        // Get Specific Game:
        app.MapGet("games/{id}", handler: (int id) =>
        {
            GameDto? game = games.Find(game => game.ID == id);

            return game is null ? Results.NotFound() : Results.Ok(game);


        })
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

            if (Index == -1)
            {
                return Results.NotFound();
            }

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

        return app;     
       }

}
