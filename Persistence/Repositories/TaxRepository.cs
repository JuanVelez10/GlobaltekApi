using Domain.Entities;
using Persistence.DataBase;
using Persistence.Interfaces;


namespace Persistence.Repositories
{
    public class TaxRepository : IGenericRepository<Tax>
    {
        private readonly GlobaltekContext dbContext;

        public TaxRepository(GlobaltekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Tax Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Tax Get(Guid? id)
        {
            throw new NotImplementedException();
        }

        public List<Tax> GetAll()
        {
            throw new NotImplementedException();
        }

        public Tax Insert(Tax @object)
        {
            throw new NotImplementedException();
        }

        public Tax Update(Tax @object)
        {
            throw new NotImplementedException();
        }
    }
}
