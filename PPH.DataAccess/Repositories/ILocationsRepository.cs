using PPH.PublicContracts.Entities;

namespace PPH.DataAccess.Repositories;

public interface IMetadataRepository
{
    Task<IEnumerable<UnitSize>> GetUnitSizesAsync();
    Task<IEnumerable<UnitType>> GetUnitTypesAsync();
    Task<IEnumerable<Actor>> GetActorsAsync();
}
