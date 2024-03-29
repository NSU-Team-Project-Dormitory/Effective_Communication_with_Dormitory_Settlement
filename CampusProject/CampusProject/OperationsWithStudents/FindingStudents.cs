﻿using System.Collections.ObjectModel;

public sealed class FindingStudents
{
    private readonly CampusModel _model;

    public FindingStudents(CampusModel model)
    {
        _model = model;
    }

    public IReadOnlyDictionary<Guid, Student> FindStudents(string inputName, IReadOnlyDictionary<Guid, Student> allStudents)
    {
        var foundStudents = new Dictionary<Guid, Student>();

        foreach (var student in allStudents.Values)
        {
            if (student.Document.LastName == inputName)
            {
                foundStudents.Add(student.Id, student);
            }
        }

        return foundStudents;
    }

}