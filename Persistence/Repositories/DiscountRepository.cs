using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DataBase;


namespace Persistence.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly GlobaltekContext dbContext;

        public DiscountRepository(GlobaltekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Discount Get(Guid? id)
        {
            return dbContext.Discount.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Discount> GetAll()
        {
            return dbContext.Discount.ToList();
        }

    }
}
