using System;
using Microsoft.EntityFrameworkCore;

namespace WebApp1_GameStore.Data;

public static class DataExtintions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {

        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync();

    }
}
