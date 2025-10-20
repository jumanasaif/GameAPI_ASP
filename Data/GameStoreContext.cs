using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp1_GameStore.Entities;


namespace WebApp1_GameStore.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options)
    : DbContext(options)
{

    public DbSet<Game> Games => Set<Game>();
    public DbSet<Kind> Kinds => Set<Kind>();

    public DbSet<User> Users => Set<User>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kind>().HasData(
            new { Id = 1, Name = "Fighting" },
            new { Id = 2, Name = "RolePlaying" },
            new { Id = 3, Name = "Sports" },
            new { Id = 4, Name = "Kids And Family" }
        );

        modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                UserName = "Admin",
                Role = "Admin",
                PasswordHash = "AQAAAAIAAYagAAAAEBjDpf3/6DHKCEd2+/teABhWA3JHze2Bmk4edGDBGaTyW0W7EmZz7CovpQlX1+Q31g=="
            }
        );
    }



}
