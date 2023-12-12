namespace CampusProject
{
	public struct ControlMenu
	{
        public void WelcomeMessage()
		{
            
            Console.WriteLine("Добро пожаловать в меню общежитий");

            var model = new CampusModel();
            var nsuCampus = new NsuCampusFactory(model).Create();

            Console.WriteLine(nsuCampus.ToString());
        }
	}
}