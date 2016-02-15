namespace MilitarySystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public class EfConfig : DbMigrationsConfiguration<MilitarySystemContext>
    {
        public EfConfig()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MilitarySystemContext context)
        {
            if (context.Users.Any())
            {
                return;
            }
            //Seed users with roles
            SeedUsers(context);
            //Seed vehicles with manufacturers
            SeedVehicles(context);
            //Seed squads
            SeedSquads(context);
            //Seed platoons
            SeedPlatoons(context);
            //Seed missions
            SeedMissions(context);
            SeedSoldiersInSquads(context);
            SeedMessagesInSquads(context);

        }

        private void SeedUsers(MilitarySystemContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            if (!context.Roles.Any(r => r.Name == "SquadLeader"))
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "SquadLeader"
                };

                manager.Create(roleAdmin);
            }

            if (!context.Roles.Any(r => r.Name == "PlatoonLeader"))
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "PlatoonLeader"
                };

                manager.Create(roleAdmin);
            }

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "Admin"
                };

                manager.Create(roleAdmin);
            }

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            var adminUser = new User()
            {
                UserName = "Admin",
                Email = "Admin@system.death",
                FirstName = "Josh",
                LastName = "TJ",
                EnrollmentDate = DateTime.UtcNow
            };

            userManager.Create(adminUser, "2admin1");
            userManager.AddToRole(adminUser.Id, "Admin");

            var squadLeader = new User()
            {
                UserName = "Robin",
                FirstName = "Robin",
                LastName = "Tillson",
                Email = "Robin@system.death",
                Rank = 2,
                EnrollmentDate = DateTime.UtcNow
            };


            userManager.Create(squadLeader, "asdasd");


            var squadMemeber1 = new User()
            {
                UserName = "Derrik",
                Email = "Derrik@system.death",
                FirstName = "Derrik",
                LastName = "Johnson",
                Rank = 1,
                EnrollmentDate = DateTime.UtcNow
            };


            userManager.Create(squadMemeber1, "asdasd");

            var squadMemeber2 = new User()
            {
                UserName = "Tommy",
                Email = "Tommy@system.death",
                FirstName = "Tommy",
                LastName = "Williams",
                Rank = 3,
                EnrollmentDate = DateTime.UtcNow
            };

            userManager.Create(squadMemeber2, "asdasd");

            var squadMemeber3 = new User()
            {
                UserName = "Alfred",
                Email = "Alfred@system.death",
                FirstName = "Alfred",
                LastName = "Garrison",
                Rank = 1,
                EnrollmentDate = DateTime.UtcNow
            };

            userManager.Create(squadMemeber3, "asdasd");

            var squadMemeber4 = new User()
            {
                UserName = "Paul",
                Email = "Paul@system.death",
                FirstName = "Paul",
                LastName = "Gladstone",
                Rank = 2,
                EnrollmentDate = DateTime.UtcNow
            };

            userManager.Create(squadMemeber4, "asdasd");

            //PLATOON LEADERS
            var plattonLeader = new User()
            {
                UserName = "John",
                Email = "John@site.com",
                FirstName = "John",
                LastName = "Tiberian",
                Rank = 3,
                EnrollmentDate = DateTime.UtcNow
            };

            userManager.Create(plattonLeader, "asdasd");
        }

        private void SeedVehicles(MilitarySystemContext context)
        {
            var manufacturer = new Manufacturer() { Name = "D&D" };
            var vehicle1 = new Vehicle() { Manufacturer = manufacturer, Price = 87000M, Model = "Raptor" };
            var vehicle2 = new Vehicle() { Manufacturer = manufacturer, Price = 37000.547M, Model = "Thunder" };
            var vehicle3 = new Vehicle() { Manufacturer = manufacturer, Price = 18200M, Model = "Spiral" };
            var vehicle4 = new Vehicle() { Manufacturer = manufacturer, Price = 687000M, Model = "Destoryer" };
            var vehicle5 = new Vehicle() { Manufacturer = manufacturer, Price = 27000000.99M, Model = "F32" };

            context.Manufacturers.Add(manufacturer);
            context.Vehicles.Add(vehicle1);
            context.Vehicles.Add(vehicle2);
            context.Vehicles.Add(vehicle3);
            context.Vehicles.Add(vehicle4);
            context.Vehicles.Add(vehicle5);

            context.SaveChanges();
        }

        private void SeedSquads(MilitarySystemContext context)
        {
            var squad1 = new Squad() { Name = "Alpha" };
            var squad2 = new Squad() { Name = "Bravo" };
            var squad3 = new Squad() { Name = "Charlie" };
            var squad4 = new Squad() { Name = "Delta" };

            context.Squads.Add(squad1);
            context.Squads.Add(squad2);
            context.Squads.Add(squad3);
            context.Squads.Add(squad4);

            context.SaveChanges();
        }

        private void SeedPlatoons(MilitarySystemContext context)
        {
            var platoon1 = new Platoon() { Name = "Delta Force" };
            var platoon2 = new Platoon() { Name = "Seals" };
            var platoon3 = new Platoon() { Name = "Barrets" };
            var platoon4 = new Platoon() { Name = "Spetsnaz" };

            context.Platoons.Add(platoon1);
            context.Platoons.Add(platoon2);
            context.Platoons.Add(platoon3);
            context.Platoons.Add(platoon4);

            context.SaveChanges();
        }

        private void SeedMissions(MilitarySystemContext context)
        {
            var location = new Location() { Lat = -34.397M, Lgn = 150.6442M };

            var mission1 = new Mission() { Info = "Training in the mountains", TargetLocation = location };
            //var mission2 = new Mission() { Info = "Seals" };
            //var mission3 = new Mission() { Info = "Barrets" };
            //var mission4 = new Mission() { Info = "Spetsnaz" };

            context.Missions.Add(mission1);
            //context.Missions.Add(mission2);
            //context.Missions.Add(mission3);
            //context.Missions.Add(mission4);

            context.SaveChanges();
        }
        private void SeedSoldiersInSquads(MilitarySystemContext context)
        {
            var squad = context.Squads.FirstOrDefault();
            var squadLeader = context.Users.FirstOrDefault(x => x.FirstName == "Derrik");
            squadLeader.Squad = squad;
            var squadMember1 = context.Users.FirstOrDefault(x => x.FirstName == "Robin");
            squadMember1.Squad = squad;
            var squadMember2 = context.Users.FirstOrDefault(x => x.FirstName == "Tommy");
            squadMember2.Squad = squad;
            var squadMember3 = context.Users.FirstOrDefault(x => x.FirstName == "Alfred");
            squadMember3.Squad = squad;
            squad.SquadLeader = squadLeader;
            squad.Soldiers.Add(squadMember1);
            squad.Soldiers.Add(squadMember2);
            squad.Soldiers.Add(squadMember3);

            squad.ActiveMission = context.Missions.FirstOrDefault();
            squad.Messages.Add(context.Messages.FirstOrDefault());
            context.SaveChanges();
        }

        private void SeedMessagesInSquads(MilitarySystemContext context)
        {
            var squad = context.Squads.FirstOrDefault();
            var squadLeader = context.Users.FirstOrDefault(x => x.FirstName == "Derrik");

            for (int i = 0; i < 10; i++)
            {
                var message = new Message() { User = squadLeader, Content = "Field testing " + i };
                squad.Messages.Add(message);
            }

            context.SaveChanges();
        }
    }
}
