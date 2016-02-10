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

        public int Delete(string id)
        {
            this.users.Delete(id);

            return this.users.SaveChanges();
        }

        public IQueryable GetAll(int skip = 0, int take = 10)
        {
            return this.users
                .All()
                .Skip(skip)
                .Take(take);
        }

        public User GetById(string id)
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
