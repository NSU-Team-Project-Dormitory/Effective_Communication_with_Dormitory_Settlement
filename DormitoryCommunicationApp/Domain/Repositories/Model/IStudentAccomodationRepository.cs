using Domain.Entities.Campus;
using Domain.Entities.Model;

namespace Domain.Repositories.Model
{
    public interface IStudentAccomodationRepository
    {

        public string Add(StudentAccomodation studentAccomodation);

        public string Update(StudentAccomodation oldAccomodation, Building dormitory, Room room, string contract, DateTime startTime, DateTime endDate);

        public string Delete(StudentAccomodation studentAccomodation);

        public List<StudentAccomodation> GetAll();
    }
}
