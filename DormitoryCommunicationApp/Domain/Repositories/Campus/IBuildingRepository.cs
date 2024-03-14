

namespace Domain.Repositories.Campus;

using System.Diagnostics.Contracts;
using Domain.Entities.Campus;
using Domain.Repositories.Common;


public interface IBuildingRepository : IReadableAll<Building>
{
    IFloorRepository FloorRepository { get; }
}