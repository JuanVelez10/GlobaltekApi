

namespace Application.Contracts.Persistence
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
