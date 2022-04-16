using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Interfaces;
using Domain.Dtos;
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
        private readonly IBillDetailRepository billDetailRepository;
        private readonly IMapperService mapper;

        public BillDetailServices(IBillDetailRepository billDetailRepository, IMapperService mapper)
        {
            this.billDetailRepository = billDetailRepository;
            this.mapper = mapper;
        }

        public async Task<List<BillDetailInfo>> GetAllBillDetailInfo(Guid? id)
        {
            return billDetailRepository.GetAllForIdBill(id).Select(x => mapper.ConvertBillDetailToBillDetailInfo(x)).ToList();
        }
    }
}
