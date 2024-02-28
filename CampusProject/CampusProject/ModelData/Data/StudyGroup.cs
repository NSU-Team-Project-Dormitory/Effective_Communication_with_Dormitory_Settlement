public sealed class StudyGroup
{
    public string Number { get; }
    public string Faculty { get; }


    public StudyGroup(string number, string faculty)
    {
        Number = number;
        Faculty = faculty;
    }
}