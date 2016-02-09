namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitartySystem.Models;

    public interface IManufacturesService
    {
        IQueryable GetAll();

        Manufacturer GetById(int id);

        int Add(Manufacturer manufacturer);

        int Delete(int id);

        int Update(Manufacturer manufacturer);
    }
}
