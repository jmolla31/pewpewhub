using System.ComponentModel.DataAnnotations;

namespace PPH.PublicContracts;



public class Formation : LocationEntityBase
{
    [StringLength(500)]
    public string? Description { get; set; }
    public string Symbol { get; set; } = "default";
    public string? Type { get; set; } = "other";
    public string? Size { get; set; } = "other";
}
