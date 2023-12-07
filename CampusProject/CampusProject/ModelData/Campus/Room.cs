public sealed class Room : ModelObject
{
    public string Name { get; }
    public int Сapacity { get; }
    public string V { get; }

    public Room(IModel model, Guid id, string name,int capacity) : base(model, id)
    {
        Name = name;
        Сapacity = capacity;
    }

    public Room(IModel model, Guid id, string v) : base(model, id)
    {
        V = v;
    }

    public override string ToString()
    {
        return Name;
    }
}