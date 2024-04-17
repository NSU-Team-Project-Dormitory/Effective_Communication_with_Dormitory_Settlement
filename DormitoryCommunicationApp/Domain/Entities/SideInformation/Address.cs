
namespace Domain.Entities.SideInformation;

public class Address
{
    public string Street { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; } 
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public int ID { get; set; } 

    public Address() { }

    public Address(string street, string? city, string? region, string? postalCode, string? country)
    {
        Street = street;
        City = city;
        Region = region;
        PostalCode = postalCode;
        Country = country;
    }



    // Переопределение метода ToString()
    public override string ToString()
    {
        return $"{Street}, {City}, {Region}, {PostalCode}, {Country}";
    }
}

