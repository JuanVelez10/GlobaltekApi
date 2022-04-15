using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DataBase;

namespace Persistence.Repositories
{
    public class MessageRepository : IGenericRepository<Message>
    {
        private readonly GlobaltekContext dbContext;

        public MessageRepository(GlobaltekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Message Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Message Get(Guid? id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetAll()
        {
            throw new NotImplementedException();
        }

        public Message Insert(Message @object)
        {
            throw new NotImplementedException();
        }

        public Message Update(Message @object)
        {
            throw new NotImplementedException();
        }
    }
}
