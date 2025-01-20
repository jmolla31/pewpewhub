using System.ComponentModel.DataAnnotations;

namespace PPH.PublicContracts;

public class Map : TraceableEntityBase
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = "default";
    
    [StringLength(500)]
    public string? Description { get; set; }
}
