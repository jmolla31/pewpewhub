namespace PPH.DataAccess.Models;

public class Map : TraceableEntityBase
{
    public int Id { get; private set; }
    public string Name { get; }
    public string? Description { get; }

    public Map(int id, string name, string? description,
        DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy)
        :base(createdAt, createdBy, updatedAt, updatedBy)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    internal Map WithId(int id)
    {
        Id = id;
        return this;
    }
}