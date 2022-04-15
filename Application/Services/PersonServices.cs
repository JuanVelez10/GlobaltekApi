using Application.Contracts.Persistence;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PersonServices: IPersonServices
    {
        private readonly IGenericRepository<Person> personRepository;

        public PersonServices(IGenericRepository<Person> personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task<Person> GetPersonForId(Guid? id)
        {
            return personRepository.Get(id);
        }


    }
}
