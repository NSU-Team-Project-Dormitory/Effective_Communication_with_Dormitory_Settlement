

namespace Domain.Entities.SideInformation;

public class StudentGroup
{
    public int ID { get; set; } 
    public string Faculty { get; }

    StudentGroup() { }
    public StudentGroup(int id, string faculty)
    {
        ID = id;
        Faculty = faculty;
    }
}

