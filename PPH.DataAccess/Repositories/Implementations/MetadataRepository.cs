using Dapper;
using Npgsql;
using PPH.PublicContracts.Entities;
using System.Data;

namespace PPH.DataAccess.Repositories.Implementations;

public class MetadataRepository : IMetadataRepository
{
    private readonly IDbConnection _dbConnection;

    public MetadataRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<UnitSize>> GetUnitSizesAsync()
    {
        const string sql = "SELECT id, description FROM unit_sizes";
        return await _dbConnection.QueryAsync<UnitSize>(sql);
    }

    public async Task<IEnumerable<UnitType>> GetUnitTypesAsync()
    {
        const string sql = "SELECT id, description FROM unit_types";
        return await _dbConnection.QueryAsync<UnitType>(sql);
    }

    public async Task<IEnumerable<Actor>> GetActorsAsync()
    {
        const string sql = "SELECT id, description FROM actors";
        return await _dbConnection.QueryAsync<Actor>(sql);
    }
}
