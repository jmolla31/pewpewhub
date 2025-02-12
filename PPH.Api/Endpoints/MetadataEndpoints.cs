using PPH.DataAccess.Repositories;

namespace PPH.Api.Endpoints;

public static class MetadataEndpoints
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapGet("metadata/unit-sizes", async (IMetadataRepository repo) =>
        {
            var result = await repo.GetUnitSizesAsync();
            return Results.Ok(result);
        })
        .WithName("get-unit-sizes");

        builder.MapGet("metadata/entity-types", async (IMetadataRepository repo) =>
        {
            var result = await repo.GetUnitTypesAsync();
            return Results.Ok(result);
        })
        .WithName("get-entity-types");

        builder.MapGet("metadata/actors", async (IMetadataRepository repo) =>
        {
            var result = await repo.GetActorsAsync();
            return Results.Ok(result);
        })
        .WithName("get-actors");
    }
}
