namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitarySystem.Models;

    public interface IUsersService
    {
        IQueryable GetAll(int skip, int take);

        User GetById(string id);

        int Add(User user);

        int Delete(string id);

        int Update(User user);
    }
}
