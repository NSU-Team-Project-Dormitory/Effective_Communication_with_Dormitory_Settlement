using System;
using System.Reflection;

namespace CampusProject
{
    public struct Connection5Dormitory
    {
        public void Buildings()
        {
            var model = new CampusModel();
            var nsuFactory = new NsuCampusFactory(model);
            var nsuCampus = nsuFactory.Create();

            var factory = new Building5FirstFloorFactory();
            Floor floor = factory.Create();
            List<Room> rooms = floor.GetRooms();
            foreach (Room room in rooms)
            {
                Console.WriteLine("Room ID: " + room.RoomId);
                Console.WriteLine("Room Name: " + room.RoomName);
                
            }
        }
    }
}