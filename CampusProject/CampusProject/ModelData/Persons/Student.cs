using System.Text.RegularExpressions;

public class Student : ModelObject
{
    public PersonDocument Document { get; }
    public string CampusBookId { get; }
    public StudyGroup StGroup { get; }



public Student(IModel model, Guid id, PersonDocument document, string campusBookId, StudyGroup group) : base(model, id)
    {
        Document = document;
        CampusBookId = campusBookId;
        StGroup = group;

    }
    public override string ToString()
    {
        return CampusBookId;
    }
}