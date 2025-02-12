using System.ComponentModel.DataAnnotations;

namespace PPH.PublicContracts.Entities;

public class MetadataEntity
{
    [Required]
    public string Id { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string Description { get; set; }
}
