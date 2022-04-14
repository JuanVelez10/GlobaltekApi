using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Interfaces
{
    public interface IGenericRepository<TDomainObject>
    {
        public abstract TDomainObject Get(Guid? id);
        public abstract List<TDomainObject> GetAll();
        public abstract TDomainObject Insert(TDomainObject @object);
        public abstract TDomainObject Delete(Guid? id);
        public abstract TDomainObject Update(TDomainObject @object);

    }
}
