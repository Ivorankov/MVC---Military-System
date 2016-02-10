namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitarySystem.Models;

    public interface IUsersService
    {
        IQueryable GetAll();

        User GetById();

        User GetByUserName();

        int Add(User user);

        int Delete(int id);

        int Update(User user);
    }
}
