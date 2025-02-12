using System.ComponentModel.DataAnnotations;

namespace PPH.PublicContracts.Entities;

public class UnitSize
{
    [Required]
    public string Id { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string Description { get; set; }
}

public class UnitType : UnitSize
{
}


public class Actor
{
    [Required]
    public string Id { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string Description { get; set; }

    public string? VisualAssetUrl { get; set; }
}