using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DataBase;

namespace Persistence.Repositories
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private readonly GlobaltekContext dbContext;

        public ProductRepository(GlobaltekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Product Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Product Get(Guid? id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product Insert(Product @object)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product @object)
        {
            throw new NotImplementedException();
        }
    }
}
