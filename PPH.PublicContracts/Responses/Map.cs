using System;
using System.ComponentModel.DataAnnotations;

namespace PPH.PublicContracts.Entities;

public class Map : TraceableEntityBase
{
    public string Id { get; }

    [Required]
    [StringLength(100)]
    public string Name { get; }

    [StringLength(500)]
    public string? Description { get; }

    public Map(string id, string name, string? description, DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy)
        :base(createdAt, createdBy, updatedAt, updatedBy)
    {
        Id = id;
        Name = name;
        Description = description;
    }


}
