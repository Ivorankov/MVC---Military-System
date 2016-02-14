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
            //Kill if these been a seed
            if (context.Users.Any())
            {
                return;
            }

            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            //Seed roles TODO split Admin into 3 sub roles - Users/ Communication / Weapons/Gear/Vehciles
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

            userManager.PasswordValidator = new MinimumLengthValidator(5);

            //SEED ADMIN USERS

            var adminUser = new User()
            {
                UserName = "Admin",
                Email = "Admin@system.death",
                FirstName = "Josh",
                LastName = "TJ",
                EnrollmentDate = DateTime.UtcNow
            };

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                userManager.Create(adminUser, "2admin1");
                userManager.AddToRole(adminUser.Id, "Admin");
            }

            //SEED SQUADS WITH TEAM MEMEBERS

            var manufacturer = new Manufacturer() { Name = "D&D" };

            var veh = new Vehicle() { Manufacturer = manufacturer, Model = "Raptor", Price = 89000.564M };
            context.SaveChanges();
            var location = new Location() { Lat=-34.397M, Lgn= 150.6442M };
            
            var squad = new Squad()
            {
                Name = "Alpha",
            };

            squad.Vehicles.Add(veh);

            var squadLeader = new User()
            {
                UserName = "Robin",
                FirstName = "Robin",
                LastName = "Tillson",
                Email = "Robin@system.death",
                SquadId = 1,
                EnrollmentDate = DateTime.UtcNow
            };

            if (!context.Users.Any(u => u.UserName == "Robin"))
            {
                userManager.Create(squadLeader, "asdasd");
            }

            var squadMemeber1 = new User()
            {
                UserName = "Derrik",
                Email = "Derrik@system.death",
                FirstName = "Derrik",
                LastName = "Johnson",
                SquadId = 1,
                EnrollmentDate = DateTime.UtcNow
            };

            if (!context.Users.Any(u => u.UserName == "Derrik"))
            {
                userManager.Create(squadMemeber1, "asdasd");
            }

            var squadMemeber2 = new User()
            {
                UserName = "Tommy",
                Email = "Tommy@system.death",
                FirstName = "Tommy",
                LastName = "Williams",
                SquadId = 1,
                EnrollmentDate = DateTime.UtcNow
            };

            if (!context.Users.Any(u => u.UserName == "Tommy"))
            {
                userManager.Create(squadMemeber2, "asdasd");
            }

            var squadMemeber3 = new User()
            {
                UserName = "Alfred",
                Email = "Alfred@system.death",
                FirstName = "Alfred",
                LastName = "Garrison",
                SquadId = 1,
                EnrollmentDate = DateTime.UtcNow
            };

            if (!context.Users.Any(u => u.UserName == "Alfred"))
            {
                userManager.Create(squadMemeber3, "asdasd");
            }

            var squadMemeber4 = new User()
            {
                UserName = "Paul",
                Email = "Paul@system.death",
                FirstName = "Paul",
                LastName = "Gladstone",
                SquadId = 1,
                EnrollmentDate = DateTime.UtcNow
            };

            if (!context.Users.Any(u => u.UserName == "Paul"))
            {
                userManager.Create(squadMemeber4, "asdasd");
            }
            squad.SquadLeader = squadLeader;
            squad.Soldiers.Add(squadMemeber1);
            squad.Soldiers.Add(squadMemeber2);
            squad.Soldiers.Add(squadMemeber3);
            squad.Soldiers.Add(squadMemeber4);
            context.Squads.Add(squad);
            context.SaveChanges();

            var mission = new Mission() { Info = "Traning in the mountains", TargetLocation = location, SquadId = 1 };
            context.Missions.AddOrUpdate(mission);
            squad.ActiveMission = mission;

            context.SaveChanges();

            // SEED PLATOONS WITH PLATOON LEADERS
            var plattonLeader = new User()
            {
                UserName = "John",
                Email = "John@site.com",
                FirstName = "John",
                LastName = "Tiberian",
                EnrollmentDate = DateTime.UtcNow
            };

            if (!context.Users.Any(u => u.UserName == "John"))
            {
                userManager.Create(plattonLeader, "asdasd");
            }

            var platoon = new Platoon()
            {
                Name = "1st Brigade"
            };

            var messageToPlatoon = new Message() { Content = "Ellooooo", User = squadLeader };

            context.SaveChanges();

            platoon.Squads.Add(squad);
            platoon.Messages.Add(messageToPlatoon);
            platoon.PlatoonCommander = plattonLeader;
            context.Platoons.AddOrUpdate(platoon);

            context.SaveChanges();
        }
    }
}
