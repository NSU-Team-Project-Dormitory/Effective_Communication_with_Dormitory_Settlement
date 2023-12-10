using CampusProject;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

//ControlMenu WelcomeText = new ControlMenu();
//WelcomeText.WelcomeMessage();

//создание модели кампуса
var model = new CampusModel();
var nsuFactory = new NsuCampusFactory(model);
var nsuCampus = nsuFactory.Create();

Console.WriteLine(nsuCampus.Name);

var nsuBuildingsFactory = new NsuBuildingsFactory(model);
var buildings = nsuBuildingsFactory.CreateBuildings();


foreach (var building in buildings.Values)
{
    Console.WriteLine(building.Name);
}


//вывод всех студентов кампуса

var StudentsFactory = new StudentsFactory(model);
var students = StudentsFactory.CreateStudents();
Console.WriteLine("\nList of all students:");
foreach (var student in students.Values)
{
    Console.WriteLine(student);
}


//поиск студента по фамилии

var findingStudents = new FindingStudents(model);
Console.WriteLine("\nВведите фамилию студента:");
string inputName = Console.ReadLine();
var foundStudens = findingStudents.FindStudents(inputName, students);
Console.WriteLine("\nНайденные студенты:");

foreach (var student in foundStudens.Values)
{
    Console.WriteLine(student);
}

Console.ReadLine();
