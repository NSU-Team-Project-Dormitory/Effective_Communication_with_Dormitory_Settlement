
using System.Xml.Linq;
using Domain.Entities.App.Role;
using Domain.Entities.People.Attribute;
using Domain.Entities.SideInformation;

namespace Domain.Repositories.App.Role
{
    public interface IStudentRepository
    {
        public string Add(string login, string password, string name, string surname, string patronymic, DateTime dateOfBirth, Sex sex, StudentGroup studentGroup);


        public string Update(Student oldStudent, string login, string password, string name, string surname, string patronymic, DateTime dateOfBirth, Sex sex, StudentGroup studentGroup);

        public string Delete(Student student);




    }
}






