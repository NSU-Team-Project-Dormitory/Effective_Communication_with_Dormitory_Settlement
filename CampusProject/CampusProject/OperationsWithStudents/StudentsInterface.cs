using System;

namespace CampusProject
{
    public struct StudentsInterface
    {
        public static void Select()
        {
            var model = new CampusModel();
            var nsuFactory = new NsuCampusFactory(model);
            var nsuCampus = nsuFactory.Create();

            //Console.WriteLine(nsuCampus.Name);

            var nsuBuildingsFactory = new NsuBuildingsFactory(model);
            var buildings = nsuBuildingsFactory.CreateBuildings();


            foreach (var building in buildings.Values)
            {
                //Console.WriteLine(building.Name);
            }


            //вывод всех студентов кампуса

            var StudentsFactory = new StudentsFactory(model);
            var students = StudentsFactory.CreateStudents();
            while (true)
            {
                Console.WriteLine("\nСписок доступных операций:\n" +
                    "all\nfind\nadd\nexit\n");
                var operation = Console.ReadLine();

                switch (operation)
                {
                    case "all": //вывод списка всех студентов
                        Console.WriteLine("\nСписок всех студентов:");
                        foreach (var student in students.Values)
                        {
                            Console.WriteLine(student);
                        }
                        Console.WriteLine();
                        break;
                    case "find":
                        //поиск студента по фамилии

                        var findingStudents = new FindingStudents(model);
                        Console.WriteLine("\nВведите фамилию студента:");
                        string inputName = Console.ReadLine();
                        var foundStudens = findingStudents.FindStudents(inputName, students);
                        if (foundStudens != null)
                        {
                            Console.WriteLine("\nНайденные студенты:");

                            foreach (var student in foundStudens.Values)
                            {
                                Console.WriteLine(student);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Студент не найден!\n");
                        }
                        Console.WriteLine();
                        break;

                    case "add": //добавить студента
                        Console.WriteLine("\nВведите имя студента:");
                        var firstName = Console.ReadLine();
                        Console.WriteLine("Введите фамилию студента:");
                        var lastName = Console.ReadLine();
                        students = StudentsFactory.AddStudents(firstName, lastName, "1", "1", "1", "1", "1", "1");
                        Console.WriteLine("Студент добавлен");
                        break;
                    case "exit":
                        return;
                        
                    default:
                        Console.WriteLine("\nСписок доступных операций:\n" +
                            "all\nfind\nadd\nexit\n");
                        break;
                }
            }
        }
    }
}
