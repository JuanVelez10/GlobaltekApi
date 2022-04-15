using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Interfaces;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Services
{
    public class BillServices : IBillServices
    {
        private readonly IGenericRepository<Bill> billRepository;
        private readonly IMapperService mapper;
        private readonly IPersonServices personService;

        public BillServices(IGenericRepository<Bill> billRepository, IMapperService mapper, IPersonServices personService)
        {
            this.billRepository = billRepository;
            this.mapper = mapper;
            this.personService = personService;
        }


        public async Task<List<BillBasic>> GetAllBillBasic()
        {
            var billsBasic = billRepository.GetAll().Select(x => mapper.ConvertBillToBillBasic(x)).ToList();

            if (billsBasic.Any())
            {
                foreach (var billBasic in billsBasic)
                {
                    var person = personService.GetPersonForId(billBasic.PersonId);
                    if (person != null) billBasic.NameClient = person.Result.Name;
                }
            }

            return billsBasic;
        }



    }
}
