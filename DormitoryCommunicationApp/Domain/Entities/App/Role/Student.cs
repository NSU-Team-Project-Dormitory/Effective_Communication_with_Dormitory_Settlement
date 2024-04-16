
using System.Reflection.Metadata;
using Domain.Entities.SideInformation;

namespace Domain.Entities.App.Role;

public class Student : User 
{
    public virtual StudentGroup? StudentGroup { get; set; }

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
        StudentGroup = studentGroup;
        ContactNumber = contactNumber;
    }



}