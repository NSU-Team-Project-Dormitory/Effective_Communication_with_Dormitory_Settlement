using System;

namespace CampusProject
{
    public struct SelectRoom
    {
        public static void Select()
        {
            var model = new CampusModel();
            var building5FirstFloorFactory = new Building5FirstFloorFactory(model);
            Console.WriteLine("Введите номер комнаты: ");
            var roomNumber = Console.ReadLine();

            if (RoomExists(building5FirstFloorFactory, roomNumber))
            {
                Console.WriteLine("СЮДА ВЫВОДИТЬ ЭТИХ ЗАСЕЛЕНЦЕВ");
            }
            else
            {
                Console.WriteLine($"Комната {roomNumber} не существует.");
            }
        }

        private static bool RoomExists(Building5FirstFloorFactory buildingFactory, string roomNumber)
        {
            var floor = buildingFactory.Create();
            foreach (var room in floor.Rooms.Values)
            {
                if (room.Name == roomNumber)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
