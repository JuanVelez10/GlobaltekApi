using Application.Contracts.Persistence;
using Domain.Dtos;
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

        public bool Delete(Guid? id)
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

        public bool Insert(Bill bill)
        {
            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {

                try
                {
                    dbContext.Bill.Add(bill);

                    foreach (var billDetail in bill.BillDetails)
                    {
                        dbContext.BillDetail.Add(billDetail);
                    }

                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }

        }

        public bool Update(Bill bill)
        {
            throw new NotImplementedException();
        }
    }
}
