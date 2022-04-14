using Domain.Entities;
using Persistence.DataBase;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class DiscountRepository : IGenericRepository<Discount>
    {
        private readonly GlobaltekContext dbContext;

        public DiscountRepository(GlobaltekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Discount Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Discount Get(Guid? id)
        {
            throw new NotImplementedException();
        }

        public List<Discount> GetAll()
        {
            throw new NotImplementedException();
        }

        public Discount Insert(Discount @object)
        {
            throw new NotImplementedException();
        }

        public Discount Update(Discount @object)
        {
            throw new NotImplementedException();
        }
    }
}
