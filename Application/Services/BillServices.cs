using Application.Common;
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
    public class BillServices : IBillServices
    {
        private readonly IGenericRepository<Bill> billRepository;

        public BillServices(IGenericRepository<Bill> billRepository)
        {
            this.billRepository = billRepository;
        }


        public async Task<List<Bill>> GetAllBill()
        {
            return billRepository.GetAll();
        }



    }
}
