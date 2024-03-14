
using Domain.Entities.App.Role;
using Domain.Entities.Campus;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities.Model;


public sealed class StudentAccomodation
{
    public int ID { get; set; }
    public Building? Dormitory { get; set; }
    
    public Room? Room { get; set; }

    public string? Contract { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; } 


    public StudentAccomodation() { }
    
    public StudentAccomodation(int id, Building? dormitory, Room? room, string? contract, DateTime? startDate, DateTime? endDate)
    {
        ID = id;
        Dormitory = dormitory;
        Room = room;   
        Contract = contract;
        StartDate = startDate;
        EndDate = endDate;
    }

}


