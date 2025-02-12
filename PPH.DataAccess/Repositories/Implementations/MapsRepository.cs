using Dapper;
using PPH.DataAccess.Models;
using System.Data;

namespace PPH.DataAccess.Repositories.Implementations;


public sealed class MapsRepository : IMapsRepository
{
    private readonly IDbConnection _dbConnection;

    public MapsRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async IAsyncEnumerable<Map> ListAsync()
    {
        const string query = "SELECT * FROM maps";
        var maps = await _dbConnection.QueryAsync<Map>(query);

        foreach (var map in maps)
        {
            yield return map;
        }
    }


    public async Task<Map?> Get(int id)
    {
        const string query = "SELECT * FROM map WHERE id = @Id;";
        return await _dbConnection.QueryFirstOrDefaultAsync<Map>(query, new { Id = id });
    }

    public async Task<Map?> Create(Map map)
    {
        const string query = @"
            INSERT INTO maps (name, description, created_at, created_by)
            VALUES (@Name, @Description, @CreatedAt, @CreatedBy)
            RETURNING id;";

        try
        {
            var id = await _dbConnection.ExecuteScalarAsync<int>(query, new
            {
                map.Name,
                map.Description,
                CreatedAt = DateTime.UtcNow,
                map.CreatedBy
            });

            return map.WithId(id);
        }
        catch (Exception ex)
        {
            // Handle or log the exception as needed
            Console.WriteLine($"Error creating map: {ex.Message}");
            return null;
        }
    }

    public async Task<string?> Update(Map map)
    {
        const string query = @"
            UPDATE map
            SET name = @Name,
                description = @Description,
                updated_at = @UpdatedAt,
                updated_by = @UpdatedBy
            WHERE id = @Id
            RETURNING id;";

        try
        {
            var id = await _dbConnection.ExecuteScalarAsync<int?>(query, new
            {
                map.Id,
                map.Name,
                map.Description,
                UpdatedAt = DateTime.UtcNow,
                map.UpdatedBy
            });

            return id?.ToString();
        }
        catch (Exception ex)
        {
            // Handle or log the exception as needed
            Console.WriteLine($"Error updating map: {ex.Message}");
            return null;
        }
    }
}


public class DateTimeHandler : SqlMapper.TypeHandler<DateTime>
{
    public override void SetValue(IDbDataParameter parameter, DateTime value)
    {
        parameter.Value = value;
    }

    public override DateTime Parse(object value)
    {
        return DateTime.SpecifyKind((DateTime)value, DateTimeKind.Utc);
    }
}