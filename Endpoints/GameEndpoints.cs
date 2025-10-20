using Microsoft.AspNetCore.Authorization;
using WebApp1_GameStore.DTOs;
using WebApp1_GameStore.Entities;
using WebApp1_GameStore.Mapping;
using WebApp1_GameStore.Repositories;

namespace WebApp1_GameStore.Endpoints;

public static class GameEndpoints
{
    const string GetGameEndPoint = "GetGame";

    public static RouteGroupBuilder MapGameEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();


        group.MapGet("/", async (IGameRepository repository) =>
        {
            var games = await repository.GetAllAsync();
            var result = games.Select(g => g.ToDto());
            return Results.Ok(result);
        });


        group.MapGet("/{id}", async (int id, IGameRepository repository) =>
        {
            var game = await repository.GetGameAsync(id);
            return game is null ? Results.NotFound() : Results.Ok(game.ToDetailsDto());
        }).WithName(GetGameEndPoint);



        group.MapPost("/", [Authorize(Roles = "Admin")] async (CreateGameDto newGame, IGameRepository repository) =>
        {
            var game = newGame.ToEntity();
            await repository.CreateGameAsync(game);
            return Results.CreatedAtRoute(GetGameEndPoint, new { id = game.Id }, game.ToDetailsDto());
        });



        group.MapPut("/{id}", [Authorize(Roles = "Admin")] async (int id, UpdateGameDto dto, IGameRepository repository) =>
        {
            var existing = await repository.GetGameAsync(id);
            if (existing == null) return Results.NotFound();

            existing.GameName = dto.GameName;
            existing.KindId = dto.KindId;
            existing.Price = dto.Price;
            existing.ReleaseDate = dto.ReleaseDate;

            await repository.UpdateGameAsync(existing);
            return Results.NoContent();
        });


        group.MapDelete("/{id}", [Authorize(Roles = "Admin")] async (int id, IGameRepository repository) =>
        {
            await repository.DeleteGameAsync(id);
            return Results.NoContent();
        });

        return group;
    }
}
