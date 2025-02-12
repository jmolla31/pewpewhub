
namespace PPH.DataAccess.Models;

public class Event : LocationEntityBase
{
    public DateTime EventTime { get; }

    public Event(int id, int mapId, string name, string point,
                 DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy)
        : base(id, mapId, name, point, createdAt, createdBy, updatedAt, updatedBy)
    {
    }
}
