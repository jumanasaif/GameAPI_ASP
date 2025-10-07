using System;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using WebApp1_GameStore.Data;
using WebApp1_GameStore.DTOs;
using WebApp1_GameStore.Entities;
using WebApp1_GameStore.Mapping;

namespace WebApp1_GameStore.Endpoints;

public static class GameEndpoints
{

    const string GetGameEndPoint = "GetGame";


    public static RouteGroupBuilder MapGameEndPoints(this WebApplication app)
    {

        var group = app.MapGroup("games")
                                          .WithParameterValidation();




        // Get All Games:
        group.MapGet("/", async (GameStoreContext dbContext) =>
          await dbContext.Games
                  .Include(game => game.Kind)
                  .Select(game => game.ToDto())
                  .AsNoTracking()
                  .ToListAsync()
         );


        // Get Specific Game:
        group.MapGet("/{id}", handler: async (int id, GameStoreContext dbContext) =>
        {
            Game? game = await dbContext.Games.FindAsync(id);

            return game is null ? Results.NotFound() : Results.Ok(game.ToDetailsDto());


        })
        .WithName(GetGameEndPoint);




        // Add New Game:
        group.MapPost("/", async (CreateGameDto NewGame, GameStoreContext dbContext) =>
        {


            Game game = NewGame.ToEntity();

            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetGameEndPoint, new { id = game.Id }, game.ToDetailsDto());


        }

        );



        // Update Game:
        group.MapPut("/{id}", async (int id, UpdateGameDto UpdatedGame, GameStoreContext dbContext) =>
        {

            var existingGame = await dbContext.Games.FindAsync(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingGame)
                     .CurrentValues
                     .SetValues(UpdatedGame.ToEntity(id));

            await dbContext.SaveChangesAsync();
            return Results.NoContent();



        });


        // Delete Game:
        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            await dbContext.Games
                      .Where(game => game.Id == id)
                      .ExecuteDeleteAsync();
            return Results.NoContent();
        });



        return group;
    }

}
