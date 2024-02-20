public sealed class Building5ThirdFloorFactory
{
    private readonly CampusModel _model;

    public Building5ThirdFloorFactory(CampusModel model)
    {
        _model = model;
    }

    public Floor Create()
    {
        var rooms = new Dictionary<Guid, Room>();

        var room301s = new Room(_model, new Guid("{199d6f1d-01d7-4720-8c81-7bed4bcd3049}"),
            "301м");


        rooms.Add(room301s.Id, room301s);

        return new Floor(_model, new Guid("{25f3d7e5-dd34-4cc1-a3b6-1412e7f58fbe}")
            , "Этаж 3", rooms);
    }
}