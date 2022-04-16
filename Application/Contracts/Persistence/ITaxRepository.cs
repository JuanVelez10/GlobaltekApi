using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface ITaxRepository
    {
        Tax Get(Guid? id);
        List<Tax> GetAll();
    }
}
