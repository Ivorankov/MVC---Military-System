namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitartySystem.Models;

    public interface IVehiclesService
    {
        IQueryable GetAll();

        Vehicle GetById(int id);

        int Add(Vehicle vehicles);

        int Delete(int id);

        int Update(Vehicle vehicle);
    }
}
