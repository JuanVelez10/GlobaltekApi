
using Application.References;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IBillServices
    {
        Task<List<BillBasic>> GetAllBillBasic();

        Task<BillInfo> GetBill(Guid? id);

        Task<BaseResponse<bool>> Update(BillInfo billInfo);

        Task<BaseResponse<bool>> Insert(BillInfo billInfo);

        Task<BaseResponse<bool>> Delete(Guid? id);
    }
}
