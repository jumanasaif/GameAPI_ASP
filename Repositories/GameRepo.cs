using System;
using Microsoft.EntityFrameworkCore;
using WebApp1_GameStore.Data;
using WebApp1_GameStore.Entities;
namespace WebApp1_GameStore.Repositories;

public class GameRepo(GameStoreContext context) : IGameRepository
{

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await context.Games
        .Include(g => g.Kind)
        .ToListAsync();
    }

    public async Task<Game> GetGameAsync(int id)
    {
        var game = await context.Games
       .Include(g => g.Kind)
       .FirstOrDefaultAsync(g => g.Id == id);

        if (game == null)
            throw new InvalidOperationException($"Game with id {id} was not found.");

        return game;
    }

    public async Task CreateGameAsync(Game game)
    {
        await context.Games.AddAsync(game);
        await context.SaveChangesAsync();
    }

    public async Task UpdateGameAsync(Game game)
    {
        context.Games.Update(game);
        await context.SaveChangesAsync();
    }

    public async Task DeleteGameAsync(int id)
    {
        var game = await context.Games.FindAsync(id);
        if (game != null)
        {
            context.Games.Remove(game);
            await context.SaveChangesAsync();
        }
    }
}