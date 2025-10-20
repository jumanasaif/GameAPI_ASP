using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp1_GameStore.Entities;


namespace WebApp1_GameStore.Repositories;

public interface IGameRepository
{

    Task<IEnumerable<Game>> GetAllAsync();
    Task<Game> GetGameAsync(int id);
    Task CreateGameAsync(Game game);
    Task UpdateGameAsync(Game game);
    Task DeleteGameAsync(int id);



}

