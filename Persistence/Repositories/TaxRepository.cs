using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DataBase;

namespace Persistence.Repositories
{
    public class TaxRepository : ITaxRepository
    {
        private readonly GlobaltekContext dbContext;

        public TaxRepository(GlobaltekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Tax Get(Guid? id)
        {
            return dbContext.Tax.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Tax> GetAll()
        {
            return dbContext.Tax.ToList();
        }

    }
}
