using Application.Contracts.Persistence;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class DiscountServices : IDiscountServices
    {
        private readonly IDiscountRepository discountRespository;

        public DiscountServices(IDiscountRepository discountRespository)
        {
            this.discountRespository = discountRespository;
        }

        public async Task<List<Discount>> GetAllDiscounts()
        {
            return discountRespository.GetAll();
        }

        public async Task<Discount> GetDiscount(Guid? id)
        {
            return discountRespository.Get(id);
        }
    }
}
