using System;
using Microsoft.EntityFrameworkCore;
using WebApp1_GameStore.Entities;


namespace WebApp1_GameStore.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options)
    : DbContext(options)
{

    public DbSet<Game> Games => Set<Game>();
    public DbSet<Kind> Kinds => Set<Kind>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kind>().HasData(
         new { Id = 1, Name = "Fighting" },
         new { Id = 2, Name = "RolePlaying" },
         new { Id = 3, Name = "Sports" },
         new { Id = 4, Name = "Kids And Family" }
       );
    }


}
