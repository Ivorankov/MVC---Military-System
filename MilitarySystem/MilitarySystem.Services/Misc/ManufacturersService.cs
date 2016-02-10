namespace MilitarySystem.Services
{
    using System;
    using System.Linq;

    using Models;
    using MilitarySystem.Services.Contracts;
    using Data.Contracts;

    public class ManufacturersService : IManufacturersService
    {
        private readonly IRepository<Manufacturer> manufacturers;

        public ManufacturersService(IRepository<Manufacturer> manufacturers)
        {
            this.manufacturers = manufacturers;
        }

        public int Add(Manufacturer manufacturer)
        {
            this.manufacturers.Add(manufacturer);

            return this.manufacturers.SaveChanges();
        }

        public int Delete(int id)
        {
            this.manufacturers.Delete(id);

            return this.manufacturers.SaveChanges();
        }

        public IQueryable GetAll(int skip, int take)
        {
            return this.manufacturers
                    .All()
                    .Skip(skip)
                    .Take(take);
        }

        public Manufacturer GetById(int id)
        {
            return this.manufacturers.GetById(id);
        }

        public int Update(Manufacturer manufacturer)
        {
            this.manufacturers.Update(manufacturer);

            return this.manufacturers.SaveChanges();
        }
    }
}
