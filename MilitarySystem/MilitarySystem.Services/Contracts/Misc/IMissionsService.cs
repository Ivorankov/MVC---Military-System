namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitartySystem.Models;

    public interface IMissionsService
    {
        IQueryable GetAll();

        Mission GetById(int id);

        int Add(Mission mission);

        int Delete(int id);

        int Update(Mission mission);
    }
}
