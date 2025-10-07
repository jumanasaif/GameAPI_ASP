using System;
using Microsoft.EntityFrameworkCore;
using WebApp1_GameStore.Data;
using WebApp1_GameStore.Mapping;

namespace WebApp1_GameStore.Endpoints;

public static class KindEndpoints
{
    public static RouteGroupBuilder MapKindEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("kinds");
        group.MapGet("/", async (GameStoreContext dbContext) =>

            await dbContext.Kinds
                           .Select(kind => kind.ToDto())
                           .AsNoTracking()
                           .ToListAsync()

        );
        return group;    
   }
}
