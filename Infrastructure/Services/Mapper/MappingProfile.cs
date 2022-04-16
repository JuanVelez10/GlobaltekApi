using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bill, BillBasic>();
            CreateMap<Bill, BillInfo>();
            CreateMap<BillDetail, BillDetailInfo>();
        }

    }
}
