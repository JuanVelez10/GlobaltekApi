using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DataBase;

namespace Persistence.Repositories
{
    public class BillRepository : IGenericRepository<Bill>
    {
        private readonly GlobaltekContext dbContext;

        public BillRepository(GlobaltekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Bill Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Bill Get(Guid? id)
        {
            return dbContext.Bill.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Bill> GetAll()
        {
            return dbContext.Bill.ToList();
        }

        public Bill Insert(Bill @object)
        {
            throw new NotImplementedException();
        }

        public Bill Update(Bill @object)
        {
            throw new NotImplementedException();
        }
    }
}
