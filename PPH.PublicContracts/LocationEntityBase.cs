using PPH.PublicContracts.GeoJson;
using System.ComponentModel.DataAnnotations;

namespace PPH.PublicContracts
{
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

        public string Actor { get; set; } = "neutral";

        public GeoJsonGeometry Point { get; set; } = new();

        public double Latitude => Point.coordinates[1];
        public double Longitude => Point.coordinates[0];
    }
}
