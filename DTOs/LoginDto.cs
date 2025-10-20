using System.ComponentModel.DataAnnotations;

namespace WebApp1_GameStore.DTOs;

public record class LoginDto(
    [Required] string UserName,
    [Required] string Password
);
