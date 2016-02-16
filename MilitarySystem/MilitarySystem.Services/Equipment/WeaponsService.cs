namespace MilitarySystem.Services
{
    using System;
    using System.Linq;

    using Models;
    using MilitarySystem.Services.Contracts;
    using Data.Contracts;

    public class WeaponsService : IWeaponsService
    {
        private readonly IRepository<Weapon> weapons;

        public WeaponsService(IRepository<Weapon> weapons)
        {
            this.weapons = weapons;
        }

        public int Add(Weapon weapon)
        {
            this.weapons.Add(weapon);

            return this.weapons.SaveChanges();
        }

        public int Delete(int id)
        {
            this.weapons.Delete(id);

            return this.weapons.SaveChanges();
        }

        public IQueryable<Weapon> GetAll()
        {
            return this.weapons.All();
        }

        public Weapon GetById(int id)
        {
            return this.weapons.GetById(id);
        }

        public int Update(Weapon weapon)
        {
            this.weapons.Update(weapon);

            return this.weapons.SaveChanges();
        }
    }
}
