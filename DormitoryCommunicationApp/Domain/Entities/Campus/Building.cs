
using Domain.Entities.SideInformation;

namespace Domain.Entities.Campus;

public sealed class Building
{
    public int? ID { get; set; }

    public string? Name;
    public Address? Address { get; set; }   

    public Contact? Contact { get; set; }

    public int FloorsCount { get; set; }    
    public IEnumerable<Floor>? Floors { get; }



    public Building() { }

   public Building(Address address, int id, Contact contact, string name, Building dormitory, int floorsCount)
    {
        Address = address ?? throw new NullReferenceException("Address is null");
        ID = id;
        Contact = contact;
        Name = name;
        FloorsCount = floorsCount;
    }

    public override string ToString()
    {
        string buildingInfo = Name + "\n";

        foreach (var floor in Floors)
        {
            buildingInfo += floor.Number + "\n";
        }

        return buildingInfo;
    }
}

    