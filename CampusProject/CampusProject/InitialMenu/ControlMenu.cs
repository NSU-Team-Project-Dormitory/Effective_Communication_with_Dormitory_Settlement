using System;
namespace CampusProject
{
	public struct ControlMenu
	{
        public void WelcomeMessage()
		{
            Console.WriteLine("Добро пожаловать в меню общежитий");
            SelectDormitory.Message();
        }
	}
}