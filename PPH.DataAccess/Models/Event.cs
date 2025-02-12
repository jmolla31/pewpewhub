
using System.ComponentModel.DataAnnotations;

namespace PPH.DataAccess.Models;

public class Event : LocatableEntityBase
{
    public DateTime EventTime { get; }

    public Event(int id, int mapId, string name, string point, string? actor,
                 DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy)
        : base(id, mapId, name, point, actor, createdAt, createdBy, updatedAt, updatedBy)
    {
    }
}


public class Unit : LocatableEntityBase
{
    [Required]
    public string Type { get; }

    [Required]
    public string Size { get; }

    [StringLength(500)]
    public string? Description { get; set; }

    public Unit(int id, int mapId, string name, string point, string? actor,
                string type, string size, string description,
                DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy)
        : base(id, mapId, name, point, actor, createdAt, createdBy, updatedAt, updatedBy)
    {
        Type = type;
        Size = size;
        Description = description;
    }
}