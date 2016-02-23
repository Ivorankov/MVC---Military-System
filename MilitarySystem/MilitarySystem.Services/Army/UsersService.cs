namespace MilitarySystem.Services
{
    using System;
    using System.Linq;
    using Models;

    using MilitarySystem.Services.Contracts;
    using Data.Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Data;
    using Common;
    using System.Data.Entity.Validation;
    using System.Diagnostics;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;

        private readonly IRepository<Platoon> platoons;

        private readonly IRepository<Squad> squads;

        private readonly IRepository<Message> messages;

        private readonly IMilitarySystemContext context;

        public UsersService(
            IRepository<User> users,
            IRepository<Platoon> platoons,
            IRepository<Squad> squads,
            IRepository<Message> messages,
            IMilitarySystemContext context
            )
        {
            this.users = users;
            this.platoons = platoons;
            this.squads = squads;
            this.messages = messages;
            this.context = context;
        }

        public int Add(User user)
        {
            var userManager = this.GetManager();

            var newUser = new User()
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.UserName + "@site.com",
                EnrollmentDate = DateTime.Now
            };


            try
            {
                var result = userManager.Create(newUser, user.PasswordHash);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            return 0;

        }

        public int Delete(User user)
        {
            var userManager = this.GetManager();
            var userToDelete = userManager.Users.FirstOrDefault(x => x.Id == user.Id);
            var messages = this.messages.All().Where(x => x.UserId == user.Id);
            foreach (var item in messages)
            {
                this.messages.Delete(item);
                userToDelete.Messages.Remove(item);
            }

            this.messages.SaveChanges();

            var squad = this.squads.All().FirstOrDefault(x => x.SquadLeaderId == user.Id);

            if (squad != null)
            {
                squad.SquadLeaderId = null;
                squad.SquadLeader = null;
                this.squads.Update(squad);
                this.squads.SaveChanges();
                userManager.RemoveFromRole(user.Id, ModelsConstraints.SquadLeaderRoleName);
            }

            var platoon = this.platoons
                .All()
                .FirstOrDefault(x => x.PlatoonCommanderId == user.Id);

            if (platoon != null)
            {
                platoon.PlatoonCommanderId = null;
                this.platoons.Update(platoon);
                this.platoons.SaveChanges();
                userManager.RemoveFromRole(user.Id, ModelsConstraints.PlatoonLeaderRoleName);
            }
            userManager.Dispose();
            var user1 = this.users.GetById(user.Id);
            this.users.Delete(user1);
            this.users.SaveChanges();
            return 1; //TODO Remove return
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public User GetById(object id)
        {
            return this.users.GetById(id);
        }


        public int Update(User user)
        {
            this.users.Update(user);

            return this.users.SaveChanges();
        }

        public void AddToRole(string id, string role)
        {

            var userManager = this.GetManager();

            userManager.AddToRole(id, role);
        }

        public void RemoveFromRole(string id, string role)
        {
            var userManager = this.GetManager();

            userManager.RemoveFromRole(id, role);
        }

        private UserManager<User> GetManager()
        {
            var userStore = new UserStore<User>(this.context as MilitarySystemContext);
            var userManager = new UserManager<User>(userStore);
            userManager.UserValidator = new UserValidator<User>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configure user lockout defaults
            userManager.UserLockoutEnabledByDefault = true;
            userManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            userManager.MaxFailedAccessAttemptsBeforeLockout = 5;

            return userManager;
        }
    }
}
