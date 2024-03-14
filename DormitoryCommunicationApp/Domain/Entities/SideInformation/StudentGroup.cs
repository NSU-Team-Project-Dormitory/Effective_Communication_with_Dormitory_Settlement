

namespace Domain.Entities.SideInformation;

public sealed class StudentGroup
{
    public int ID { get; set; } 
    public string? Number { get; }
    public string? Faculty { get; }

    StudentGroup() { }
    public StudentGroup(string number, string faculty)
    {
        Number = number;
        Faculty = faculty;
    }
}