using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Interfaces;
using Application.References;
using Domain.Dtos;
using Domain.Entities;
using static Domain.Enums.Enums;

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
        private readonly IProductRepository productRepository;
        private readonly IMessageServices messageServices;

        public BillServices(IBillRepository billRepository, IMapperService mapper, IPersonServices personService,
            IBillDetailServices billDetailServices, ITaxServices taxServices, IDiscountServices discountServices,
            IMessageServices messageServices, IProductRepository productRepository)
        {
            this.billRepository = billRepository;
            this.mapper = mapper;
            this.personService = personService;
            this.billDetailServices = billDetailServices;
            this.taxServices = taxServices;
            this.discountServices = discountServices;
            this.messageServices = messageServices;
            this.productRepository = productRepository;
        }

        public async Task<BaseResponse<bool>> Delete(Guid? id)
        {
            BaseResponse<bool> reponse = new BaseResponse<bool>();

            if (!id.HasValue) return MessageResponse(4, MessageType.Error, "Bill");
            var exits = billRepository.Get(id);
            if (exits == null) return MessageResponse(3, MessageType.Error, "Bill");

            var delete = billRepository.Delete(id);
            if (!delete) return MessageResponse(6, MessageType.Error);

            reponse = MessageResponse(1, MessageType.Success, "Bill");
            reponse.Data = delete;

            return reponse;

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

        public async Task<BaseResponse<bool>> Insert(BillInfo billInfo)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();

            response = Validate(billInfo, false);
            if (response.Code > 0) return response;

            var bill = await CalculateBill(billInfo);

            var save = billRepository.Insert(bill);

            if (!save) return MessageResponse(6, MessageType.Error);

            response = MessageResponse(1, MessageType.Success, "Bill");
            response.Data = save;

            return response;
        }

        public async Task<BaseResponse<bool>> Update(BillInfo billInfo)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();

            response = Validate(billInfo, true);
            if (response.Code > 0) return response;

            var bill = await CalculateBill(billInfo);

            var save = billRepository.Update(bill);

            if (!save) return MessageResponse(6, MessageType.Error);

            response = MessageResponse(1, MessageType.Success, "Bill");
            response.Data = save;

            return response;
        }

        private async Task<Bill> CalculateBill(BillInfo billInfo)
        {
            Bill bill = mapper.ConvertBillInfoToBill(billInfo);

            bill.SubTotal = 0;
            bill.BillDetails = new List<BillDetail>();
            foreach (var billDetailInfo in billInfo.BillDetails)
            {
                var product = productRepository.Get(billDetailInfo.ProductId);

                if (product != null)
                {
                    bill.SubTotal = bill.SubTotal + product.Cost;

                    var billDetail = mapper.ConvertBillDetailInfoToBillDetail(billDetailInfo);
                    billDetail.BillId = billInfo.Id;
                    billDetail.UnitCost = product.Cost;

                    bill.BillDetails.Add(billDetail);
                }
            }

            var discount = await discountServices.GetDiscount(bill.DiscountId);
            bill.DiscountTotal = bill.SubTotal * discount.Percentage;

            var total = bill.SubTotal - bill.DiscountTotal;
            var tax = await taxServices.GetTax(bill.TaxId);
            bill.TaxTotal = total * tax.Percentage;

            bill.Total = total + bill.TaxTotal;

            return bill;
        }

        private BaseResponse<bool> Validate(BillInfo billInfo, bool update)
        {
            if (!billInfo.PersonId.HasValue) return MessageResponse(4, MessageType.Error, "PersonId");
            if (!billInfo.DiscountId.HasValue) return MessageResponse(4, MessageType.Error, "DiscountId");
            if (!billInfo.TaxId.HasValue) return MessageResponse(4, MessageType.Error, "TaxId");
            if (billInfo.Date == null) return MessageResponse(4, MessageType.Error, "Date");
            if ((int)billInfo.PaymentType < 0) return MessageResponse(4, MessageType.Error, "PaymentType");
            if (!billInfo.BillDetails.Any()) return MessageResponse(4, MessageType.Error, "BillDetails");

            if (update)
            {
                if (!billInfo.Id.HasValue) return MessageResponse(4, MessageType.Error, "Id");
                if (billInfo.Number < 0) return MessageResponse(4, MessageType.Error, "Number");
            }

            return new BaseResponse<bool>();

        }

        public BaseResponse<bool> MessageResponse(int code, MessageType messageType, string additionalMessage = "")
        {
            BaseResponse<bool> response = new BaseResponse<bool>();
            response.Code = code;
            response.Message = String.Format("{0} {1}", messageServices.GetMessage(code, messageType), additionalMessage);
            response.MessageType = messageType;
            return response;
        }


    }
}
