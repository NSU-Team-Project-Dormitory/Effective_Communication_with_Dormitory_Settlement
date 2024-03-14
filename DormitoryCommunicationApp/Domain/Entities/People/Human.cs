
using Domain.Entities.SideInformation;
using Domain.Entities.People.Attribute;

namespace Domain.Entities.People;

public class Human 
{
    public int ID { get; set; }
    public string?  FirstName { get; set; }
    public string?  SecondName { get; set; }
    public string? PatronymicName {  get; set; }
    public Sex Sex { get; set; }
    public DateTime DateOfBirth { get; set; }

    public Address? Address { get; set; }



    public Human() { }
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
