namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitartySystem.Models;

    public interface IUsersServices
    {
        IQueryable GetAll();

        User GetById();

        User GetByUserName();

        int Add(User user);

        int Delete(int id);

        int Update(User user);
    }
}
