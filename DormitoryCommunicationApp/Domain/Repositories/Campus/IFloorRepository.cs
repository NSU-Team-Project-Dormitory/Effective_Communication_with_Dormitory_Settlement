

using Domain.Entities.Campus;

namespace Domain.Repositories.Campus;

public interface IFloorRepository : IDatabaseRepository<Floor>
{
    Task<IEnumerable<Floor>> ReadFloorByBuildingIdAsync(int id);
    IEnumerable<Floor> ReadFloorByBuildingId(int id)
    {
        return ReadFloorByBuildingIdAsync(id).GetAwaiter().GetResult();
    }
}

