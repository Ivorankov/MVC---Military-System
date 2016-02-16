namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitarySystem.Models;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        User GetById(string id);

        int Add(User user);

        int Delete(string id);

        int Update(User user);
    }
}
