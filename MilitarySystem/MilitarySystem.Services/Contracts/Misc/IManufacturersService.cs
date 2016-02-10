namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitarySystem.Models;

    public interface IManufacturersService
    {
        IQueryable GetAll(int skip, int take);

        Manufacturer GetById(int id);

        int Add(Manufacturer manufacturer);

        int Delete(int id);

        int Update(Manufacturer manufacturer);
    }
}
