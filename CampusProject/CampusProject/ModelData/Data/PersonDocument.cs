public sealed class PersonDocument
{
    public string LastName { get; }
    public string FirstName { get; }
    public string Patronimic { get; }
    public string DocumentType { get; }
    public string DocumentId { get; }

    public PersonDocument(
        string lastName,
        string firstName,
        string patronimic,
        string documentType,
        string documentId)
    {
        LastName = lastName;
        FirstName = firstName;
        Patronimic = patronimic;
        DocumentType = documentType;
        DocumentId = documentId;
    }
}