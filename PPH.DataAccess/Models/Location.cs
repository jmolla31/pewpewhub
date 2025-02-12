using System.ComponentModel.DataAnnotations;

namespace PPH.DataAccess.Models;

public class Location : LocatableEntityBase
{
    public Location(int id, int mapId, string name, string point, 
                    DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy) 
        : base(id, mapId, name, point, createdAt, createdBy, updatedAt, updatedBy)
    {
    }

    public string Type { get; set; } = "other";

    [StringLength(500)]
    public string? Description { get; set; }
}
