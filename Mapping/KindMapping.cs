using System;
using WebApp1_GameStore.DTOs;
using WebApp1_GameStore.Entities;

namespace WebApp1_GameStore.Mapping;

public static class KindMapping
{
    public static KindDto ToDto(this Kind kind)
    {
        return new KindDto(kind.Id, kind.Name);
    }

}
