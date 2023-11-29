using System;
namespace CampusProject
{
	public struct SelectDormitory
	{
        public void Message()
        {
            var model = new CampusModel();
            var nsuFactory = new NsuCampusFactory(model);
            var nsuCampus = nsuFactory.Create();

            Console.WriteLine(nsuCampus.Name);

            Console.WriteLine("Выберите общежитие");


            Console.ReadLine();
        }
    }
}