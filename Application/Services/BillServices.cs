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
        private readonly ITaxServices taxServices;
        private readonly IDiscountServices discountServices;

        public BillServices(IBillRepository billRepository, IMapperService mapper, IPersonServices personService,
            IBillDetailServices billDetailServices, ITaxServices taxServices, IDiscountServices discountServices)
        {
            this.billRepository = billRepository;
            this.mapper = mapper;
            this.personService = personService;
            this.billDetailServices = billDetailServices;
            this.taxServices = taxServices;
            this.discountServices = discountServices;
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

            var person = await personService.GetPersonForId(billInfo.PersonId);

            if (person != null)
            {
                billInfo.NamePerson = person.Name;
                billInfo.DocumenPerson = person.Document;
            }

            billInfo.Discount = await discountServices.GetDiscount(billInfo.DiscountId);
            billInfo.Tax = await taxServices.GetTax(billInfo.TaxId);
            billInfo.BillDetails = await billDetailServices.GetAllBillDetailInfoForIdBill(billInfo.Id);

            return billInfo;
        }

    }
}
