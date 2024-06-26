﻿using System.Xml.Linq;

namespace Domain.Entities.Campus;

public  class Floor 
{
    public string Number {  get; set; }
    public int Height { get; set; }

    public int ID { get; set;  }


    public virtual Building Dormitory { get; set; }

    public virtual List<Room> Rooms { get; }

    public Floor() { }



    public Floor(string number, int height, int id)
    {
        Number = number ?? throw new NullReferenceException("Number is Null");
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
