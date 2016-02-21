namespace MilitarySystem.Services
{
    using System;
    using System.Linq;
    using Models;

    using MilitarySystem.Services.Contracts;
    using Data.Contracts;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public int Add(User user)
        {
            this.users.Add(user);

            return this.users.SaveChanges();
        }

        public int Delete(User id)
        {
            this.users.Delete(id);

            return this.users.SaveChanges();
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
    }
}
