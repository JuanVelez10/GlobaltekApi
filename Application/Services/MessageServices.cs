using Application.Contracts.Persistence;
using Application.Interfaces;
using Domain.Entities;
using System;
using static Domain.Enums.Enums;

namespace Application.Services
{
    public class MessageServices: IMessageServices
    {
        private readonly IGenericRepository<Message> messageRepository;

        public MessageServices(IGenericRepository<Message> messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        //Method to get success or error messages from database
        public string GetMessage(int Code, MessageType messageType)
        {
            return messageRepository.GetAll().Where(x => x.Code == Code && x.MessageType == messageType).Select(x => x.Text).FirstOrDefault();
        }

    }
}
