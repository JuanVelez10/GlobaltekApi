using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IBillRepository
    {
        Bill Get(Guid? id);
        List<Bill> GetAll();
        bool Insert(Bill bill);
        bool Delete(Guid? id);
        bool Update(Bill bill);
    }
}
