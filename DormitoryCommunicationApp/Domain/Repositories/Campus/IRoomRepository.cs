
using Domain.Entities.Campus;

namespace Domain.Repositories.Campus
{
    public interface IRoomRepository
    {
        public string Add(string number, int capacity, Floor floor);
        public string Delete(Room room);

        public string Update(Room oldRoom, string number, int capacity, Floor floor);

        public Room GetRoom(string number, int floorID);


        public List<Room> GetAll();



    }
}
