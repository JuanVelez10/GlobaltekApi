using Application.References;
using Domain.Dtos;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IPersonServices
    {
        public Task<List<Person>> GetAllPerson();
        public Task<Person> GetPersonForId(Guid? id);
        public Task<BaseResponse<Login>> GetPersonLogin(string email, string password);
    }
}
