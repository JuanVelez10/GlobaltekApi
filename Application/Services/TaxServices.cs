using Application.Contracts.Persistence;
using Application.Interfaces;
using Domain.Entities;
namespace Application.Services
{
    public class TaxServices: ITaxServices
    {
        private readonly ITaxRepository taxRepository;

        public TaxServices(ITaxRepository taxRepository)
        {
            this.taxRepository = taxRepository;
        }

        public async Task<List<Tax>> GetAllTaxes()
        {
            return taxRepository.GetAll();
        }

        public async Task<Tax> GetTax(Guid? id)
        {
            return taxRepository.Get(id);
        }
    }
}
