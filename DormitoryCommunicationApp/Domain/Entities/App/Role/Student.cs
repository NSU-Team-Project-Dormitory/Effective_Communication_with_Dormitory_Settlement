
using System.Reflection.Metadata;
using Domain.Entities.Campus;
using Domain.Entities.SideInformation;

namespace Domain.Entities.App.Role;

public class Student : User 
{
    public virtual StudentGroup? StudentGroup { get; set; }

    public virtual Room Room { get; set; }

    public int ContactNumber {  get; set; }

    public Student() { }
    public Student(string login,
                  string password,
                  string name,
                  string surname,
                  string patronymic,
                  Address address,
                  DateTime dateOfBirth,
                  String sex,
                  Room room,
                  int id,
                  int contactNumber,
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
        Room = room;
        StudentGroup = studentGroup;
        ContactNumber = contactNumber;
    }



}