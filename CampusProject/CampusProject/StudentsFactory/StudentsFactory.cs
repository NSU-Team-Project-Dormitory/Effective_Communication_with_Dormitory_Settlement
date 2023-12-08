public sealed class StudentsFactory
{
    private readonly Students _model;

    public StudentsFactory(Students model)
    {
        _model = model;
    }
    public Students Create()
    {
        var floors = new Dictionary<Guid, Floor>();
        var firstFloor = new Building5FirstFloorFactory(_model).Create();

        var rooms = new Dictionary<Guid, Room>();

        var room100 = new Room(_model, new Guid("{d904752a-0867-4207-866e-1b54d0db5c44}"),
            "100");
       
        rooms.Add(room100.Id, room100);
        
        return new Floor(_model, new Guid("{DD656AAB-EFC8-4E35-947B-89284E781A6B}")
            , "Этаж 1", rooms);

        var building = new Students(_model, new Guid("{C52285D0-6164-410E-83A2-BC4C2001191D}"),
            "Общежитие 5", floors);

        return studets;
    }
}