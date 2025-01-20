using PPH.PublicContracts.GeoJson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace PPH.DataAccess.Models;

public class FormationSize
{
    public string Id { get; }
    public string Description { get; }

    public FormationSize(string id, string description)
    {
        Id = id;
        Description = description;
    }
}
public class Map : TraceableEntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}


public class Location : LocationEntityBase
{
    public string Type { get; set; } = "other";

    [StringLength(500)]
    public string? Description { get; set; }
}

public class Event : LocationEntityBase
{
}

public class Formation : LocationEntityBase
{
    [StringLength(500)]
    public string? Description { get; set; }
    public string Symbol { get; set; } = "default";
    public string? Type { get; set; } = "other";
    public string? Size { get; set; } = "other";
}

/// <summary>
///     Base class for objects requiring a unique identifier and location coordinates (using a GeoJson point).
/// </summary>
public abstract class LocationEntityBase : TraceableEntityBase
{
    public int Id { get; set; }
    public int MapId { get; set; }

    [Required]
    [StringLength(150)]
    public string Name { get; set; } = "default";

    public string Point { get; set; } = string.Empty;

    public GeoJsonGeometry PointObject => Point != null ? JsonSerializer.Deserialize<GeoJsonGeometry>(Point) ?? new() : new();

    public double Latitude => PointObject.coordinates[1];
    public double Longitude => PointObject.coordinates[0];
}

/// <summary>
///     Base class for objects requiring create/update tracing (who and when).
/// </summary>
public abstract class TraceableEntityBase
{
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("updated_by")]
    public string? UpdatedBy { get; set; }
}
