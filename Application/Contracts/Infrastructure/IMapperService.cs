using Domain.Dtos;
using Domain.Entities;

namespace Application.Contracts.Infrastructure
{
    public interface IMapperService
    {
        BillBasic ConvertBillToBillBasic(Bill bill);
        BillInfo ConvertBillToBillInfo(Bill bill);
        BillDetailInfo ConvertBillDetailToBillDetailInfo(BillDetail billDetail);
        BillDetail ConvertBillDetailInfoToBillDetail(BillDetailInfo billDetailInfo);
        Bill ConvertBillInfoToBill(BillInfo billInfo);
    }
}
