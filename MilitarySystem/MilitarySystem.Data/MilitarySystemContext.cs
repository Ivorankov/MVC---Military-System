namespace MilitarySystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Microsoft.AspNet.Identity.EntityFramework;

    using MilitarySystem.Models;
    using MilitarySystem.Data.Contracts;


    public class MilitarySystemContext : IdentityDbContext<User>, IMilitarySystemContext
    {
        public MilitarySystemContext()
            : base("MilitarySystemDb")
        {

        }

        public IDbSet<Gear> Gear { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<Mission> Missions { get; set; }

        public IDbSet<Platoon> Platoons { get; set; }

        public IDbSet<Squad> Squads { get; set; }

        public IDbSet<Vehicle> Vehicles { get; set; }

        public IDbSet<Weapon> Weapons { get; set; }

        public static MilitarySystemContext Create()
        {
            return new MilitarySystemContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
