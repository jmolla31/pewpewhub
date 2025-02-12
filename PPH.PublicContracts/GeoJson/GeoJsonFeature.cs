using System.Collections.Generic;

namespace PPH.PublicContracts.GeoJson;

public class GeoJsonFeature
{
    public string Type = "Feature";
    public GeoJsonGeometry Geometry { get; }
    public Dictionary<string, object> Properties { get; }

    public GeoJsonFeature(GeoJsonGeometry geometry)
    {
        Geometry = geometry;
        Properties = [];
    }
}
