
using System.Xml.Linq;
using Domain.Entities.App.Role;
using Domain.Entities.SideInformation;
using Domain.Entities.Campus;

namespace Domain.Repositories.App.Role
{
    public interface IStudentRepository
    {
        public Boolean Add(string login, string password, string name, string surname, string patronymic,
                          int contactNumber, DateTime dateOfBirth, string sex, StudentGroup studentGroup);

        public Boolean Add(Student newStudent);

        public string Delete(Student student);

        public List<Student> GetAll();

        public string Update(Student oldStudent, string login, string password, string name, string surname,
                     string patronymic, string sex, StudentGroup studentGroup);

        public List<Student> Find(string name, string surname, string patronymic);

        public List<Student> Find(string surname);

        public Boolean CheckIn(Student student, Room room);

        public Boolean CheckOut(Student student, Room room);

        public Boolean SwapStudents(Student student1, Student Student2);

    }
}





