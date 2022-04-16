using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DataBase;

namespace Persistence.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly GlobaltekContext dbContext;

        public MessageRepository(GlobaltekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Message> GetAll()
        {
           return dbContext.Message.ToList();
        }

    }
}
