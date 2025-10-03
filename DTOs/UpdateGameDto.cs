using System.ComponentModel.DataAnnotations;

namespace WebApp1_GameStore.DTOs;

public record class UpdateGameDto
(
    [Required][StringLength(50)] string GameName,
    [Required][StringLength(50)] string Kind,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate

);