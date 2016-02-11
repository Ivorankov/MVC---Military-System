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
            //var store = new RoleStore<IdentityRole>(context);
            //var manager = new RoleManager<IdentityRole>(store);

            ////Seed roles TODO split Admin into 3 sub roles - Users/ Communication / Weapons/Gear/Vehciles
            //if (!context.Roles.Any(r => r.Name == "SquadLeader"))
            //{
            //    var roleAdmin = new IdentityRole
            //    {
            //        Name = "SquadLeader"
            //    };

            //    manager.Create(roleAdmin);
            //}

            //if (!context.Roles.Any(r => r.Name == "PlatoonLeader"))
            //{
            //    var roleAdmin = new IdentityRole
            //    {
            //        Name = "PlatoonLeader"
            //    };

            //    manager.Create(roleAdmin);
            //}

            //if (!context.Roles.Any(r => r.Name == "Admin"))
            //{
            //    var roleAdmin = new IdentityRole
            //    {
            //        Name = "Admin"
            //    };

            //    manager.Create(roleAdmin);
            //}

            //var userStore = new UserStore<User>(context);
            //var userManager = new UserManager<User>(userStore);

            //userManager.PasswordValidator = new MinimumLengthValidator(5);

            ////SEED ADMIN USERS
            //var adminUser = new User()
            //{
            //    UserName = "Admin",
            //    Email = "Admin@site.com",
            //    EnrollmentDate = DateTime.UtcNow
            //};

            //if (!context.Users.Any(u => u.UserName == "Admin"))
            //{
            //    userManager.Create(adminUser, "2admin1");
            //    userManager.AddToRole(adminUser.Id, "Admin");
            //}

            ////SEED SQUADS WITH TEAM MEMEBERS
            //var squadLeader = new User()
            //{
            //    UserName = "Robin",
            //    Email = "Robin@mail.bg",
            //    EnrollmentDate = DateTime.UtcNow
            //};

            //if (!context.Users.Any(u => u.UserName == "Robin"))
            //{
            //    userManager.Create(squadLeader, "asdasd");
            //}

            //var squadMemeber1 = new User()
            //{
            //    UserName = "Derrik",
            //    Email = "Derrik@mail.bg",
            //    EnrollmentDate = DateTime.UtcNow
            //};

            //if (!context.Users.Any(u => u.UserName == "Derrik"))
            //{
            //    userManager.Create(squadMemeber1, "asdasd");
            //}

            //var squad = new Squad()
            //{
            //    Name = "Alpha",
            //};

            //squad.Soldiers.Add(squadMemeber1);
            //context.Squads.AddOrUpdate(squad);

            //var plattonLeader = new User()
            //{
            //    UserName = "John",
            //    Email = "John@site.com",
            //    EnrollmentDate = DateTime.UtcNow
            //};

            //if (!context.Users.Any(u => u.UserName == "John"))
            //{
            //    userManager.Create(plattonLeader, "asdasd");
            //}

            //var platoon = new Platoon()
            //{
            //    Name = "1st Brigade"
            //};

            ////platoon.Squads.Add(squad);
            //context.Platoons.AddOrUpdate(platoon);
        }
    }
}
