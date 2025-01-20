using PPH.DataAccess.Models;

namespace PPH.DataAccess.Repositories;

public interface ILocationsRepository
{
    IAsyncEnumerable<Location> ListDefault();
    IAsyncEnumerable<Location> List(int mapId);

    Task<Location> Get(int id, int mapId);

    Task<string?> Create(Location location);
    Task<string?> Update(Location location);
}
