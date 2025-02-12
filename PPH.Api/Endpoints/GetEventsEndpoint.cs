using Microsoft.Net.Http.Headers;
using PPH.DataAccess.Repositories.Implementations;
using PPH.PublicContracts.GeoJson;
using System.Text.Json;

namespace PPH.Api.Endpoints;

public static class GetEventsEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/maps/{mapId}/events/geoJson-stream", async (string mapid, HttpContext ctx, EventRepository repo) =>
        {
            ctx.Response.Headers.Append(HeaderNames.ContentType, "text/event-stream");

            await foreach (var @event in repo.GetMapEventsStream(1))
            {
                await ctx.Response.WriteAsync($"data: ");

                var feature = new GeoJsonFeature(@event.PointObject);

                feature.Properties["id"] = @event.Id;
                feature.Properties["mapId"] = @event.MapId;
                feature.Properties["name"] = @event.Name;
                feature.Properties["eventTime"] = @event.EventTime;

                await JsonSerializer.SerializeAsync(ctx.Response.Body, feature);

                await ctx.Response.WriteAsync($"\n\n");
                await ctx.Response.Body.FlushAsync();
            }
        })
        .WithName("get-map-events");

        builder.MapGet("/maps/{mapId}/events/latest", async (string mapId, HttpContext ctx, EventRepository repo) =>
        {
            ctx.Response.Headers.Append(HeaderNames.ContentType, "text/event-stream");

            var id = int.Parse(mapId);

            var response = await repo.GetMapLatestEvents(id);

            return Results.NotFound();

            //return Results.Json(response.Select(x => new PPH.PublicContracts.Entities.Event()))
        })
        .WithName("get-map-latest-events");
    }
}


//public class GeoJsonFeatureCollection
//{
//    public string Type { get; set; } = "FeatureCollection";
//    public List<GeoJsonFeature> Features { get; set; } = new();
//}

//public class GeoJsonFeature
//{
//    public string Type { get; set; } = "Feature";
//    public int Id { get; set; }
//    public GeoJsonGeometry Geometry { get; set; } = default!;
//    public Dictionary<string, object> Properties { get; set; } = new();
//}

//public class GeoJsonGeometry
//{
//    public string Type { get; set; } = "Point";
//    public List<double> Coordinates { get; set; } = new();
//}

//var geoJson = new GeoJsonFeatureCollection
//{
//    Features = new List<GeoJsonFeature>
//                {
//                    new GeoJsonFeature
//                    {
//                        Geometry = new GeoJsonGeometry
//                        {
//                            Coordinates = [30.5234, 50.4501] // Kyiv
//                        },
//                        Properties = new Dictionary<string, object>
//                        {
//                            { "name", "Kyiv" },
//                            { "description", "Capital of Ukraine" },
//                            { "marker-color", "#0000FF" },
//                            { "marker-size", "large" },
//                            { "marker-symbol", "star" }
//                        }
//                    },
//                    new GeoJsonFeature
//                    {
//                        Geometry = new GeoJsonGeometry
//                        {
//                            Coordinates = [36.2304, 49.9935] // Kharkiv
//                        },
//                        Properties = new Dictionary<string, object>
//                        {
//                            { "name", "Kharkiv" },
//                            { "description", "Second-largest city in Ukraine" },
//                            { "marker-color", "#FF0000" },
//                            { "marker-size", "medium" },
//                            { "marker-symbol", "circle" }
//                        }
//                    }
//                }