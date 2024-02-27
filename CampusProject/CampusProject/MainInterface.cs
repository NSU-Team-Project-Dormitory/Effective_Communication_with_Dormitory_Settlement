using System;
namespace CampusProject
{
    public struct MainInterface
    {
        public static void Select()
        {
            Console.WriteLine("\nСписок доступных операций:\n" +
                "room\nstudent\nexit\n");
            string operation = Console.ReadLine();
            switch (operation)
            {
                case "room":
                    SelectRoom.Select();
                    break;
                case "student":
                    StudentsInterface.Select();
                    break;
                case "exit":
                    SelectDormitory.Message();
                    return;
                default:
                    Console.WriteLine("\nСписок доступных операций:\n" +
                        "room\nstudent\nexit\n");
                    break;
            }

        }
    }
}

