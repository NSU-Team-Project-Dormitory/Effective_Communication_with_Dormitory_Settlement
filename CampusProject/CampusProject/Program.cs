using CampusProject;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

//ControlMenu WelcomeText = new ControlMenu();
//WelcomeText.WelcomeMessage();

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


var StudentsFactory = new StudentsFactory(model);
var students = StudentsFactory.CreateStudents();
foreach (var student in students.Values)
{
    Console.WriteLine(student.CampusBookId);
}
Console.ReadLine();
