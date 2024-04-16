
using System.Reflection.Metadata;
using Domain.Entities.Campus;
using Domain.Entities.People.Attribute;
using Domain.Entities.SideInformation;

namespace Domain.Entities.App.Role;

public sealed class Student : User 
{
    public StudentGroup? StudentGroup { get; set; }
    public List<Room>? Rooms { get; set; }


    public Student() { }
    public Student(string login,
                  string password,
                  string name,
                  string surname,
                  string patronymic,
                  Address address,
                  DateTime dateOfBirth,
                  Sex sex,
                  int id,
                  List<Room> rooms,
                  StudentGroup studentGroup) 
                            : base(login,
                                 password,
                                 name,
                                 surname,
                                 patronymic,
                                 address,
                                 dateOfBirth,
                                 sex,
                                 id)
    {
        StudentGroup = studentGroup;
        Rooms = rooms;
    }

    public string ToString()
    {
        string result = "Name: " + this.FirstName + "Surname: " + this.SecondName;
        return result;
    }




}