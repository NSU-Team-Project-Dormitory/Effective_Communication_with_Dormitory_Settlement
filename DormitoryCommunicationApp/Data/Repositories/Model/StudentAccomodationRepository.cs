
using System.Drawing;
using System.Security.Cryptography;
using Domain.Entities.Campus;
using Domain.Entities.Model;
using Domain.Repositories.Model;

namespace Data.Repositories.Model
{
    internal class StudentAccomodationRepository : IStudentAccomodationRepository
    {
        public string Add(StudentAccomodation studentAccomodation)
        {
            string result = "Already exist";

            using ApplicationDbContext db = new ApplicationDbContext();
            //Check if student already exists
            bool checkIfExist = db.Students.Any(el => el.ID == studentAccomodation.ID);

            if (!checkIfExist)
            {


                db.StudentAccomodations.Add(studentAccomodation);
                db.SaveChanges();
                result = "Done";
            }
            return result;
        }

        public string Delete(StudentAccomodation studentAccomodation)
        {
            string result = "This accomodation note doesn't exist";

            using (ApplicationDbContext db = new())
            {
                db.StudentAccomodations.Remove(studentAccomodation);
                db.SaveChanges();
                result = "Done. Accomodation note: " + studentAccomodation.Contract + " has been removed";
            }
            return result;
        }

        public List<StudentAccomodation> GetAll()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var result = dbContext.StudentAccomodations.ToList();
                return result;
            }
        }

        public string Update(StudentAccomodation oldAccomodation, Building dormitory, Room room, string contract, DateTime startTime, DateTime endDate)
        {
            string result = "This accomodation note doesn't exist";


            using (ApplicationDbContext db = new())
            {
                StudentAccomodation accomodation = db.StudentAccomodations.FirstOrDefault(el => el.ID == oldAccomodation.ID);
                

                accomodation.Dormitory = dormitory;
                accomodation.Room = room;
                accomodation.Contract = contract;
                accomodation.StartDate = startTime;
                accomodation.EndDate = endDate;


                db.SaveChanges();
                result = "Done. Accomodation note: " + accomodation.Contract + " has been updated";
            }
            return result;
        }
    }
}
