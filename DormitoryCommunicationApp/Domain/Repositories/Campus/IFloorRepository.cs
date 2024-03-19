using Domain.Entities.Campus;

namespace Domain.Repositories.Campus
{
    public interface IFloorRepository
    {

        public string Add(Floor floor);
        public string Update(Floor oldFloor, string newNumber, int newHeight, Building newBuilding);

        public string Delete(Floor floor);

    }
}
