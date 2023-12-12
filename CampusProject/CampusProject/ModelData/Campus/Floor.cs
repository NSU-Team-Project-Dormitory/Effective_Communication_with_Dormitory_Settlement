public sealed class Floor : ModelObject
{
    public int Name { get; }

    public IReadOnlyDictionary<Guid, Room> Rooms { get; }

    public Floor(IModel model, Guid id,
        int name, IReadOnlyDictionary<Guid, Room> rooms) : base(model, id)
    {
        Name = name;
        Rooms = rooms;
    }

    public override string ToString()
    {
        string floorName = "Этаж " + Name + "\n";

        foreach (var room in Rooms)
        {
            floorName += room.Value.ToString() + "\n";
        }

        return floorName;
    }

    internal List<Room> GetRooms()
    {
        throw new NotImplementedException();
    }
}