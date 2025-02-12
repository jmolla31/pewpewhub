using System;
using System.ComponentModel.DataAnnotations;

namespace PPH.PublicContracts.Entities;

public class Unit : LocatableEntityBase
{
    [Required]
    public string TypeId { get; set; } = "other";

    [Required]
    public string SizeId { get; set; } = "other";

    [Required]
    public string ActorId { get; set; } = "neutral";

    [StringLength(500)]
    public string? Description { get; set; }

    public Unit(int id, int mapId, string name, string typeId, string sizeId, string actorId, string? description,
        DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy)
        : base(createdAt, createdBy, updatedAt, updatedBy)
    {
        Id = id;
        MapId = mapId;
        Name = name;
        TypeId = typeId;
        SizeId = sizeId;
        ActorId = actorId;
        Description = description;
    }
}
