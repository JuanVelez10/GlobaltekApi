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
            throw new NotImplementedException();
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
