using System;
using System.Collections.Generic;

namespace CampusProject
{
    public enum NoteType
    {
        Cleaning,
        FireSafety,
        Behavior,
        Custom
    }

    public class RoomRemarks
    {
        private List<string> remarks;

        public RoomRemarks()
        {
            remarks = new List<string>();
        }

        public void AddRemark(NoteType type, string content, int noteNumber)
        {
            remarks.Add($"{type.ToString()}: {noteNumber} - {content}");
        }

        public void ViewRemarks()
        {
            if (remarks.Count == 0)
            {
                Console.WriteLine("Замечаний пока нет");
            }
            else
            {
                Console.WriteLine("Замечания:");
                foreach (var remark in remarks)
                {
                    Console.WriteLine(remark);
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            RoomRemarks roomRemarks = new RoomRemarks();

            Console.WriteLine("Выберите тип замечания:");
            Console.WriteLine("1. Уборка");
            Console.WriteLine("2. Пожарная безопасность");
            Console.WriteLine("3. Поведение");
            Console.WriteLine("4. Написать замечание самостоятельно");
            int choice = int.Parse(Console.ReadLine());

            NoteType type;

            switch (choice)
            {
                case 1:
                    type = NoteType.Cleaning;
                    break;
                case 2:
                    type = NoteType.FireSafety;
                    break;
                case 3:
                    type = NoteType.Behavior;
                    break;
                case 4:
                    type = NoteType.Custom;
                    break;
                default:
                    throw new ArgumentException("Неверный выбор типа замечания");
            }

            Console.WriteLine("Введите номер замечания:");
            int noteNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите содержимое замечания:");
            string content = Console.ReadLine();

            roomRemarks.AddRemark(type, content, noteNumber);
            roomRemarks.ViewRemarks();
        }
    }

    public class Room
    {
        public string Number { get; set; }
        public List<string> Remarks { get; set; }

        public Room(string number)
        {
            Number = number;
            Remarks = new List<string>();
        }
    }

    public class Floor
    {
        public List<Room> Rooms { get; set; }

        public Floor()
        {
            Rooms = new List<Room>();
        }
    }
}
