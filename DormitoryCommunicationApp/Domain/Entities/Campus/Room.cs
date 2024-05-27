

using Domain.Entities.App.Role;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities.Campus;

public class Room 
{
    public int ID { get; set; }
    public string Number { get; set; }

    public int Capacity { get; set; }
    public int FloorID {  get; set; }
    public virtual Floor Floor {  get; set; }
    public virtual List<Student> Students { get; set; }

    public Room() {
        Students = new List<Student>();
    }

    public Room (string number, int id, int capacity, int floorID )
    {
        Number = number;
        ID = id;
        Capacity = capacity;
        FloorID = floorID;
        Students = new List<Student>();    
    }



    public override string ToString()
    {
        string roomInfo = Number + ". Capacity: " + Capacity;

        return roomInfo;
    }
}

