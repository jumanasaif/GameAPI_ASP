using System;
using Microsoft.EntityFrameworkCore;

namespace WebApp1_GameStore.Data;

public static class DataExtintions
{
    public static void MigrateDb(this WebApplication app)
    {

        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();

    }
}
