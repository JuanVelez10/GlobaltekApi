using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums.Enums;

namespace Application.Interfaces
{
    public interface IMessageServices
    {
        public string GetMessage(int Code, MessageType messageType);
    }
}
