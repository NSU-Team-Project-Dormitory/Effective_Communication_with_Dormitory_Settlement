
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

namespace Data
{
    
    public class ApplicationDbContext : DbContext
    {
        private IStudentRepository _studentRepository;


        public ApplicationDbContext() 
        {
            _studentRepository = StudentRepository.GetRepository();
            Database.EnsureCreated();
        }

        static void Main()
        {
            Console.WriteLine("123");
            ApplicationDbContext appContext = new ApplicationDbContext();

            List<Student> students = appContext._studentRepository.GetAll();
            Console.WriteLine();
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




