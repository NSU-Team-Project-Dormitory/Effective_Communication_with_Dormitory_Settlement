using System;
using System.Collections.Generic;

namespace CampusProject
{
    public struct RemarksMenu
    {
        public static void ShowRemarksMenu(string roomNumber)
        {
            RoomRemarks remarks = new RoomRemarks();
            while (true)
            {
                Console.WriteLine("add - Добавить замечание");
                Console.WriteLine("view - Просмотреть замечания");
                Console.WriteLine("Выйти");
                Console.WriteLine("Выберите действие: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "add":
                        AddRemark(remarks);
                        break;
                    case "view":
                        ViewRemarks(remarks);
                        break;
                    case "Выйти":
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
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
    }
}
