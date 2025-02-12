using System.ComponentModel.DataAnnotations;

namespace PPH.DataAccess.Models;

public class Formation : LocationEntityBase
{
    public Formation(int id, int mapId, string name, string point,
                    DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy)
        : base(id, mapId, name, point, createdAt, createdBy, updatedAt, updatedBy)
    {
    }

    [StringLength(500)]
    public string? Description { get; set; }
    public string Symbol { get; set; } = "default";
    public string? Type { get; set; } = "other";
    public string? Size { get; set; } = "other";
}
