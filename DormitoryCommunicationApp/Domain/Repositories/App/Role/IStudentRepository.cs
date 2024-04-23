
using System.Xml.Linq;
using Domain.Entities.App.Role;
using Domain.Entities.People.Attribute;
using Domain.Entities.SideInformation;
using Domain.Entities.Campus;

namespace Domain.Repositories.App.Role
{
    public interface IStudentRepository
    {
        public string Add(string login, string password, string name, string surname, string patronymic, int contactNumber, DateTime dateOfBirth, Sex sex, StudentGroup studentGroup);
        
        public void Add(Student student);

        public string Update(Student oldStudent, string login, string password, string name, string surname, string patronymic, DateTime dateOfBirth, Sex sex, StudentGroup studentGroup);

        public string Delete(Student student);

        public List<Student> Find(string name, string surname, string patronymic);

        public List<Student> Find(string surname);

        public Boolean CheckIn(Student student, Room room);

        public Boolean CheckOut(Student student, Room room);

        public Boolean SwapStudents(Student student1, Student Student2);



        public List<Student> GetAll();



    }
}






