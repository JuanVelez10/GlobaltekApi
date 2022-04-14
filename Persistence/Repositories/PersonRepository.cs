using Domain.Entities;
using Persistence.DataBase;
using Persistence.Interfaces;

namespace Persistence.Repositories
{
    public class PersonRepository : IGenericRepository<Person>
    {

        private readonly GlobaltekContext dbContext;

        public PersonRepository(GlobaltekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Person Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Person Get(Guid? id)
        {
            return dbContext.Person.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Person> GetAll()
        {
            return dbContext.Person.ToList();
        }

        public Person Insert(Person @object)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person @object)
        {
            throw new NotImplementedException();
        }

    }
}
