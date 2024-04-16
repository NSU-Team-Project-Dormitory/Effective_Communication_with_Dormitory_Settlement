
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.SideInformation;
using Domain.Repositories.SideInformation;

namespace Domain.Entities.Campus;

public class Building
{
    public int? ID { get; set; }

    public string? Name { get; set; }
    public virtual Address? Address { get; set; }

    public virtual Contact? Contact { get; set; }

    public int FloorsCount { get; set; }    
    public virtual IEnumerable<Floor>? Floors { get; }



    public Building() { }

   public Building(string name, Address address, Contact contact, int floorsCount)
    {
        Address = address ?? throw new NullReferenceException("Address is null");
        Contact = contact;
        Name = name;
        FloorsCount = floorsCount;
    }


}

    