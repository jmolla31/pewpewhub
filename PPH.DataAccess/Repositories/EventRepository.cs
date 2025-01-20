using Dapper;
using PPH.DataAccess.Models;
using System.Data;

namespace PPH.DataAccess.Repositories;

public class EventRepository
{
    private readonly IDbConnection _dbConnection;

    public EventRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async IAsyncEnumerable<Event> GetMapEventsStream(int mapId)
    {
        var sql = @"
            SELECT id, map_id, name, ST_AsGeoJSON(point) AS point, created_at, created_by
            FROM events
            WHERE map_id = @MapId
            ORDER BY created_at DESC
            OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
        ";

        IEnumerable<Event> events;

        var skip = 0;
        var take = 1;

        do
        {
            events = await _dbConnection.QueryAsync<Event>(sql, new
            {
                MapId = mapId,
                Offset = skip,
                PageSize = take
            });

            skip += take;


            foreach (var item in events)
            {
                yield return item;
            }
        }
        while (events.Any());
    }
}
