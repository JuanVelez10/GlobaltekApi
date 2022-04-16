﻿
using Domain.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IBillServices
    {
        Task<List<BillBasic>> GetAllBillBasic();

        Task<Bill> GetBill(Guid? id);

    }
}
