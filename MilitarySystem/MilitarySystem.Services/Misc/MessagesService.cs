namespace MilitarySystem.Services
{
    using System;
    using System.Linq;

    using Models;
    using MilitarySystem.Services.Contracts;
    using Data.Contracts;

    public class MessagesService : IMessagesService
    {
        private readonly IRepository<Message> messages;

        public MessagesService(IRepository<Message> messages)
        {
            this.messages = messages;
        }

        public int Add(Message message)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable GetAll()
        {
            throw new NotImplementedException();
        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
