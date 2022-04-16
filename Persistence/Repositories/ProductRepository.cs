using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DataBase;

namespace Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly GlobaltekContext dbContext;

        public ProductRepository(GlobaltekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Product Get(Guid? id)
        {
            return dbContext.Product.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Product> GetAll()
        {
            return dbContext.Product.ToList();
        }

    }
}
