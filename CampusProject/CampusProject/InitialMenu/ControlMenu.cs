using System;
namespace CampusProject
{
	public struct ControlMenu
	{
        public void WelcomeMessage()
		{
            SelectDormitory selectdormitory = new SelectDormitory();
            Console.WriteLine("Добро пожаловать в меню общежитий");
            selectdormitory.Message();
        }
	}
}