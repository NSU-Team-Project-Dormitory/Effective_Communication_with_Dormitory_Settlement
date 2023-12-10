internal class CheckInRecord
{
    public Student Person { get; }
    public Room Room { get; }

    public CheckInRecord(Student person, Room room)
    {
        Person = person;
        Room = room;
    }
}