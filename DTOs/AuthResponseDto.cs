namespace WebApp1_GameStore.DTOs;

public record class AuthResponseDto(
    string Token,
    string UserName,
    string Role
);
