﻿public sealed class Floor : ModelObject
{
    public string Name { get; }

    public IReadOnlyDictionary<Guid, Room> Rooms { get; }

    public Floor(IModel model, Guid id,
        string name, IReadOnlyDictionary<Guid, Room> rooms) : base(model, id)
    {
        Name = name;
        Rooms = rooms;
    }

    internal object GetRoomByNumber(string? roomNumber)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        string floorName = Name + "\n";

        foreach (var room in Rooms)
        {
            floorName += room.Value.ToString() + "\n";
        }

        return floorName;
    }
}