using System;
using System.ComponentModel.DataAnnotations;

namespace PPH.PublicContracts.Entities;

public class Location : LocatableEntityBase
{
    public Location(DateTime createdAt, string? createdBy, DateTime? updatedAt, string? updatedBy) 
        : base(createdAt, createdBy, updatedAt, updatedBy)
    {
    }

    public string Type { get; set; } = "other";

    [StringLength(500)]
    public string? Description { get; set; }
}
