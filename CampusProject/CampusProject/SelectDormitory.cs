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

            var nsuBuildingsFactory = new NsuBuildingsFactory(model);
            var buildings = nsuBuildingsFactory.CreateBuildings();

            foreach (var building in buildings.Values)
            {
                Console.WriteLine(building.Name);
            }

            Console.WriteLine("Введите номер общежития:");
            string inputNumberDormitory = Console.ReadLine();

            switch (inputNumberDormitory)
            {
                case "Общежитие 4":
                case "4":
                    Console.WriteLine("Выбрано общежитие 4");
                    break;
                case "Общежитие 5":
                case "5":
                    Console.WriteLine("Выбрано общежитие 5");
                    SelectRoom.Select();
                    break;
                case "Общежитие 7":
                case "7":
                    Console.WriteLine("Выбрано общежитие 7");
                    break;
                default:
                    Console.WriteLine("Неправильный выбор");
                    break;
            }
        }
    }
}