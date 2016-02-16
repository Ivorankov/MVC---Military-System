namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitarySystem.Models;

    public interface IWeaponsService
    {
        IQueryable<Weapon> GetAll();

        Weapon GetById(int id);

        int Add(Weapon weapon);

        int Delete(int id);

        int Update(Weapon weapon);
    }
}
