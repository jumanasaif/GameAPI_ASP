namespace WebApp1_GameStore.DTOs;

public record class GameDto
(
    int ID,
    string GameName,
    string Kind,
    decimal Price,
    DateOnly ReleaseDate
);