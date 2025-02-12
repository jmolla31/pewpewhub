using PPH.DataAccess.Repositories;
using PPH.PublicContracts.Payloads;

namespace PPH.Api.Endpoints;

public static class GetMapsEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/maps", async (IMapsRepository repo) =>
        {
            var maps = await repo.ListAsync().ToListAsync();

            return Results.Json(maps.Select(x => new PublicContracts.Entities.Map(
                x.Id.ToString(),
                x.Name,
                x.Description,
                x.CreatedAt,
                x.CreatedBy,
                x.UpdatedAt,
                x.UpdatedBy)));

        }).WithName("get-maps");
    }
}


public static class AddMapEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/maps", async (CreateMap body, IMapsRepository repo) =>
        {
            var dbModel = new DataAccess.Models.Map(
                id: 0,
                name: body.Name,
                description: body.Description,
                createdAt: DateTime.UtcNow,
                createdBy: "system",
                updatedAt: null,
                updatedBy: null);

            var created = await repo.Create(dbModel);

            if (created is null) return Results.BadRequest();

            var response = new PublicContracts.Entities.Map(
                created.Id.ToString(),
                created.Name,
                created.Description,
                created.CreatedAt,
                created.CreatedBy,
                created.UpdatedAt,
                created.UpdatedBy);

            return Results.Json(response);

        }).WithName("post-map");
    }
}
