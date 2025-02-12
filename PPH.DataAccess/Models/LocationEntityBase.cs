using Newtonsoft.Json;
using PPH.PublicContracts.GeoJson;
using System.Text.Json;

namespace PPH.DataAccess.Models;

/// <summary>
///     Base class for objects requiring a unique identifier and location coordinates (using a GeoJson point).
/// </summary>
public abstract class LocationEntityBase : TraceableEntityBase
{
    protected LocationEntityBase(int id, int mapId, string name, string point, DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy) : base(createdAt, createdBy, updatedAt, updatedBy)
    {
        Id = id;
        MapId = mapId;
        Name = name;
        Point = point;
    }

    public int Id { get; }
    public int MapId { get; }
    public string Name { get; }

    public string Point { get; }

    public GeoJsonGeometry PointObject => Point != null 
        ? JsonConvert.DeserializeObject<GeoJsonGeometry>(Point) ?? new() 
        : new();

    public double Latitude => PointObject.Coordinates[1];
    public double Longitude => PointObject.Coordinates[0];
}
