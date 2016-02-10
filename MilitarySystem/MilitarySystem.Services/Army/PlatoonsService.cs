namespace MilitarySystem.Services
{
    using System;
    using System.Linq;

    using MilitarySystem.Services.Contracts;
    using Models;
    using Data.Contracts;

    public class PlatoonsService : IPlatoonsService
    {
        private readonly IRepository<Platoon> platoons;

        public PlatoonsService(IRepository<Platoon> platoons)
        {
            this.platoons = platoons;
        }

        public int Add(Platoon platoon)
        {
            this.platoons.Add(platoon);

            return this.platoons.SaveChanges();
        }

        public int Delete(int id)
        {
            this.platoons.Delete(id);

            return this.platoons.SaveChanges();
        }

        public IQueryable GetAll(int skip, int take)
        {
            return this.platoons
                .All()
                .Skip(skip)
                .Take(take);
        }

        public Platoon GetById(int id)
        {
            return this.platoons.GetById(id);
        }

        public int Update(Platoon platoon)
        {
            this.platoons.Update(platoon);

            return this.platoons.SaveChanges();
        }
    }
}
