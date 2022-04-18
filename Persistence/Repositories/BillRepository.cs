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
            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {

                try
                {

                    var bill = Get(id);

                    var detailsOld = dbContext.BillDetail.Where(x => x.BillId == id).ToList();
                    detailsOld.ForEach(x => dbContext.BillDetail.Remove(x));

                    dbContext.Bill.Remove(bill);

                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }

            return true;
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
                    bill.Id = Guid.NewGuid();

                    var billDetails = bill.BillDetails;
                    bill.BillDetails = null;

                    dbContext.Bill.Add(bill);

                    foreach (var billDetail in billDetails)
                    {
                        billDetail.Id = Guid.NewGuid();
                        billDetail.BillId = bill.Id;
                        dbContext.BillDetail.Add(billDetail);
                    }

                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch(Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }

        }

        public bool Update(Bill bill)
        {

            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {

                try
                {
                    var billDetails = bill.BillDetails;
                    bill.BillDetails = null;

                    var billUpdate = Get(bill.Id); 
                    billUpdate.Date = bill.Date;
                    billUpdate.DiscountId = bill.DiscountId;
                    billUpdate.DiscountTotal = bill.DiscountTotal;
                    billUpdate.PaymentType = bill.PaymentType;
                    billUpdate.PersonId = bill.PersonId;
                    billUpdate.SubTotal = bill.SubTotal;
                    billUpdate.TaxId = bill.TaxId;
                    billUpdate.TaxTotal = bill.TaxTotal;
                    billUpdate.Total = bill.Total;

                    var detailsOld = dbContext.BillDetail.Where(x => x.BillId == bill.Id).ToList();
                    detailsOld.ForEach(x => dbContext.BillDetail.Remove(x));

                    foreach (var billDetail in billDetails)
                    {
                        billDetail.Id = Guid.NewGuid();
                        billDetail.BillId = bill.Id;
                        dbContext.BillDetail.Add(billDetail);
                    }

                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
    }
}
