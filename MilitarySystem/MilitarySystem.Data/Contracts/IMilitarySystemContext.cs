namespace MilitarySystem.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using MilitarySystem.Models;

    public interface IMilitarySystemContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Platoon> Platoons { get; set; }

        IDbSet<Squad> Squads { get; set; }

        IDbSet<Manufacturer> Manufacturers { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<Mission> Missions { get; set; }

        IDbSet<Gear> Gear { get; set; }

        IDbSet<Weapon> Weapons { get; set; }

        IDbSet<Vehicle> Vehicles { get; set; }

        IDbSet<Image> Images { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
