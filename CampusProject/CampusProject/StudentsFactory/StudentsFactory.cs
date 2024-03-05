using System.Collections.ObjectModel;
using System.Globalization;

public sealed class StudentsFactory
{
    private readonly CampusModel _model;

    public StudentsFactory(CampusModel model)
    {
        _model = model;
    }
    private Dictionary<Guid, Student> students = new Dictionary<Guid, Student>();

    public Dictionary<Guid, Student> CreateStudents()
    {

        //var student1 = new NewStudentFactory(_model).Create();
        var student1 = new Student(_model, new Guid("{83202A0D-66E8-4A1E-AD45-EEDFFC5F7C48}"),
            new PersonDocument("Klaus", "Santa", "DedMorozovich", "passport", "7776969777"),
            "1", new StudyGroup("00201", "FIT"));

        var student2 = new Student(_model, new Guid("{402B250D-EE9B-4CE4-91C9-FD705C80E21B}"),
            new PersonDocument("White", "Walter", "Chemistrovich", "passport", "420420420"),
            "2", new StudyGroup("00202", "FIT"));

        var student3 = new Student(_model, new Guid("{3DAE8460-20D5-49B1-B464-E12624E0AF56}"),
            new PersonDocument("Cena", "John", "Gigachadovich", "passport", "0001"),
            "3", new StudyGroup("00203", "FIT"));

        var student4 = new Student(_model, new Guid("{99CB47FA-7E2A-4CDF-91CE-BC6034C3408F}"),
            new PersonDocument("Klaus", "Fake", "Grinchovich", "passport", "6666666"),
            "4", new StudyGroup("00201", "FIT"));

        students.Add(student1.Id, student1);
        students.Add(student2.Id, student2);
        students.Add(student3.Id, student3);
        students.Add(student4.Id, student4);

        return students;
    }

    public Dictionary<Guid, Student> AddStudents(string lastName,
        string firstName, string patronimyc, string documentType, string documentNumber, 
        string campusBookId, string studyGroup, string faculty)
    {
        var newStudent = new Student(_model, System.Guid.NewGuid(),
            new PersonDocument(lastName, firstName, patronimyc, documentType, documentNumber), campusBookId,
            new StudyGroup(studyGroup, faculty));
        students.Add(newStudent.Id, newStudent);
        return students;
    }

    public Dictionary<Guid, Student> UpdadeName(string lastName, string firstName, string patronimyc,
    string newLastName, string newFirstName, string newPatronimyc)
    {
        var foundStudents = new Dictionary<Guid, Student>();
        var found = false;
        foreach (var student in students.Values)
        {
            if (student.Document.LastName == lastName 
                && student.Document.FirstName == firstName
                && student.Document.Patronimic == patronimyc)
            {
                if(newLastName == null)
                {
                    newLastName = student.Document.LastName;
                }
                if(newFirstName == null) { 
                    newFirstName = student.Document.FirstName;
                }

                if (newPatronimyc == null) {
                    newPatronimyc = student.Document.Patronimic; 
                }
                var updatedStudent = new Student(_model, student.Id, new PersonDocument(newLastName, newFirstName, newPatronimyc,
                    student.Document.DocumentType, student.Document.DocumentId),student.CampusBookId ,student.StGroup);

                students[student.Id] = updatedStudent;
                found = true;
            }
        }
        if (found)
        {
            Console.WriteLine("Данные о студенте успешно обновлены\n");
        }
        else
        {
            Console.WriteLine("Студент не найдет\n");
        }
        return students;
    }

    public Dictionary<Guid, Student> RemoveStudent(string lastName, string firstName, string patronimyc)
    {
        var foundStudents = new Dictionary<Guid, Student>();
        var found = 0;
        foreach (var student in students.Values)
        {
            if (student.Document.LastName == lastName 
                && student.Document.FirstName == firstName
                && student.Document.Patronimic == patronimyc)
            {
                students.Remove(student.Id);
                found++;
            }
        }
        if (found > 0)
        {
            Console.WriteLine($"Удаленно {found} студентов\n");
        }
        else
        {
            Console.WriteLine("Студент не найдет\n");
        }
        return students;
    }

}