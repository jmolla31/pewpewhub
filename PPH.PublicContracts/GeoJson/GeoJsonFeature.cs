using System.Collections.Generic;

namespace PPH.PublicContracts.GeoJson;

public class GeoJsonFeature
{
    public string Type { get; set; } = "Feature";
    public int Id { get; set; }
    public GeoJsonGeometry Geometry { get; set; } = default!;
    public Dictionary<string, object> Properties { get; set; } = new();
}
