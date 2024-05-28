using System.Linq;
using Domain.Entities.Campus;
using Domain.Repositories.Campus;
using Microsoft.EntityFrameworkCore;

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
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // Check if room already exists
                var existingRoom = db.Rooms.FirstOrDefault(r => r.Number == number && r.Floor.ID == floor.ID);
                if (existingRoom != null)
                {
                    return "Room already exists";
                }

                try
                {
                    Room newRoom = new()
                    {
                        Number = number,
                        Capacity = capacity,
                        Floor = floor
                    };

                    db.Rooms.Add(newRoom);
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // Log exception details or rethrow with more information
                    throw new Exception($"An error occurred while adding the room: {ex.Message}", ex);
                }

                return "Done";
            }
        }

        public string Delete(Room room)
        {
            using (ApplicationDbContext db = new())
            {
                var existingRoom = db.Rooms.FirstOrDefault(r => r.ID == room.ID);
                if (existingRoom == null)
                {
                    return "This room doesn't exist";
                }

                try
                {
                    db.Rooms.Remove(existingRoom);
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // Log exception details or rethrow with more information
                    throw new Exception($"An error occurred while deleting the room: {ex.Message}", ex);
                }

                return $"Done. Room: {room.Number} has been removed";
            }
        }

        public string Update(Room oldRoom, string number, int capacity, Floor floor)
        {
            using (ApplicationDbContext db = new())
            {
                var room = db.Rooms.FirstOrDefault(r => r.ID == oldRoom.ID);
                if (room == null)
                {
                    return "This room doesn't exist";
                }

                try
                {
                    room.Number = number;
                    room.Capacity = capacity;
                    room.Floor = floor;

                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // Log exception details or rethrow with more information
                    throw new Exception($"An error occurred while updating the room: {ex.Message}", ex);
                }

                return $"Done. Room {oldRoom.Number} has been changed";
            }
        }

        public List<Room> GetAll()
        {
            using (ApplicationDbContext db = new())
            {
                return db.Rooms.ToList();
            }
        }
    }
}
