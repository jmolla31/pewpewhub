using PPH.DataAccess.Models;

namespace PPH.DataAccess.Repositories;

public interface IMapsRepository
{
    IAsyncEnumerable<Map> ListAsync();

    Task<Map?> Get(int id);

    Task<Map?> Create(Map map);

    Task<string?> Update(Map map);
}
