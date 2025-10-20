using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp1_GameStore.DTOs;

public record class RegisterDto(
    [Required][StringLength(50)] string UserName,
    [Required][StringLength(30, MinimumLength = 6)] string Password
);