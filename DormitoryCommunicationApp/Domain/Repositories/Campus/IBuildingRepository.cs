using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Campus;
using Domain.Entities.SideInformation;

namespace Domain.Repositories.Campus
{
    public interface IBuildingRepository
    {
        public string Add(string name, Address address, Contact contact, int floorsCount);

        public string Update(Building oldbBuilding, string name, Address address, Contact contact, int floorsCount);

        public string Delete(Building building);

        public List<Building> GetAll();

    }

}
        