using System;
using System.ComponentModel.DataAnnotations;

namespace PPH.PublicContracts.Entities;


public class Formation : LocationEntityBase
{
    public Formation(DateTime createdAt, string? createdBy, DateTime? updatedAt, string? updatedBy) 
        : base(createdAt, createdBy, updatedAt, updatedBy)
    {
    }

    [StringLength(500)]
    public string? Description { get; set; }
    public string Symbol { get; set; } = "default";
    public string? Type { get; set; } = "other";
    public string? Size { get; set; } = "other";
}
