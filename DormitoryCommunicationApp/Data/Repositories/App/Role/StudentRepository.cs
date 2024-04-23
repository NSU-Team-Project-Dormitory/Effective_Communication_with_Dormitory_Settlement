﻿
using Domain.Entities.App.Role;
using Domain.Entities.Campus;
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



        public string Add(string login, string password, string name, string surname, string patronymic, int contactNumber, DateTime dateOfBirth, Sex sex, StudentGroup studentGroup)
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
                        ContactNumber = contactNumber,
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

        public void Add(Student student)
        {
            using (ApplicationDbContext db = new())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
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

        public List<Student> GetAll()
        {
            using ApplicationDbContext dbContext = new ApplicationDbContext();
            List<Student> result = new();
            //var result = dbContext.Students.ToList();
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
                if (student1.Rooms.Count < 1)
                {
                    Console.WriteLine("Student:" + student1 + "does not have a room");
                    return false;
                }
                if (student2.Rooms.Count < 1)
                {
                    Console.WriteLine("Student:" + student2 + "does not have a room");
                    return false;
                }
                student1.Rooms.Add(student2.Rooms[0]);
                student2.Rooms.Add(student1.Rooms[0]);

                student1.Rooms.Remove(student1.Rooms[0]);
                student2.Rooms.Remove(student2.Rooms[0]);


                db.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
