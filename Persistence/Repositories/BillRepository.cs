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
            throw new NotImplementedException();
        }

        public List<Bill> GetAll()
        {
            throw new NotImplementedException();
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
