using System.ComponentModel.DataAnnotations;

namespace PPH.PublicContracts
{
    public class Location : LocationEntityBase
    {
        public string Type { get; set; } = "other";

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
