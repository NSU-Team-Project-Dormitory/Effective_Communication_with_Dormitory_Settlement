
namespace Domain.Entities.SideInformation;

public sealed class Address 
{
    public string Street { get; set; }  
    public string City { get; set; }    
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }

    public int ID { get; }

    public Address (string street, string city, string region, string postalCode, string country, int id)
    {
        Street = street;
        City = city;
        Region = region;
        PostalCode = postalCode;
        Country = country;
        ID = id;
    }   
}
