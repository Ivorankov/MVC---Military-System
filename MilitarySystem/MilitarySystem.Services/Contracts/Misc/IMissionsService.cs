namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitarySystem.Models;

    public interface IMissionsService
    {
        IQueryable GetAll(int skip, int take);

        Mission GetById(int id);

        int Add(Mission mission);

        int Delete(int id);

        int Update(Mission mission);
    }
}
