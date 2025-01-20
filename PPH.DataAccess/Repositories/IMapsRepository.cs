using PPH.DataAccess.Models;

namespace PPH.DataAccess.Repositories;

public interface IMapsRepository
{
    IAsyncEnumerable<Map> ListAsync();

    Task<Map?> Get(int id);

    Task<string?> Create(Map map);

    Task<string?> Update(Map map);
}
