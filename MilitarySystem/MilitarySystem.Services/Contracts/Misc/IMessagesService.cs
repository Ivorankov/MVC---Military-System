namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitarySystem.Models;

    public interface IMessagesService
    {
        IQueryable<Message> GetAll();

        Message GetById(int id);

        void Add(Message message);

        int Delete(Message dbModel);

        int Update(Message message);
    }
}
