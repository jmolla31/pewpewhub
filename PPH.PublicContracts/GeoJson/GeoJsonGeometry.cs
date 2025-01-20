namespace PPH.PublicContracts.GeoJson;

public class GeoJsonGeometry
{
    public string type { get; set; } = "Point";

    public double[] coordinates { get; set; } = [];
}

