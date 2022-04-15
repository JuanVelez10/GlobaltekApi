using Domain.Dtos;
using Domain.Entities;

namespace Application.Contracts.Infrastructure
{
    public interface IMapperService
    {
        BillBasic ConvertBillToBillBasic(Bill bill);
    }
}
