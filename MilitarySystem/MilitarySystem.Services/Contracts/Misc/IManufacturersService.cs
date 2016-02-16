namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitarySystem.Models;

    public interface IManufacturersService
    {
        IQueryable<Manufacturer> GetAll();

        Manufacturer GetById(int id);

        int Add(Manufacturer manufacturer);

        int Delete(int id);

        int Update(Manufacturer manufacturer);
    }
}
