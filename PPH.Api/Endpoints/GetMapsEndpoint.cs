using PPH.DataAccess.Repositories;

namespace PPH.Api.Endpoints;

public static class GetMapsEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/maps", async (IMapsRepository repo) =>
        {
            var maps = await repo.ListAsync().ToListAsync();
            return Results.Json(maps);

        }).WithName("GetMaps");
    }
}
