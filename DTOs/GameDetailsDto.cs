namespace WebApp1_GameStore.DTOs;

public record class GameDetailsDto
(
    int ID,
    string GameName,
    int KindId,
    decimal Price,
    DateOnly ReleaseDate
);