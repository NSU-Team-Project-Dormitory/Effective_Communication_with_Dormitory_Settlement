using System.Xml.Linq;
using Domain.Entities.SideInformation;


namespace Domain.Entities.People;

public class Human 
{
    public int ID { get; }
    public string  FirstName { get; }
    public string  SecondName { get; }
    public string? PatronymicName {  get; }
    public Sex Sex { get; set; }
    public DateTime DateOfBirth { get; }

    public Address Address { get; set; }



    public Human (int id,
        string firstName,
        string secondName,
        string? patronymicName,
        Sex sex,
        DateTime dateOfBirth,
        Address address
        )
    {
        ID = id;
        FirstName = new string(firstName) ?? throw new NullReferenceException("Name is null");
        SecondName = new string(secondName) ?? throw new NullReferenceException("Surname is null");
        PatronymicName = patronymicName;
        DateOfBirth = dateOfBirth;
        Address = address;
        Sex = sex;
    }

    public class HumanException : Exception
    {
        public HumanException(string message) : base(message) { }
    }
}
