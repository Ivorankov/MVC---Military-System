namespace MilitarySystem.Services
{
    using System;
    using System.Linq;

    using Models;
    using MilitarySystem.Services.Contracts;
    using Data.Contracts;

    public class VehiclesService : IVehiclesService
    {
        private readonly IRepository<Vehicle> vehicles;

        public VehiclesService(IRepository<Vehicle> vehicles)
        {
            this.vehicles = vehicles;
        }

        public int Add(Vehicle vehicles)
        {
            this.vehicles.Add(vehicles);

            return this.vehicles.SaveChanges();
        }

        public int Delete(object id)
        {
            this.vehicles.Delete(id);

            return this.vehicles.SaveChanges();
        }

        public IQueryable<Vehicle> GetAll()
        {
            return this.vehicles.All();
        }

        public Vehicle GetById(int id)
        {
            return this.vehicles.GetById(id);
        }

        public int Update(Vehicle vehicle)
        {
            this.vehicles.Update(vehicle);

            return this.vehicles.SaveChanges();
        }
    }
}
