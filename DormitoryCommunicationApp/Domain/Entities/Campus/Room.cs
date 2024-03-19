

using Domain.Entities.App.Role;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities.Campus;

public sealed class Room 
{
    public string? ID { get; set; }
    public string? Number { get; set; }

    public int? Capacity { get; set; }
    public int FloorID {  get; set; }
    public Floor Floor {  get; set; }
    public List<Student> Students { get; set; }

    public Room() {
        Students = new List<Student>();
    }

    public Room (string number, string id, int capacity)
    {
        Number = number;
        ID = id;
        Capacity = capacity;
        Students = new List<Student>();    
    }



    public override string ToString()
    {
        string roomInfo = Number + ". Capacity: " + Capacity;

        return roomInfo;
    }
}

