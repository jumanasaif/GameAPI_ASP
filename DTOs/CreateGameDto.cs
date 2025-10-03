namespace WebApp1_GameStore.DTOs;

public record class CreateGameDto
(
    string GameName,
    string Kind,
    decimal Price,
    DateOnly ReleaseDate

);