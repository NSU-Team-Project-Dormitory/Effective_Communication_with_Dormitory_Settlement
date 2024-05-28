
using System.Drawing;
using System.Security.Cryptography;
using Domain.Entities.Campus;
using Domain.Repositories.Campus;


namespace Data.Repositories.Campus
{
    public class RoomRepository : IRoomRepository
    {
        private static RoomRepository? roomRepository = null;
        private RoomRepository() { }
        public static RoomRepository GetRepository()
        {
            return roomRepository ??= new RoomRepository();
        }

        public string Add(string number, int capacity, Floor floor)
        {
            string result = "Already exist";

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                
                var existingRoom = db.Rooms.FirstOrDefault(r => r.Number == number && r.Floor.ID == floor.ID);
                if (existingRoom != null)
                {
                    return "Room already exists";
                }

                    Room newRoom = new()
                    {
                        Number = number,
                        Capacity = capacity,
                        Floor = floor
                    };

                    db.Rooms.Add(newRoom);
                    db.SaveChanges();
                    result = "Done";
               
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

        public Room GetRoom(string number, int floorID)
        {
            using (ApplicationDbContext db = new())
            {
                var existingRoom = db.Rooms.FirstOrDefault(r => r.Number == number && r.Floor.ID == floorID);
                return existingRoom;
            }
        }

        public List<Room> GetAll()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var result = dbContext.Rooms.ToList();
                return result;
            }
        }

    }
}


