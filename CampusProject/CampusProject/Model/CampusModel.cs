public sealed class CampusModel : IModel
{
    public Campus Campus { get; }
    public CheckInBook CheckInBook { get; }
    public StudentBook StudentBook { get; }

    public CampusModel(Campus campus, CheckInBook checkInBook, StudentBook studentBook)
    {
        Campus = campus;
        CheckInBook = checkInBook;
        StudentBook = studentBook;
    }

    public CampusModel()
    {
    }
}