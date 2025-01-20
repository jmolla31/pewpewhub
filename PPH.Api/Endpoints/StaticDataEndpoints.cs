using PPH.PublicContracts;

namespace PPH.Api.Endpoints;

public static class StaticDataEndpoints
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapGet("data/unit-sizes", () =>
        {
            return Results.Ok<UnitSize[]>(
            [
                new UnitSize
                {
                    Id = "other",
                    Description = "Unknown size/strenght. Used also for entries where size is not relevant."
                },
                new UnitSize
                {
                    Id = "brigade",
                    Description = "NATO-standard size. Aprox 5000 troops."
                },
                new UnitSize
                {
                    Id = "company",
                    Description = "NATO-standard size. Aprox 200 troops."
                },

            ]);
        })
        .WithName("GetUnitSizes");


        builder.MapGet("data/entity-types", () =>
        {
            return Results.Ok<UnitType[]>(
            [
                new UnitType
                {
                    Id = "other",
                    Description = "Unknown type. Used also for entries where type is not relevant."
                },
                new UnitType
                {
                    Id = "civilian",
                    Description = "Non-military related unit."
                },
                new UnitType
                {
                    Id = "military",
                    Description = "Generic military unit"
                }
            ]);
        })
        .WithName("GetEntityTypes");

        builder.MapGet("data/actors", () =>
        {
            return Results.Ok<Actor[]>(
            [
                new Actor
                {
                    Id = "neutral",
                    Description = "Default actor for any new entities unless a specific one is specified. " +
                                  "Used also to track entities without a specific side or affiliation in a conflict."
                },
                new Actor
                {
                    Id = "blufor",
                    Description = "Generic actor for friendly forces."
                },
                new Actor
                {
                    Id = "redfor",
                    Description = "Generic actor for enemy/oposition forces."
                },

            ]);
        })
        .WithName("GetFormationSizes");
    }

}
