
using Domain.Dtos;

namespace Application.Interfaces
{
    public interface IBillServices
    {
        public Task<List<BillBasic>> GetAllBillBasic();
    }
}
