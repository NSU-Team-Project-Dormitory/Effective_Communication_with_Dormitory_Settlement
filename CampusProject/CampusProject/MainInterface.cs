using System;
namespace CampusProject
{
	public struct MainInterface
	{
		public static void Select()
		{
            Console.WriteLine("Выберите следующее действие: room/student");
            Console.WriteLine("Выйти");
            string way = Console.ReadLine();
            if (way == "room")
            {
                SelectRoom.Select();
            }
            else if (way == "student")
            {
                StudentsInterface.Select();
            }
            else if (way == "Выйти")
            {
                SelectDormitory.Message();
                return;
            }
        }
	}
}

