

using System.Text.RegularExpressions;
using Domain.Entities.Campus;

namespace Domain.Entities.SideInformation;



public class Contact
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int ID { get; set; }


    public Contact() { }

    public Contact(string email, string phoneNumber, int id)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        ID = id;
    }
}

public class ContactException : EndOfStreamException
{
    public ContactException(string message) : base(message) { }
}
