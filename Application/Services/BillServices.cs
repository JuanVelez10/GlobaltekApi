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
        private readonly IBillDetailServices billDetailServices;

        public BillServices(IGenericRepository<Bill> billRepository, IMapperService mapper, IPersonServices personService,
            IBillDetailServices billDetailServices)
        {
            this.billRepository = billRepository;
            this.mapper = mapper;
            this.personService = personService;
            this.billDetailServices = billDetailServices;
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

        public async Task<Bill> GetBill(Guid? id)
        {
            var bill = billRepository.Get(id);
            bill.BillDetails = await Task.Run(() =>
            {
                return billDetailServices.GetAllBillDetail().Result.Where(x => x.BillId == bill.Id).ToList();
            }); 

            return bill;
        }

    }
}
