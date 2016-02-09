namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitartySystem.Models;

    public interface ISquadsServices
    {
        IQueryable GetAll();

        Squad GetById(int id);

        int Add(Squad squad);

        int Delete(int id);

        int Update(Squad squad);
    }
}
