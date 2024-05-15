
using System.Reflection.Metadata;
using Domain.Entities.Campus;
using Domain.Entities.People.Attribute;
using Domain.Entities.SideInformation;

namespace Domain.Entities.App.Role;

public sealed class Student : User 
{

    public StudentGroup? StudentGroup { get; set; }
    //public List<Room>? Rooms { get; set; }
    public Room? Room { get; set; }


    public Student() { }
    public Student(string login,
                  string password,
                  string name,
                  string surname,
                  string patronymic,
                  int contactNumber,
                  Address address,
                  DateTime dateOfBirth,
                  Sex sex,
                  int id,
                  Room room,
                  StudentGroup studentGroup) 
                            : base(login,
                                 password,
                                 name,
                                 surname,
                                 patronymic,
                                 contactNumber,
                                 address,
                                 dateOfBirth,
                                 sex,
                                 id)
    {
        StudentGroup = studentGroup;
        Room = room;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {SecondName}, Student Group: {StudentGroup?.ID}";
    }
}
