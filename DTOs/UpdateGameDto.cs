namespace WebApp1_GameStore.DTOs;

public record class UpdateGameDto
(
    string GameName,
    string Kind,
    decimal Price,
    DateOnly ReleaseDate

);