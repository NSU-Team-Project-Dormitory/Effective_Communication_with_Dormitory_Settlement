
using Domain.Entities.Campus;
using Domain.Entities.SideInformation;

namespace Domain.Repositories.Campus
{
    public interface IStudentGroupRepository
    {
        public string Add(int id, string faculcy);

        public string Delete(StudentGroup group);

        public StudentGroup GetGroup(int id, string faculcy);

        public List<StudentGroup> GetAll();

    }
}
