using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Interfaces;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Services
{
    public class BillServices : IBillServices
    {
        private readonly IBillRepository billRepository;
        private readonly IMapperService mapper;
        private readonly IPersonServices personService;
        private readonly IBillDetailServices billDetailServices;

        public BillServices(IBillRepository billRepository, IMapperService mapper, IPersonServices personService,
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

        public async Task<BillInfo> GetBill(Guid? id)
        {
            var billInfo = mapper.ConvertBillToBillInfo(billRepository.Get(id));

            billInfo.Person = await Task.Run(() =>
            {
                return personService.GetPersonForId(billInfo.PersonId);
            });


            billInfo.BillDetails = await Task.Run(() =>
            {
                return billDetailServices.GetAllBillDetailInfo(billInfo.Id).Result;
            }); 

            return billInfo;
        }

    }
}
