using Data;
using Domain.Entities.App.Role;
using Domain.Entities.People.Attribute;
using System.Xml.Linq;
using Domain.Entities.SideInformation;
using Domain.Repositories.SideInformation;
using Domain.Entities.Campus;
using Domain.Entities.Model;
using System.Diagnostics.Contracts;
using Data.Repositories.App.Role;

namespace Data.Repositories.SideInformation
{
    public class AddressRepository : IAddressRepoisitory
    {

        private static AddressRepository? addressRepository = null;
        private AddressRepository() { }
        public static AddressRepository GetRepository()
        {
            return addressRepository ??= new AddressRepository();
        }
        public string Add(Address address)
        {
            string result = "Already exist";

            using ApplicationDbContext db = new();
            //Check if student already exists
            bool checkIfExist = db.Addresses.Any(el => el.ID == address.ID);

            if (!checkIfExist)
            {

                db.Addresses.Add(address);
                db.SaveChanges();
                result = "Done";
            }
            return result;
        }

        public string Delete(Address address)
        {
            string result = "This address doesn't exist";

            using (ApplicationDbContext db = new())
            {
                db.Addresses.Remove(address);
                db.SaveChanges();
                result = "Done. Address: " + address.Country + " " + address.Region + " " + address.City + " has been removed";
            }
            return result;
        }

        public string Get(Address address)
        {
            throw new NotImplementedException();
        }

        public List<Address> GetAll()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var result = dbContext.Addresses.ToList();
                return result;
            }
        }

        public string Update(Address oldAdrress, string street, string city, string region, string postalCode, string country)
        {
            string result = "This address doesn't exist";


            using (ApplicationDbContext db = new())
            {
                Address address = db.Addresses.FirstOrDefault(el => el.ID == oldAdrress.ID);


                address.Street = street;
                address.City = city;
                address.Region = region;
                address.PostalCode = postalCode;
                address.Country = country;



                db.SaveChanges();
                result = "Done. Address: " + address.Country + " " + address.Region + " " + address.City + " has been updated";
            }
            return result;
        }
    }
}


