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

        public void Add(Message message)
        {
            this.messages.Add(message);
            this.messages.SaveChanges();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable GetAll()
        {
            return this.messages.All();
        }

        public Message GetById(int id)
        {
            return this.messages.GetById(id);
        }

        public int Update(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
