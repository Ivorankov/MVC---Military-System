﻿namespace MilitarySystem.Services
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

        public int Delete(Platoon id)
        {
            this.platoons.Delete(id);

            return this.platoons.SaveChanges();
        }

        public IQueryable<Platoon> GetAll()
        {
            return this.platoons.All();
        }

        public Platoon GetById(object id)
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
