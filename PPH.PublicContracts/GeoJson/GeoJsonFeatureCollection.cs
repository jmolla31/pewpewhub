using System.Collections.Generic;

namespace PPH.PublicContracts.GeoJson;

public class GeoJsonFeatureCollection
{
    public string Type { get; set; } = "FeatureCollection";
    public List<GeoJsonFeature> Features { get; set; } = new();
}
