public sealed class Room : ModelObject
{
    //internal string RoomId;
    //internal string RoomName;

    public string Name { get; }
    public int Сapacity { get; }

    public Room(IModel model, Guid id, string name,int capacity) : base(model, id)
    {
        Name = name;
        Сapacity = capacity;
    }

    public override string ToString()
    {
        return "Комната " + Name;
    }
}

