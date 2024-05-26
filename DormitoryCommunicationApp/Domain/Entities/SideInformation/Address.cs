
using Domain.Entities.Campus;

namespace Domain.Entities.SideInformation;

public class Address
{
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string City { get; set; }
    public string? Region { get; set; } 
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public int ID { get; set; } 
    public int BuildingID { get; set; }
    public Building Building { get; set; }

    public Address() { }

    public Address(string street, string houseNumber, string? city, string? region, string? postalCode, string? country)
    {
        Street = street;
        HouseNumber = houseNumber;
        City = city;
        Region = region;
        PostalCode = postalCode;
        Country = country;
    }


    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (GetType() != obj.GetType())
        {
            return false;
        }

        Address other = (Address)obj;

        return Street == other.Street &&
               HouseNumber == other.HouseNumber &&
               City == other.City &&
               Region == other.Region &&
               PostalCode == other.PostalCode &&
               Country == other.Country;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Street, HouseNumber, City, Region, PostalCode, Country);
    }


    public override string ToString()
    {
        return $"{Street}, {HouseNumber}, {City}, {Region}, {PostalCode}, {Country}";
    }
}

