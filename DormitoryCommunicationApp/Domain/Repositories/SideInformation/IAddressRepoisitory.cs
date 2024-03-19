using Domain.Entities.SideInformation;

namespace Domain.Repositories.SideInformation
{
    public interface IAddressRepoisitory
    {
        public string Add (Address address);

        public string Update(Address oldAdrress, string street, string city, string region ,string postalCode, string country);

        public string Delete (Address address);

        public string Get (Address address);

        public List<Address> GetAll ();
    }
}
