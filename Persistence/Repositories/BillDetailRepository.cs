using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DataBase;

namespace Persistence.Repositories
{
    public class BillDetailRepository : IGenericRepository<BillDetail>
    {
        private readonly GlobaltekContext dbContext;

        public BillDetailRepository(GlobaltekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public BillDetail Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public BillDetail Get(Guid? id)
        {
            throw new NotImplementedException();
        }

        public List<BillDetail> GetAll()
        {
            return dbContext.BillDetail.ToList();
        }

        public BillDetail Insert(BillDetail @object)
        {
            throw new NotImplementedException();
        }

        public BillDetail Update(BillDetail @object)
        {
            throw new NotImplementedException();
        }
    }
}
