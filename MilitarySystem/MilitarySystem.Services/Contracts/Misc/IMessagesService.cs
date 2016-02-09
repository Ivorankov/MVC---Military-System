namespace MilitarySystem.Services.Contracts
{
    using System.Linq;

    using MilitartySystem.Models;

    public interface IMessagesService
    {
        IQueryable GetAll();

        Message GetById(int id);

        int Add(Message message);

        int Delete(int id);

        int Update(Message message);
    }
}
