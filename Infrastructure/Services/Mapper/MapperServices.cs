using Application.Contracts.Infrastructure;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;


namespace Infrastructure.Services.Mapper
{
    public class MapperServices : IMapperService
    {
        private readonly IMapper mapper;

        public MapperServices(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public BillBasic ConvertBillToBillBasic(Bill bill)
        {
            return mapper.Map<BillBasic>(bill);
        }

        public BillInfo ConvertBillToBillInfo(Bill bill)
        {
            return mapper.Map<BillInfo>(bill);
        }

        public BillDetailInfo ConvertBillDetailToBillDetailInfo(BillDetail billDetail)
        {
            return mapper.Map<BillDetailInfo>(billDetail);
        }
        

    }
}
