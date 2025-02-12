using PPH.PublicContracts.GeoJson;
using System;
using System.ComponentModel.DataAnnotations;

namespace PPH.PublicContracts.Entities
{
    /// <summary>
    ///     Base class for objects requiring a unique identifier and location coordinates (using a GeoJson point).
    /// </summary>
    public abstract class LocationEntityBase : TraceableEntityBase
    {
        protected LocationEntityBase(DateTime createdAt, string? createdBy, DateTime? updatedAt, string? updatedBy) : base(createdAt, createdBy, updatedAt, updatedBy)
        {
        }

        public int Id { get; set; }
        public int MapId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = "default";

        public string Actor { get; set; } = "neutral";

        public GeoJsonGeometry Point { get; set; } = new();

        public double Latitude => Point.Coordinates[1];
        public double Longitude => Point.Coordinates[0];
    }
}
