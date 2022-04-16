using Application.Contracts.Persistence;
using Application.Interfaces;
using Application.References;
using Domain.Dtos;
using Domain.Entities;
using static Domain.Enums.Enums;

namespace Application.Services
{
    public class PersonServices: IPersonServices
    {
        private readonly IPersonRepository personRepository;
        private readonly IMessageServices messageServices;

        public PersonServices(IPersonRepository personRepository, IMessageServices messageServices)
        {
            this.personRepository = personRepository;
            this.messageServices = messageServices;
        }

        //Method to obtain an person for id
        public async Task<Person> GetPersonForId(Guid? id)
        {
            return personRepository.Get(id);
        }

        //Method to obtain an person for login
        public async Task<BaseResponse<Login>> GetPersonLogin(string email,string password)
        {
            BaseResponse<Login> response = new BaseResponse<Login>();

            if (string.IsNullOrEmpty(email)) return MessageResponse(4, MessageType.Error, "Email");
            if (string.IsNullOrEmpty(password)) return MessageResponse(4, MessageType.Error, "Passwork");

            var person = personRepository.GetAll().Where(x=> x.Email== email && x.Password == password).FirstOrDefault();

            if (person == null) return MessageResponse(3, MessageType.Error, "Account");
            if(person.RoleType != RoleType.Admin) return MessageResponse(6, MessageType.Error, "Rol invalid");
            response = MessageResponse(1, MessageType.Success, "Account");

            response.Data = new Login();
            response.Data.person = person;

            return response;
        }

        //Method to return response message
        private BaseResponse<Login> MessageResponse(int code, MessageType messageType, string additionalMessage = "")
        {
            BaseResponse<Login> response = new BaseResponse<Login>();
            response.Code = code;
            response.Message = String.Format("{0} {1}", messageServices.GetMessage(code, messageType), additionalMessage);
            response.MessageType = messageType;
            return response;
        }


    }
}
