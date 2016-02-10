namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitarySystem.Models;

    public interface IVehiclesService
    {
        IQueryable GetAll(int skip, int take);

        Vehicle GetById(int id);

        int Add(Vehicle vehicles);

        int Delete(int id);

        int Update(Vehicle vehicle);
    }
}
