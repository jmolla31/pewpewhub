namespace PPH.DataAccess.Models;

public class FormationSize
{
    public string Id { get; }
    public string Description { get; }

    public FormationSize(string id, string description)
    {
        Id = id;
        Description = description;
    }
}
