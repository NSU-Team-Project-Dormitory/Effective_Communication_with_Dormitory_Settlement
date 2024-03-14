
using System.Reflection.Metadata;
using Domain.Entities.People.Attribute;
using Domain.Entities.SideInformation;

namespace Domain.Entities.App.Role;

public sealed class Student : User
{
    public StudentGroup? StudentGroup { get; set; }


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
    }



}