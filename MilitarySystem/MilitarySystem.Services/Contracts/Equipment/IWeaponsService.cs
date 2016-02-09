namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitartySystem.Models;

    public interface IWeaponsService
    {
        IQueryable GetAll();

        Weapon GetById(int id);

        int Add(Weapon weapon);

        int Delete(int id);

        int Update(Weapon weapon);
    }
}
