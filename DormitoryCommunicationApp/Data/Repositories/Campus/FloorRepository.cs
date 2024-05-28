using System.Net;
using System.Xml.Linq;
using Data.Repositories.App.Role;
using Domain.Entities.Campus;
using Domain.Entities.SideInformation;
using Domain.Repositories.Campus;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Data.Repositories.Campus
{
    public class FloorRepository : IFloorRepository
    {
        public string Add(Floor floor)
        {
            //string result = "Already exist";

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //Check if student already exists
                //bool checkIfExist = db.Dormitories.Any(el => el.ID == floor.ID);

                var existingFloor = db.Floors.FirstOrDefault(r => r.Number == floor.Number && r.Dormitory == floor.Dormitory);
                if (existingFloor != null)
                {
                    return "Room already exists";
                }
                db.Floors.Add(floor);
                db.SaveChanges();
                return "Done";
                /*                if (!checkIfExist)
                                {
                                    db.Floors.Add(floor);
                                    db.SaveChanges();
                                    result = "Done";
                                }
                            }
                return result;*/
            }
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

        public List<Floor> GetAll()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var result = dbContext.Floors.ToList();
                return result;
            }
        }

        public string GetStudentBYRoomNumber(int roomNumber)
        {
            throw new NotImplementedException();
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




