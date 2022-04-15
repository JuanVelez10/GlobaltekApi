using Application.Contracts.Infrastructure;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
