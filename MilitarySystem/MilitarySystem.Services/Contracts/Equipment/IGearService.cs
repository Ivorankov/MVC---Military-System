namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitarySystem.Models;

    public interface IGearService
    {
        IQueryable GetAll();

        Gear GetById(int id);

        int Add(Gear gear);

        int Delete(int id);

        int Update(Gear gear);
    }
}
