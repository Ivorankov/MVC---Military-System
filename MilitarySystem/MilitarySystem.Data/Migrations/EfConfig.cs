namespace MilitarySystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using Common;

    public class EfConfig : DbMigrationsConfiguration<MilitarySystemContext>
    {
        public EfConfig()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        public void SeedDb(MilitarySystemContext context)
        {
            if (!context.Users.Any())
            {
                SeedUsers(context);
            }

            if (!context.Manufacturers.Any())
            {
                SeedVehicles(context);
            }

            if (!context.Squads.Any())
            {
                SeedSquads(context);
                SeedMissions(context);
                SeedSoldiersInSquads(context);
                SeedMessagesInSquads(context);
                SeedVehiclesInSquads(context);
            }

            if (!context.Platoons.Any())
            {
                SeedPlatoons(context);
                SeedSquadsInPlatoons(context);
            }
        }

        private void SeedVehiclesInSquads(MilitarySystemContext context)
        {
            var squad = context.Squads.First();
            var vehciles = context.Vehicles.OrderBy(x => x.Price).Take(5).ToList();
            foreach (var item in vehciles)
            {
                squad.Vehicles.Add(item);
            }

            context.SaveChanges();
        }

        private void SeedUsers(MilitarySystemContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            if (!context.Roles.Any(r => r.Name == ModelsConstraints.SquadLeaderRoleName))
            {
                var roleAdmin = new IdentityRole
                {
                    Name = ModelsConstraints.SquadLeaderRoleName
                };

                manager.Create(roleAdmin);
            }

            if (!context.Roles.Any(r => r.Name == ModelsConstraints.PlatoonLeaderRoleName))
            {
                var roleAdmin = new IdentityRole
                {
                    Name = ModelsConstraints.PlatoonLeaderRoleName
                };

                manager.Create(roleAdmin);
            }

            if (!context.Roles.Any(r => r.Name == ModelsConstraints.AdminRoleName))
            {
                var roleAdmin = new IdentityRole
                {
                    Name = ModelsConstraints.AdminRoleName
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
            userManager.AddToRole(adminUser.Id, ModelsConstraints.AdminRoleName);

            var squadLeader = new User()
            {
                UserName = "Robin",
                FirstName = "Robin",
                LastName = "Tillson",
                Email = "Robin@system.death",
                Rank = 2,
                ImgUrl = "http://www.download-free-wallpaper.com/img86/pwhcwpombrjbpnuotuza.png",
                EnrollmentDate = DateTime.UtcNow
            };


            userManager.Create(squadLeader, "asdasd");
            userManager.AddToRole(squadLeader.Id, ModelsConstraints.SquadLeaderRoleName);

            var squadMemeber1 = new User()
            {
                UserName = "Derrik",
                Email = "Derrik@system.death",
                FirstName = "Derrik",
                LastName = "Johnson",
                Rank = 1,
                ImgUrl = "http://www.download-free-wallpaper.com/img86/pwhcwpombrjbpnuotuza.png",
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
                ImgUrl = "http://www.download-free-wallpaper.com/img86/pwhcwpombrjbpnuotuza.png",
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
                ImgUrl = "http://www.download-free-wallpaper.com/img86/pwhcwpombrjbpnuotuza.png",
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
                ImgUrl = "http://www.download-free-wallpaper.com/img86/pwhcwpombrjbpnuotuza.png",
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
                ImgUrl = "http://images.techtimes.com/data/images/full/4131/army-soldier.jpg?w=600",
                EnrollmentDate = DateTime.UtcNow
            };

            userManager.Create(plattonLeader, "asdasd");
            userManager.AddToRole(plattonLeader.Id, ModelsConstraints.PlatoonLeaderRoleName);
        }

        private void SeedVehicles(MilitarySystemContext context)
        {
            var manufacturer = new Manufacturer() { Name = "D&D" };
            var manufacturer2 = new Manufacturer() { Name = "ZTech" };
            var manufacturer3 = new Manufacturer() { Name = "AlphaOrigin" };
            var manufacturer4 = new Manufacturer() { Name = "GearsRUs" };
            var vehicle1 = new Vehicle() { Manufacturer = manufacturer, Price = 87000M, Model = "Raptor" };
            var vehicle2 = new Vehicle() { Manufacturer = manufacturer, Price = 37000.547M, Model = "Thunder" };
            var vehicle3 = new Vehicle() { Manufacturer = manufacturer, Price = 18200M, Model = "Spiral" };
            var vehicle4 = new Vehicle() { Manufacturer = manufacturer, Price = 687000M, Model = "Destoryer" };
            var vehicle5 = new Vehicle() { Manufacturer = manufacturer, Price = 27000000.99M, Model = "F32" };

            context.Manufacturers.Add(manufacturer);
            context.Manufacturers.Add(manufacturer2);
            context.Manufacturers.Add(manufacturer3);
            context.Manufacturers.Add(manufacturer4);
            context.Vehicles.Add(vehicle1);
            context.Vehicles.Add(vehicle2);
            context.Vehicles.Add(vehicle3);
            context.Vehicles.Add(vehicle4);
            context.Vehicles.Add(vehicle5);

            context.SaveChanges();
        }

        private void SeedSquads(MilitarySystemContext context)
        {
            var squad1 = new Squad() { Name = "Alpha", ImgUrl = "http://emblemsbf.com/img/30268.jpg" };
            var squad2 = new Squad() { Name = "Bravo", ImgUrl = "http://orig07.deviantart.net/e530/f/2007/120/c/f/bravo_team_logo_by_benjo_kun.jpg" };
            var squad3 = new Squad() { Name = "Charlie", ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/6/6b/ArmyWestPointAthenaShield.png" };
            var squad4 = new Squad() { Name = "Delta", ImgUrl = "http://www.groundzeroairsoft.com/nae/booking/images/delta_team_logo.png" };

            context.Squads.Add(squad1);
            context.Squads.Add(squad2);
            context.Squads.Add(squad3);
            context.Squads.Add(squad4);

            context.SaveChanges();
        }

        private void SeedPlatoons(MilitarySystemContext context)
        {
            var platoon1 = new Platoon() { Name = "Delta Force", ImgUrl = "http://i629.photobucket.com/albums/uu17/rj_castro/Delta-Force-1-256x256.png" };
            var platoon2 = new Platoon() { Name = "Seals", ImgUrl = "http://patriotden.com/fotki/usnavy/USN-SEALS.png" };
            var platoon3 = new Platoon() { Name = "Barrets", ImgUrl = "http://drrichswier.com/wp-content/uploads/green-beret-logo.jpg" };
            var platoon4 = new Platoon() { Name = "Spetsnaz", ImgUrl = "http://img1.goodfon.su/wallpaper/big/6/4c/specnaz-simvol-vv-mvd-deviz.jpg" };

            context.Platoons.Add(platoon1);
            context.Platoons.Add(platoon2);
            context.Platoons.Add(platoon3);
            context.Platoons.Add(platoon4);

            context.SaveChanges();
        }

        private void SeedMissions(MilitarySystemContext context)
        {
            var mission1 = new Mission() { Info = "Training in the mountains", Lat = -34.397M, Lgn = 150.6442M };
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
                squadLeader.Messages.Add(message);
            }

            context.SaveChanges();
        }

        private void SeedSquadsInPlatoons(MilitarySystemContext context)
        {
            var platoon = context.Platoons.FirstOrDefault();
            var squads = context.Squads;
            foreach (var squad in squads)
            {
                platoon.Squads.Add(squad);
                squad.Platton = platoon;
            }
            platoon.PlatoonCommander = context.Users.First(x => x.FirstName == "John");
            context.SaveChanges();
        }
    }
}
