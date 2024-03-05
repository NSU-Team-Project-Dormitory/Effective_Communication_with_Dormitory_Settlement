using CampusProject;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

//ControlMenu WelcomeText = new ControlMenu();
//WelcomeText.WelcomeMessage();

//создание модели кампуса
var model = new CampusModel();
var nsuFactory = new NsuCampusFactory(model);
var nsuCampus = nsuFactory.Create();

//Console.WriteLine(nsuCampus.Name);

var nsuBuildingsFactory = new NsuBuildingsFactory(model);
var buildings = nsuBuildingsFactory.CreateBuildings();


//вывод всех студентов кампуса

var StudentsFactory = new StudentsFactory(model);
var students = StudentsFactory.CreateStudents();
while (true)
{
    Console.WriteLine("\nСписок доступных операций:\n" +
    "all\nfind\nadd\nupdate\nremove\nexit\n");
    Console.WriteLine("Введите операцию:");
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
            Console.WriteLine("\nВведите имя студента:");
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
            Console.WriteLine("\nВведите имя и фамилию студента:");
            var input = Console.ReadLine().Split(" ");
            var firstName = input[0];
            var lastName = input[1];
            students = StudentsFactory.AddStudents(lastName, firstName, "1", "1", "1", "1", "1", "1");
            Console.WriteLine();
            break;
        case "update":
            Console.WriteLine("\nВведите ФИО студента:");
            var inputFind = Console.ReadLine().Split(" ");
            var firstNameUpd = inputFind[0];
            var lastNameUpd = inputFind[1];
            var patronimycUpd = inputFind[2];

            Console.WriteLine("\nВведите новое имя студента:");
            var newFirstName = Console.ReadLine();
            if (newFirstName == "\n") newFirstName = null;

            Console.WriteLine("\nВведите новую фамилию студента:");
            var newLastName = Console.ReadLine();
            if(newLastName == "\n") newLastName = null;

            Console.WriteLine("\nВведите новое отчество студента:");
            var newPatronimyc = Console.ReadLine();
            if(newPatronimyc == "\n") newPatronimyc = null;


            students = StudentsFactory.UpdadeName(lastNameUpd, firstNameUpd,patronimycUpd, newLastName, newFirstName, newPatronimyc);
            //var updateStudents = new UpdateStudenInfo(model);
            //students = updateStudents.updadeName(lastNameUpd, firstNameUpd, newLastName, newFirstName, students);
            break;
        case "remove":
            Console.WriteLine("\nВведите ФИО студента:");
            var inputRem = Console.ReadLine().Split(" ");
            var firstNameRem = inputRem[0];
            var lastNameRem = inputRem[1];
            var patronimycRem = inputRem[2];
            students = StudentsFactory.RemoveStudent(lastNameRem, firstNameRem, patronimycRem);
            break;
        case "exit":
            return 0;
        default:
            Console.WriteLine("\nСписок доступных операций:\n" +
            "all\nfind\nadd\nupdate\nremove\nexit\n");
            break;
    }
}







Console.ReadLine();
