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
        private readonly IProductServices productServices;

        public BillDetailServices(IBillDetailRepository billDetailRepository, IMapperService mapper, IProductServices productServices)
        {
            this.billDetailRepository = billDetailRepository;
            this.mapper = mapper;
            this.productServices = productServices;
        }

        public async Task<List<BillDetailInfo>> GetAllBillDetailInfoForIdBill(Guid? id)
        {
            List<BillDetailInfo> billDetailInfos = new List<BillDetailInfo>();

            billDetailInfos = billDetailRepository.GetAllForIdBill(id).Select(x=> mapper.ConvertBillDetailToBillDetailInfo(x)).ToList();

            if (billDetailInfos.Any())
            {
                foreach (var billDetailsInfo in billDetailInfos)
                {
                    var product = productServices.GetProduct(billDetailsInfo.ProductId);
                    if (product != null) billDetailsInfo.NameProduct = product.Result.Name;
                }
            }

            return billDetailInfos;
        }
    }
}
