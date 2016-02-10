namespace MilitarySystem.Services
{
    using System;
    using System.Linq;

    using Models;
    using MilitarySystem.Services.Contracts;
    using Data.Contracts;

    public class MissionsService : IMissionsService
    {
        private readonly IRepository<Mission> missions;

        public MissionsService(IRepository<Mission> missions)
        {
            this.missions = missions;
        }

        public int Add(Mission mission)
        {
            this.missions.Add(mission);

            return this.missions.SaveChanges();
        }

        public int Delete(int id)
        {
            this.missions.Delete(id);

            return this.missions.SaveChanges();
        }

        public IQueryable GetAll(int skip, int take)
        {
            return this.missions
                .All()
                .Skip(skip)
                .Take(take);
        }

        public Mission GetById(int id)
        {
            return this.missions.GetById(id);
        }

        public int Update(Mission mission)
        {
            this.missions.Update(mission);

            return this.missions.SaveChanges();
        }
    }
}
