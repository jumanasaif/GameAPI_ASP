using System;

namespace WebApp1_GameStore.Entities;

public class Game
{
    public int Id { get; set; }
    public required string GameName { get; set; }

    public int KindId { get; set; }

    public Kind? Kind { get; set; }

    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }

}
