
namespace PPH.PublicContracts.GeoJson;

public class GeoJsonGeometry
{
    public string Type { get; }

    public double[] Coordinates { get; }

    [System.Text.Json.Serialization.JsonConstructor]
    [Newtonsoft.Json.JsonConstructor]
    public GeoJsonGeometry(string type, double[] coordinates)
    {
        Type = type;
        Coordinates = coordinates;
    }

    public GeoJsonGeometry()
    {
    }
}

