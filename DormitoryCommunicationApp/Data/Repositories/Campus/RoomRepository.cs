
using System.Security.Cryptography;
using Domain.Entities.Campus;
using Domain.Repositories.Campus;


namespace Data.Repositories.Campus
{
    public class RoomRepository : IRoomRepository
    {
        public string Add(string number, int capacity, Floor floor)
        {
            string result = "Already exist";

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //Check if student already exists
                bool checkIfExist = false;

                //Need to reealise condition if room already exists

                if (!checkIfExist)
                {
                    Room newRoom = new()
                    {
                        Number = number,
                        Capacity = capacity,
                        Floor = floor
                    };

                    db.Rooms.Add(newRoom);
                    db.SaveChanges();
                    result = "Done";
                }
                return result;
            }
        }



        public string Delete(Room room)
        {
            string result = "This room doesn't exist";

            using (ApplicationDbContext db = new())
            {
                db.Rooms.Remove(room);
                db.SaveChanges();
                result = "Done. Room: " + room.Number + " has been removed";
            }
            return result;
        }

        public string Update(Room oldRoom, string number, int capacity, Floor floor)
        {
            string result = "This room doesn't exist";

            using (ApplicationDbContext db = new())
            {
                Room room = db.Rooms.FirstOrDefault(el => el.ID == oldRoom.ID);

                room.Number = number;
                room.Capacity = capacity;
                room.Floor = floor;



                db.SaveChanges();
                result = "Done. Room " + oldRoom.Number + " has been changed";
            }
            return result;
        }

        public static IEnumerable<Room> GetAll()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var result = dbContext.Rooms.ToList();
                return result;
            }
        }
    }
}


