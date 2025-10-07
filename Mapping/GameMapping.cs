using System;
using WebApp1_GameStore.DTOs;
using WebApp1_GameStore.Entities;

namespace WebApp1_GameStore.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto game)
    {
        return new Game()
        {
            GameName = game.GameName,
            KindId = game.KindId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate

        };

    }


    public static Game ToEntity(this UpdateGameDto game, int id)
    {
        return new Game()
        {
            Id = id,
            GameName = game.GameName,
            KindId = game.KindId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate

        };

    }


    public static GameDto ToDto(this Game game)
    {
        return new(
               game.Id,
               game.GameName,
               game.Kind!.Name,
               game.Price,
               game.ReleaseDate
            );
    }

    public static GameDetailsDto ToDetailsDto(this Game game)
    {
        return new(
               game.Id,
               game.GameName,
               game.KindId,
               game.Price,
               game.ReleaseDate
            );
    }
}
