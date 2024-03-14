

using Domain.Entities.App.Role;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities.Campus;

public sealed class Room 
{
    public string? Number { get; set; }

    public string? ID { get; set; }

    public int? Capacity { get; set; }

    public List<Student>? students { get; set; }

    public Room() { }

    public Room (string number, string id, int capacity)
    {
        Number = number;
        ID = id;
        Capacity = capacity;
        students = new List<Student> ();    
    }



    public override string ToString()
    {
        string roomInfo = Number + ". Capacity: " + Capacity;

        return roomInfo;
    }
}

