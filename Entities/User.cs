using System;

namespace WebApp1_GameStore.Entities;

public class User
{

    public int Id { get; set; }
    public required string UserName { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public required string Role { get; set; }

}
