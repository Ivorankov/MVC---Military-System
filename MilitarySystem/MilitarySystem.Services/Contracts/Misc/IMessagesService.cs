namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitarySystem.Models;

    public interface IMessagesService
    {
        IQueryable GetAll();

        Message GetById(int id);

        void Add(Message message);

        int Delete(int id);

        int Update(Message message);
    }
}
