namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitarySystem.Models;

    public interface IUsersService : IDataService<User>
    {
        void AddToRole(string id, string role);

        void RemoveFromRole(string id, string role);
    }
}
