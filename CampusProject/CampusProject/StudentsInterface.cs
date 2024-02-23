using System;

namespace CampusProject
{
    public struct StudentsInterface
    {
        public static void Select()
        {
            var model = new CampusModel();
            var studentsFactory = new StudentsFactory(model);
            var students = studentsFactory.CreateStudents();
            Console.WriteLine("Введите операцию:all/find/add");
            var operation = Console.ReadLine();

            switch (operation)
            {
                case "all": // вывод списка всех студентов
                    Console.WriteLine("\nСписок всех студентов:");
                    foreach (var student in students)
                    {
                        Console.WriteLine(student);
                    }
                    Console.WriteLine();
                    break;
                case "find":
                    // поиск студента по фамилии

                    var findingStudents = new FindingStudents(model);
                    Console.WriteLine("\nВведите фамилию студента:");
                    string inputName = Console.ReadLine();
                    var foundStudents = findingStudents.FindStudents(inputName, students);
                    if (foundStudents != null)
                    {
                        Console.WriteLine("\nНайденные студенты:");

                        foreach (var student in foundStudents)
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

                case "add": // добавить студента
                    Console.WriteLine("\nВведите имя и фамилию студента:");
                    var input = Console.ReadLine().Split(" ");
                    var firstName = input[0];
                    var lastName = input[1];
                    // добавление студента в students
                    break;
                default:
                    Console.WriteLine("Неизвестная операция");
                    break;
            }
        }
    }
}
