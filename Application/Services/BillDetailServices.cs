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
    public class BillDetailServices : IBillDetailServices
    {
        private readonly IGenericRepository<BillDetail> billDetailRepository;

        public BillDetailServices(IGenericRepository<BillDetail> billDetailRepository)
        {
            this.billDetailRepository = billDetailRepository;
        }

        public async Task<List<BillDetail>> GetAllBillDetail()
        {
            return billDetailRepository.GetAll();
        }
    }
}
