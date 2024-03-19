
namespace Domain.Entities.SideInformation;

public sealed class Address(string street, string city, string region, string postalCode, string country, int iD)
{
    public string Street { get; set; } = street;
    public string City { get; set; } = city;
    public string Region { get; set; } = region;
    public string PostalCode { get; set; } = postalCode;
    public string Country { get; set; } = country;
    public int ID { get; set; } = iD;
}
