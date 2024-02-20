public sealed class Building5FifthhFloorFactory
{
    private readonly CampusModel _model;

    public Building5FifthhFloorFactory(CampusModel model)
    {
        _model = model;
    }

    public Floor Create()
    {
        var rooms = new Dictionary<Guid, Room>();

        var room501s = new Room(_model, new Guid("{bcc6a249-b432-439b-b034-3c3a98a8fec2}"),
            "501м");


        rooms.Add(room501s.Id, room501s);

        return new Floor(_model, new Guid("{b861d627-55a2-498c-9277-04d3f207391c}")
            , "Этаж 5", rooms);
    }
}