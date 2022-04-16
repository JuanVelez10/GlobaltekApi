using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DataBase;

namespace Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {

        private readonly GlobaltekContext dbContext;

        public PersonRepository(GlobaltekContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Person Get(Guid? id)
        {
            return dbContext.Person.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Person> GetAll()
        {
            return dbContext.Person.ToList();
        }

    }
}
