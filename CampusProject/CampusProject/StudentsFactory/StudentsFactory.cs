using System.Collections.ObjectModel;

public sealed class StudentsFactory
{
    private readonly CampusModel _model;

    public StudentsFactory(CampusModel model)
    {
        _model = model;
    }

    public IReadOnlyDictionary<Guid, Student> CreateStudents()
    {
        var students = new Dictionary<Guid, Student>();

        //var student1 = new NewStudentFactory(_model).Create();
        var student1 = new Student(_model, new Guid("{83202A0D-66E8-4A1E-AD45-EEDFFC5F7C48}"),
            new PersonDocument("Santa", "Klaus", "DedMorozovich", "passport", "7776969777"),
            "123321", new StudyGroup("00201", "FIT"));

        students.Add(student1.Id, student1);

        return students;
    }
}