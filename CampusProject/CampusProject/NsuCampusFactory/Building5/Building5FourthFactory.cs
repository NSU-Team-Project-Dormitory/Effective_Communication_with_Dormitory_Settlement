public sealed class Building5FourthFloorFactory
{
    private readonly CampusModel _model;

    public Building5FourthFloorFactory(CampusModel model)
    {
        _model = model;
    }

    public Floor Create()
    {
        var rooms = new Dictionary<Guid, Room>();

        var room401s = new Room(_model, new Guid("{dc8a3108-0195-4765-9eb8-7367d35a6353}"),
            "401м");


        rooms.Add(room401s.Id, room401s);

        return new Floor(_model, new Guid("{bcc6a249-b432-439b-b034-3c3a98a8fec2}")
            , "Этаж 4", rooms);
    }
}