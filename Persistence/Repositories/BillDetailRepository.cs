using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DataBase;

namespace Persistence.Repositories
{
    public class BillDetailRepository : IBillDetailRepository
    {
        private readonly GlobaltekContext dbContext;

        public BillDetailRepository(GlobaltekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<BillDetail> GetAllForIdBill(Guid? id)
        {
            return dbContext.BillDetail.Where(x=> x.BillId == id).ToList();
        }

    }
}
