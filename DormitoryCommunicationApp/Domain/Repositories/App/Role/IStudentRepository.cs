
using System.Xml.Linq;
using Domain.Entities.App.Role;
using Domain.Entities.SideInformation;

namespace Domain.Repositories.App.Role
{
    public interface IStudentRepository
    {
        public string Add(string login, string password, string name, string surname, string patronymic, DateTime dateOfBirth, String sex, StudentGroup studentGroup, int contactNumber);


        public string Update(Student oldStudent, string login, string password, string name, string surname, string patronymic, DateTime dateOfBirth, String sex, StudentGroup studentGroup);

        public string Delete(Student student);


        public List<Student> GetAll();

        public List<Student> GetStudentByRoomNumber(int roomNumber);



    }
}






