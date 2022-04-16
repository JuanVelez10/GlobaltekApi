using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DataBase;

namespace Persistence.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly GlobaltekContext dbContext;

        public BillRepository(GlobaltekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Bill Get(Guid? id)
        {
            return dbContext.Bill.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Bill> GetAll()
        {
            return dbContext.Bill.ToList();
        }

    }
}
