
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Entities.App.Role;
using System.Security.Cryptography.X509Certificates;
using Domain.Entities.Campus;
using Domain.Entities.People;
using Domain.Entities.Model;
using Domain.Entities.SideInformation;
using Domain.Repositories.App.Role;

using Data.Repositories.App.Role;
using Domain.Entities.People.Attribute;
using Domain.Repositories.SideInformation;
using Data.Repositories.SideInformation;
using Domain.Repositories.Campus;
using Data.Repositories.Campus;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data
{
    
    public class ApplicationDbContext : DbContext
    {
        private IStudentRepository _studentRepository;
        private IAddressRepoisitory _addressRepoisitory;


        public ApplicationDbContext() 
        {
            //Database.EnsureDeleted();

            Database.EnsureCreated();
            _studentRepository = StudentRepository.GetRepository();
            _addressRepoisitory = AddressRepository.GetRepository();

        }

        static void Main()
        {
            ApplicationDbContext appContext = new ApplicationDbContext();

            /*
            Console.WriteLine("123");
            ApplicationDbContext appContext = new ApplicationDbContext();

            //Student student = new Student("Login", "pass", "Name" , "Surname", "Patr", new Address("Street","City","No, thank you", "696969", "Mars"),DateTime.UtcNow, Domain.Entities.People.Attribute.Sex.Male,1337, new StudentGroup(777, "VIP"));
            //appContext._studentRepository.Add(student);

            //appContext._studentRepository.Add(1, "Login", "pass", "Name", "Surname", "Patr", 123, DateTime.UtcNow, Domain.Entities.People.Attribute.Sex.Male   , new StudentGroup(7777, "VIP"));
            List<Student> students = appContext._studentRepository.GetAll();

            Console.ReadLine();
            */
            // Example usage of functions from StudentRepository

            // Create a new student repository instance
            //var studentRepository = StudentRepository.GetRepository();

            // Example of adding a new student using the overloaded Add method
            var address = new Address("Street", "City", "No, thank you", "696969", "Mars");
            //appContext._addressRepoisitory.Add(address);

            var newStudent = new Student
            {
                Login = "john.doe",
                Password = "password",
                FirstName = "John",
                SecondName = "Doe",
                PatronymicName = "Smith",
                ContactNumber = 1234567890,
                DateOfBirth = DateTime.UtcNow,
                Address = address,
                Sex = Sex.Male,
                StudentGroup = new StudentGroup(1, "YES")
            };
            var newStudent2 = new Student
            {
                Login = "john.doe2",
                Password = "password2",
                FirstName = "John2",
                SecondName = "Doe2",
                PatronymicName = "Smith2",
                ContactNumber = 1234567890,
                DateOfBirth = DateTime.UtcNow,
                Sex = Sex.Male,
                StudentGroup = new StudentGroup(12,"YES2")
            };
            var newStudent3 = new Student
            {
                Login = "john.doe3",
                Password = "password3",
                FirstName = "John3",
                SecondName = "Doe3",
                PatronymicName = "Smith3",
                ContactNumber = 1234567890,
                DateOfBirth = DateTime.UtcNow,
                Sex = Sex.Male,
                StudentGroup = new StudentGroup(13,"YES3")
            };

            // Add the new student
            bool isAdded = appContext._studentRepository.Add(newStudent);
            appContext._studentRepository.Add(newStudent2);
            appContext._studentRepository.Add(newStudent3);
            if (isAdded)
            {
                Console.WriteLine("Student added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add student. Student already exists.");
            }

            
            // Example of retrieving all students
            var allStudents = appContext._studentRepository.GetAll();
            foreach (var student in allStudents)
            {
                Console.WriteLine($"Student ID: {student.ID}, Name: {student.FirstName} {student.SecondName}");
            }

            

            // Example of deleting a student
            // Assuming studentToDelete is an existing Student object
            
            //var deleteResult = appContext._studentRepository.Delete(newStudent2);
            //Console.WriteLine(deleteResult);

            // Example of updating a student
            // Assuming studentToUpdate is an existing Student object
            var updateResult = appContext._studentRepository.Update(newStudent3, "newlogin", "newpassword", "New", "Name", "NewPatronymic", Sex.Female, new StudentGroup(14, "YES4"));
            Console.WriteLine(updateResult);

            // Example of finding students by name
            var foundStudents = appContext._studentRepository.Find("John", "Doe", "Smith");
            foreach (var foundStudent in foundStudents)
            {
                Console.WriteLine($"Found Student: {foundStudent.FirstName} {foundStudent.SecondName}");
            }

            // Example of retrieving all students
            var allStudents2 = appContext._studentRepository.GetAll();
            foreach (var student in allStudents2)
            {
                Console.WriteLine($"Student ID: {student.ID}, Name: {student.FirstName} {student.SecondName}");
            }



            /*
            // Example of checking in a student to a room
            // Assuming studentToCheckIn and roomToCheckIn are existing Student and Room objects
            bool checkInResult = studentRepository.CheckIn(studentToCheckIn, roomToCheckIn);
            Console.WriteLine($"Check-in result: {checkInResult}");

            // Example of checking out a student from a room
            // Assuming studentToCheckOut and roomToCheckOut are existing Student and Room objects
            bool checkOutResult = studentRepository.CheckOut(studentToCheckOut, roomToCheckOut);
            Console.WriteLine($"Check-out result: {checkOutResult}");

            // Example of swapping two students
            // Assuming student1 and student2 are existing Student objects
            bool swapResult = studentRepository.SwapStudents(student1, student2);
            Console.WriteLine($"Swap result: {swapResult}");
            */
        }
   


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=DormitoryDatabase; Username=postgres; Password=1234");
        }


        public DbSet<Address>Addresses { get; set; }    
        public DbSet<Student> Students { get; set; }

        public DbSet<Building> Dormitories { get; set; }   

        public DbSet<Floor> Floors { get; set; }    

        public DbSet<Room> Rooms { get; set; }

        public DbSet<StudentAccomodation> StudentAccomodations { get; set; }

    }

}




