

using Domain.Entities.App.Role;
using Domain.Entities.SideInformation;

namespace Domain.Repositories.App.Role;


public interface IStudentRepository : IUserRepository<Student>
{
    public StudentGroup GetStudentGroup(int number);
}