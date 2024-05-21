
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

            var address = new Address("street", "number", "city", "region", "postal code", "country", 1);
            //appContext._addressRepoisitory.Add(address);
            var tempRoom = new Room("1", 1,1);

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
                Sex = "Male",
                Room = tempRoom,
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
                Sex = "Male",
                Room = tempRoom,
                StudentGroup = new StudentGroup(12, "YES2")
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
                Sex = "Male",
                Room = tempRoom,
                StudentGroup = new StudentGroup(13, "YES3")
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




            //var deleteResult = appContext._studentRepository.Delete(newStudent2);
            //Console.WriteLine(deleteResult);

            var updateResult = appContext._studentRepository.Update(newStudent3, "newlogin", "newpassword", "New", "Name", "NewPatronymic", "Female", new StudentGroup(14, "YES4"));
            Console.WriteLine(updateResult);

            var foundStudents = appContext._studentRepository.Find("John", "Doe", "Smith");
            foreach (var foundStudent in foundStudents)
            {
                Console.WriteLine($"Found Student: {foundStudent.FirstName} {foundStudent.SecondName}");
            }

            var allStudents2 = appContext._studentRepository.GetAll();
            foreach (var student in allStudents2)
            {
                Console.WriteLine($"Student ID: {student.ID}, Name: {student.FirstName} {student.SecondName}");
            }
            



            /*
            bool checkInResult = studentRepository.CheckIn(studentToCheckIn, roomToCheckIn);
            Console.WriteLine($"Check-in result: {checkInResult}");

            bool checkOutResult = studentRepository.CheckOut(studentToCheckOut, roomToCheckOut);
            Console.WriteLine($"Check-out result: {checkOutResult}");

            bool swapResult = studentRepository.SwapStudents(student1, student2);
            Console.WriteLine($"Swap result: {swapResult}");
            */
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=DormitoryDatabase; Username=postgres; Password=1234");
        }


        public DbSet<Address> Addresses { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Building> Dormitories { get; set; }

        public DbSet<Floor> Floors { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<StudentAccomodation> StudentAccomodations { get; set; }

    }

}



