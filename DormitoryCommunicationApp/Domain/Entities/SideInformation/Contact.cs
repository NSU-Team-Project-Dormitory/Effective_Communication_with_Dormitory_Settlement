

namespace Domain.Entities.SideInformation;

public enum ContactType
{
        Email,
        PhoneNumber,
}


public sealed class Contact
{
    public string? Email { get; set; }
    public string? PhoneNumber { get; set;}
    public int ID { get; }

    public Contact(string? email, string? phoneNumber, int id)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        ID = id;
    }
}

public class ContactException : EndOfStreamException
{
    public ContactException(string message) : base(message { }
}
