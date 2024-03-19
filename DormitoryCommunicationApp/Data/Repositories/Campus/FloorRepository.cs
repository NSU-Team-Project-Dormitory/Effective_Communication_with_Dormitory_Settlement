using System.Net;
using System.Xml.Linq;
using Domain.Entities.Campus;
using Domain.Entities.SideInformation;
using Domain.Repositories.Campus;


namespace Data.Repositories.Campus
{
    public class FloorRepository : IFloorRepository
    {
        public string Add(Floor floor)
        {
            string result = "Already exist";

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //Check if student already exists
                bool checkIfExist = db.Dormitories.Any(el => el.ID == floor.ID);

                //Вопрос, является ли это плохой практикой, что если будет здание, а не репозиторий? Нужен ли guid, для того чтобы отличать общежития с одним именем, но разным адресом например?

                if (!checkIfExist)
                {
                    db.Floors.Add(floor);
                    db.SaveChanges();
                    result = "Done";
                }
            }
            return result;
        }

        public string Delete(Floor floor)
        {
            string result = "This floor doesn't exist";

            using (ApplicationDbContext db = new())
            {
                db.Floors.Remove(floor);
                db.SaveChanges();
                result = "Done. Floor: " + floor.ID + " has been removed";
            }
            return result;
        }

        public static List<Floor> GetAll()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var result = dbContext.Floors.ToList();
                return result;
            }
        }

        public string Update(Floor floor, string newNumber, int newHeight, Building newBuilding)
        {
            string result = "This floor doesn't exist";

            using (ApplicationDbContext db = new())
            {
                Floor newFloor = db.Floors.FirstOrDefault(el => el.ID == floor.ID);

                newFloor.Number = newNumber;
                newFloor.Height = newHeight;
                newFloor.Dormitory = newBuilding;


                db.SaveChanges();
                result = "Done. Floor " + floor.Number + " has been changed";
            }
            return result;
        }
    }
}
