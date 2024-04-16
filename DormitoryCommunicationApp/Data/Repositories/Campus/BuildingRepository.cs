
using Data.Repositories.SideInformation;
using Domain.Entities.App.Role;
using Domain.Entities.Campus;
using Domain.Entities.SideInformation;
using Domain.Repositories.Campus;

namespace Data.Repositories.Campus
{
    public class BuildingRepository : IBuildingRepository
    {
        private static BuildingRepository? buildingRepository = null;
        private BuildingRepository() { }
        public static BuildingRepository GetRepository()
        {
            return buildingRepository ??= new BuildingRepository();
        }

        public string Add(Building building)
        {
            string result = "Already exist";

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //Check if student already exists
                bool checkIfExist = db.Dormitories.Any(el => el.Name == building.Name);

                //Вопрос, является ли это плохой практикой, что если будет здание, а не репозиторий? Нужен ли guid, для того чтобы отличать общежития с одним именем, но разным адресом например?

                if (!checkIfExist)
                {
                    
                    db.Dormitories.Add(building);
                    db.SaveChanges();
                    result = "Done";
                }
                return result;
            }
        }

        public string Delete(Building building)
        {
            string result = "This dormitory doesn't exist";

            using (ApplicationDbContext db = new())
            {
                db.Dormitories.Remove(building);
                db.SaveChanges();
                result = "Done. Dormitory: " + building.Name + " has been removed";
            }
            return result;
        }

        public string Update(Building oldbBuilding, string name, Address address, Contact contact, int floorsCount)
        {
            string result = "This dormitory doesn't exist";

            using (ApplicationDbContext db = new())
            {
                Building dormitory = db.Dormitories.FirstOrDefault(el => el.ID == oldbBuilding.ID);

                dormitory.Name = name;
                dormitory.Address = address;
                dormitory.Contact = contact;
                dormitory.FloorsCount = floorsCount;



                db.SaveChanges();
                result = "Done. Dormitory " + dormitory.Name+ " hasbeen changed";
            }
            return result;
        }

        public List<Building> GetAll()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var result = dbContext.Dormitories.ToList();
                return result;
            }
        }



    }
}
