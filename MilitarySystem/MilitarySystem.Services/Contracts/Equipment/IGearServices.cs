namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitartySystem.Models;

    public interface IGearServices
    {
        IQueryable GetAll();

        Gear GetById(int id);

        int Add(Gear gear);

        int Delete(int id);

        int Update(Gear gear);
    }
}
