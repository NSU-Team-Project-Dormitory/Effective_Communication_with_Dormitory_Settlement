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
                Console.WriteLine($"Выбрана комната {roomNumber}");
                ShowRemarksMenu(roomNumber); // Показать меню с возможностью добавления и просмотра замечаний
            }
            else
            {
                Console.WriteLine($"Комната {roomNumber} не существует.");
            }
        }

        private static void ShowRemarksMenu(string roomNumber)
        {
            RoomRemarks remarks = new RoomRemarks();
            while (true)
            {
                Console.WriteLine("1. Добавить замечание");
                Console.WriteLine("2. Просмотреть замечания");
                Console.WriteLine("3. Выйти");
                Console.WriteLine("Выберите действие: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRemark(remarks);
                        break;
                    case "2":
                        ViewRemarks(remarks);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Недопустимый выбор");
                        break;
                }
            }
        }

        private static void AddRemark(RoomRemarks remarks)
        {
            Console.WriteLine("Выберите тип замечания (Cleaning, FireSafety, Behavior, Custom): ");
            var typeString = Console.ReadLine();
            NoteType type;
            if (Enum.TryParse(typeString, out type))
            {
                Console.WriteLine("Введите содержание замечания: ");
                var content = Console.ReadLine();
                Console.WriteLine("Введите номер замечания: ");
                var noteNumber = Convert.ToInt32(Console.ReadLine());

                remarks.AddRemark(type, content, noteNumber);
                Console.WriteLine("Замечание добавлено");
            }
            else
            {
                Console.WriteLine("Недопустимый тип замечания");
            }
        }

        private static void ViewRemarks(RoomRemarks remarks)
        {
            remarks.ViewRemarks();
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
