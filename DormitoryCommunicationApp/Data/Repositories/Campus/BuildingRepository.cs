using System.Linq;
using Domain.Entities.Campus;
using Domain.Entities.SideInformation;
using Domain.Repositories.Campus;
using Microsoft.EntityFrameworkCore;

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
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // Check if building already exists
                var existingBuilding = db.Dormitories.FirstOrDefault(b => b.Name == building.Name);
                if (existingBuilding != null)
                {
                    return "Building already exists";
                }

                try
                {
                    db.Dormitories.Add(building);
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // Log exception details or rethrow with more information
                    throw new Exception($"An error occurred while adding the building: {ex.Message}", ex);
                }

                return "Done";
            }
        }

        public string Delete(Building building)
        {
            using (ApplicationDbContext db = new())
            {
                var existingBuilding = db.Dormitories.FirstOrDefault(b => b.ID == building.ID);
                if (existingBuilding == null)
                {
                    return "This building doesn't exist";
                }

                try
                {
                    db.Dormitories.Remove(existingBuilding);
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // Log exception details or rethrow with more information
                    throw new Exception($"An error occurred while deleting the building: {ex.Message}", ex);
                }

                return $"Done. Building: {building.Name} has been removed";
            }
        }

        public string Update(Building oldBuilding, string name, Address address, Contact contact, int floorsCount)
        {
            using (ApplicationDbContext db = new())
            {
                var building = db.Dormitories.FirstOrDefault(b => b.ID == oldBuilding.ID);
                if (building == null)
                {
                    return "This building doesn't exist";
                }

                try
                {
                    building.Name = name;
                    building.Address = address;
                    building.Contact = contact;
                    building.FloorsCount = floorsCount;

                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // Log exception details or rethrow with more information
                    throw new Exception($"An error occurred while updating the building: {ex.Message}", ex);
                }

                return $"Done. Building {oldBuilding.Name} has been changed";
            }
        }

        public List<Building> GetAll()
        {
            using (ApplicationDbContext dbContext = new())
            {
                return dbContext.Dormitories.ToList();
            }
        }
    }
}
