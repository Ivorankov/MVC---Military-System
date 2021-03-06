﻿namespace MilitarySystem.Services
{
    using System;
    using System.Linq;

    using Models;
    using MilitarySystem.Services.Contracts;
    using Data.Contracts;

    public class GearService : IGearService
    {
        private readonly IRepository<Gear> gear;

        public GearService(IRepository<Gear> gear)
        {
            this.gear = gear;
        }

        public int Add(Gear gear)
        {
            this.gear.Add(gear);

            return this.gear.SaveChanges();
        }

        public int Delete(Gear id)
        {
            this.gear.Delete(id);

            return this.gear.SaveChanges();
        }

        public IQueryable<Gear> GetAll()
        {
            return this.gear.All();
        }

        public Gear GetById(object id)
        {
            return this.gear.GetById(id);
        }

        public int Update(Gear gear)
        {
            this.gear.Update(gear);

            return this.gear.SaveChanges();
        }
    }
}
