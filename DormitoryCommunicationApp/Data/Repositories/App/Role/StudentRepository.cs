
using Domain.Entities.App.Role;
using Domain.Entities.Campus;
using Domain.Entities.People.Attribute;
using Domain.Entities.SideInformation;
using Domain.Repositories.App.Role;
using System.Xml.Linq;

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



        public Boolean Add(string login, string password, string name, string surname, string patronymic,
                          int contactNumber, DateTime dateOfBirth, Sex sex, StudentGroup studentGroup)
        {
            using (var db = new ApplicationDbContext())
            {
                bool checkIfExist = db.Students.Any(el => el.Login == login);

                if (checkIfExist) return false;


                    var newStudent = new Student
                {
                    Login = login,
                    Password = password,
                    FirstName = name,
                    SecondName = surname,
                    PatronymicName = patronymic,
                    ContactNumber = contactNumber,
                    DateOfBirth = dateOfBirth,
                    Sex = sex,
                    StudentGroup = studentGroup
                };

                db.Students.Add(newStudent);
                db.SaveChanges();
                return true;
            }
        }

        public Boolean Add(Student newStudent)
        {
            using (var db = new ApplicationDbContext())
            {
                bool checkIfExist = db.Students.Any(el => el.Login == newStudent.Login);
                if (checkIfExist)
                {
                    return false;
                }

                db.Students.Add(newStudent);
                db.SaveChanges();
                return true;
            }
        }

        public string Delete(Student student)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Students.Remove(student);
                db.SaveChanges();
                return $"Done. Student: {student.FirstName} {student.SecondName} has been removed";
            }
        }

        public List<Student> GetAll()
        {
            //using var dbContext = new ApplicationDbContext();
            //return dbContext.Students.ToList();

            using(var db = new ApplicationDbContext()){
                return db.Students.ToList();

            }
        }
/*        public List<Student> GetAll()
        {
            return null;
*//*            List<Student> allStudents = new List<Student>();
            using (var dbContext = new ApplicationDbContext())
            {
                foreach (var student in dbContext.Students)
                {
                    allStudents.Add(student);
                }
            }
            return allStudents;*//*
        }*/

        public string Update(Student oldStudent, string login, string password, string name, string surname,
                             string patronymic, Sex sex, StudentGroup studentGroup)
        {
            using (var db = new ApplicationDbContext())
            {
                var student = db.Students.FirstOrDefault(el => el.Login == oldStudent.Login);
                if (student == null)
                    return "This student doesn't exist";

                student.FirstName = name;
                student.SecondName = surname;
                student.StudentGroup = studentGroup;
                student.Login = login;
                student.Password = password;
                student.PatronymicName = patronymic;
                student.Sex = sex;

                db.SaveChanges();
                return $"Done. Student {student.FirstName} {student.SecondName} has been changed";
            }
        }

        public List<Student> Find(string name, string surname, string patronymic)
        {
            using (ApplicationDbContext db = new())
            {
                var students = db.Students.Where(el => name.Equals(el.FirstName)
                && surname.Equals(el.SecondName) && patronymic.Equals(el.PatronymicName)).ToList();
                return students;
            }
        }

        public List<Student> Find(string surname)
        {
            using (ApplicationDbContext db = new())
            {
                var students = db.Students.Where(el => surname.Equals(el.SecondName)).ToList();
                return students;
            }
        }

        //returns success or fail
        public Boolean CheckIn(Student student, Room room)
        {
            using (ApplicationDbContext db = new())
            {
                room.Students.Add(student);
                if (db.Rooms.Update(room) != null)
                {
                    db.SaveChanges();
                    return true;
                }
                Console.WriteLine("Room not found");
            }
            return false;
        }
        
        //returns success or fail
        public Boolean CheckOut(Student student, Room room)
        {
            using (ApplicationDbContext db = new())
            {
                if (room.Students.Contains(student))
                {
                    room.Students.Remove(student);
                }
                else
                {
                    Console.WriteLine("No such student in this room!");
                    return false;
                }

                if (db.Rooms.Update(room) != null)
                {
                    db.SaveChanges();
                    return true;
                }
                Console.WriteLine("Room not found");
            }
            return false;
        }
        
        //returns success or fail
        public Boolean SwapStudents(Student student1, Student student2)
        {          
            using (ApplicationDbContext db = new())
            {
                if (student1.Room == null)
                {
                    Console.WriteLine("Student:" + student1 + "does not have a room");
                    return false;
                }
                if (student2.Room == null)
                {
                    Console.WriteLine("Student:" + student2 + "does not have a room");
                    return false;
                }
                var tempRoom = student1.Room;
                student1.Room = student2.Room;
                student2.Room = tempRoom;

                db.SaveChanges();
                return true;
            }
        }
        


    }
}
