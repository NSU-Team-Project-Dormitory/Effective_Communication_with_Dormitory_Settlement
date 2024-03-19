
using Domain.Entities.App.Role;
using Domain.Entities.People.Attribute;
using Domain.Entities.SideInformation;
using Domain.Repositories.App.Role;

namespace Data.Repositories.App.Role
{
    public class StudentRepository : IStudentRepository
    {

        private static StudentRepository? studentRepository = null;
        private StudentRepository() { }
        public static StudentRepository GetRepository()
        {
            return studentRepository ??= new StudentRepository();
        }
        public string Add(string login, string password, string name, string surname, string patronymic, DateTime dateOfBirth, Sex sex, StudentGroup studentGroup)
        {
            string result = "Already exist";

            using (ApplicationDbContext db = new ApplicationDbContext ())
            {
                //Check if student already exists
                bool checkIfExist = db.Students.Any(el => el.Login == login);

                if (!checkIfExist) 
                {
                    Student newStudent = new()
                    {
                        Login = login,
                        Password = password,
                        FirstName = name,
                        SecondName = surname,
                        PatronymicName = patronymic,
                        DateOfBirth = dateOfBirth,
                        Sex = sex,
                        StudentGroup = studentGroup
                    };

                    db.Students.Add(newStudent);
                    db.SaveChanges();
                    result = "Done";
                }
                
            }
            return result;
        }

        public string Delete(Student student)
        {
            string result = "This student doesn't exist";

            using (ApplicationDbContext db = new())
            {
                db.Students.Remove(student);
                db.SaveChanges();
                result = "Done. Student: " + student.FirstName + "" + student.SecondName + " has been removed";
            }
            return result;
        }

        public static List<Student> GetAll()
        {
            using ApplicationDbContext dbContext = new ApplicationDbContext();
            var result = dbContext.Students.ToList();
            return result;
        }

        public string Update(Student oldStudent, string login, string password, string name, string surname, string patronymic, DateTime dateOfBirth, Sex sex, StudentGroup studentGroup)
        {
            string result = "This student doesn't exist";

            using (ApplicationDbContext db = new())
            {
                Student student = db.Students.FirstOrDefault(el => el.ID == oldStudent.ID);

                student.FirstName = name;
                student.SecondName = surname;
                student.StudentGroup = studentGroup;
                student.Login = login;
                student.Password = password;
                student.PatronymicName = patronymic;
                student.Sex = sex;
                student.DateOfBirth = dateOfBirth;
                    
                db.SaveChanges();
                result = "Done. Student " + student.FirstName + " " + student.SecondName + "hasbeen changed";
            }
            return result;
        }
    }
}
