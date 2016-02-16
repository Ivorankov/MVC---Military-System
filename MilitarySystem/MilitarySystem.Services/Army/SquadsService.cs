namespace MilitarySystem.Services
{
    using System;
    using System.Linq;
    using Models;

    using MilitarySystem.Services.Contracts;
    using Data.Contracts;

    public class SquadsService : ISquadsService
    {
        private readonly IRepository<Squad> squads;

        public SquadsService(IRepository<Squad> squads)
        {
            this.squads = squads;
        }

        public int Add(Squad squad)
        {
            this.squads.Add(squad);

            return this.squads.SaveChanges();
        }

        public int Delete(int id)
        {
            this.squads.Delete(id);

            return this.squads.SaveChanges();
        }

        public IQueryable<Squad> GetAll()
        {
            return this.squads.All();
        }

        public Squad GetById(int id)
        {
            return this.squads.GetById(id);
        }

        public int Update(Squad squad)
        {
            this.squads.Update(squad);

            return this.squads.SaveChanges();
        }
    }
}
