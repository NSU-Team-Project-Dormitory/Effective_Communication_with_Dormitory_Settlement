using System.Collections.ObjectModel;

public sealed class FindingStudents
{
    private readonly CampusModel _model;

    public FindingStudents(CampusModel model)
    {
        _model = model;
    }

    public IReadOnlyDictionary<Guid, Student> FindStudents(string inputName, IReadOnlyDictionary<Guid, Student> allStudents)
    {
        var foundStudents = new Dictionary<Guid, Student>();
        var found = false;
        foreach (var student in allStudents.Values)
        {
            if (student.Document.LastName.Contains(inputName) 
                || student.Document.FirstName.Contains(inputName)
                || student.Document.Patronimic.Contains(inputName))
            {
                foundStudents.Add(student.Id, student);
                found = true;
            }
        }
        if (found)
        {
            return foundStudents;
        }
        else 
        { 
            return null;
        }
    }

}
