using System.Xml.Linq;

namespace Domain.Entities.Campus;

public sealed class Floor 
{
    public string? Number {  get; set; }
    public int? Height { get; set; }

    public int? ID { get; set;  }

    public IEnumerable<Room>? Rooms { get; }

    public Floor() { }


    public Floor(string number, int height, int id)
    {
        Number = number ?? throw new NullReferenceException("Number is NUll");
        Height = height;
        ID = id;
    }

    public override string ToString()
    {
        string floorName = Number + "\n";

        foreach (var room in Rooms)
        {
            floorName += room.Number + "\n";
        }

        return floorName;
    }
}
