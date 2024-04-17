
using Microsoft.EntityFrameworkCore;
using Domain.Entities.App.Role;
using Domain.Entities.Campus;
using Domain.Entities.Model;
using Domain.Entities.SideInformation;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {


        static void Main()
        {

        }

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }



        //Изменить под свой PostgresSQL сервер
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=DormitoryDatabase; Username=postgres; Password=3791");

        }





        public DbSet<Address>Addresses { get; set; }    
        public DbSet<Student> Students { get; set; }

        public DbSet<Building> Dormitories { get; set; }   

        public DbSet<Floor> Floors { get; set; }    

        public DbSet<Room> Rooms { get; set; }

        public DbSet<StudentAccomodation> StudentAccomodations { get; set; }




        //Not.data not.date not.

    }

}




