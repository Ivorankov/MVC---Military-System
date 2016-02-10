namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitarySystem.Models;

    public interface ISquadsService
    {
        IQueryable GetAll(int skip, int take);

        Squad GetById(int id);

        int Add(Squad squad);

        int Delete(int id);

        int Update(Squad squad);
    }
}
