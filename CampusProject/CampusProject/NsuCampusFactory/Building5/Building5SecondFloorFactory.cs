public sealed class Building5SecondFloorFactory
{
    private readonly CampusModel _model;

    public Building5SecondFloorFactory(CampusModel model)
    {
        _model = model;
    }

    public Floor Create()
    {
        var rooms = new Dictionary<Guid, Room>();

        var room201s = new Room(_model, new Guid("{41e11716-eccf-43ad-a4ff-1c159b20781f}"),
            "201м");
        var room201b = new Room(_model, new Guid("{ae4d79bf-ba15-49c0-bc88-ef11b91479e2}"),
            "202б");
        var room202s = new Room(_model, new Guid("{85d2d6be-7ad0-4975-aab1-7206a7e22e88}"),
            "202м");
        var room202b = new Room(_model, new Guid("{3077ea37-eca6-4512-9362-f38abe681ac4}"),
            "202б");

        rooms.Add(room201s.Id, room201s);
        rooms.Add(room201b.Id, room201b);
        rooms.Add(room202s.Id, room202s);
        rooms.Add(room202b.Id, room202b);

        return new Floor(_model, new Guid("{0b3de4fd-b8c3-4955-a0fc-4bd953385e6e}")
            , "Этаж 2", rooms);
    }
}