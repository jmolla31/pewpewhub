using PPH.PublicContracts.GeoJson;
using System;
using System.ComponentModel.DataAnnotations;

namespace PPH.PublicContracts.Entities
{
    /// <summary>
    ///     Base class for objects requiring a unique identifier and location coordinates (using a GeoJson point).
    /// </summary>
    public abstract class LocatableEntityBase : TraceableEntityBase
    {
        protected LocatableEntityBase(DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy) : base(createdAt, createdBy, updatedAt, updatedBy)
        {
        }

        public int Id { get; set; }

        public int MapId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = "default";

        /// <summary>
        ///     Optional. Identifies the actor that this event is related to. If <see cref="UnitId"/> is not null, it must match the actor from the attached unit.
        /// </summary>
        public string? Actor { get; set; }

        public GeoJsonGeometry Point { get; set; } = new();

        public double Latitude => Point.Coordinates[1];
        public double Longitude => Point.Coordinates[0];
    }
}
