using Microsoft.Net.Http.Headers;
using PPH.DataAccess.Repositories;
using System.Text.Json;

namespace PPH.Api.Endpoints.Events;

public static class GetEventsEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/events", async (HttpContext ctx, EventRepository repo) =>
        {
            ctx.Response.Headers.Append(HeaderNames.ContentType, "text/event-stream");

            await foreach (var @event in repo.GetMapEventsStream(1))
            {
                await ctx.Response.WriteAsync($"data: ");
                await JsonSerializer.SerializeAsync(ctx.Response.Body, @event);
                await ctx.Response.WriteAsync($"\n\n");
                await ctx.Response.Body.FlushAsync();
            }
        })
        .WithName("GetEvents");
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