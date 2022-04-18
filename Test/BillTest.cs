using Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Domain.Entities;
using Application.Interfaces;
using Moq;
using Domain.Dtos;

namespace Test
{
    public class Tests
    {
        private BillController billController;
        private Guid IdBill = Guid.NewGuid();

        [SetUp]
        public void Setup()
        {
            var mockRepo = new Mock<IBillServices>();
            mockRepo.Setup(repo => repo.GetAllBillBasic()).Returns(Get());
            mockRepo.Setup(repo => repo.GetBill(IdBill)).Returns(GetInfo(IdBill));
            billController = new BillController(mockRepo.Object);
        }

        [Test]
        public async Task GetAllSucces()
        {
            Assert.IsTrue(billController.Get().Wait(60000));
            var reponse = await billController.Get() as OkObjectResult;
            Assert.IsNotNull(reponse);
            Assert.AreEqual(200, reponse.StatusCode);
            var bills = reponse.Value as List<BillBasic>;
            Assert.IsTrue(bills.Any());
            bills.ForEach(x => Assert.IsNotNull(x));
            bills.ForEach(x => Assert.IsNotNull(x.Number));
        }

        [Test]
        public async Task GetSucces()
        {
            var responseGetAll = await billController.Get() as OkObjectResult;
            var bills = responseGetAll.Value as List<BillBasic>;
            var bill = bills.FirstOrDefault();
            var reponseGet = await billController.Get(bill.Id) as OkObjectResult;
            Assert.IsNotNull(reponseGet);
            Assert.AreEqual(200, reponseGet.StatusCode);
            var billOutput = reponseGet.Value as BillInfo;
            Assert.IsNotNull(billOutput);
            Assert.AreEqual(bill.Id, billOutput.Id);
            Assert.AreEqual(bill.Number, billOutput.Number);

        }

        [Test]
        public async Task GetError()
        {
            var reponseNotFound = await billController.Get(Guid.NewGuid()) as NotFoundObjectResult;
            Assert.IsNotNull(reponseNotFound);
            Assert.AreEqual(404, reponseNotFound.StatusCode);
        }


        private async Task<List<BillBasic>> Get()
        {
            List<BillBasic> billBasics = new List<BillBasic>();
            BillBasic billBasic = new BillBasic();
            billBasic.Id = IdBill;
            billBasic.Number = 123;
            billBasics.Add(billBasic);

            return billBasics;
        }

        private async Task<BillInfo> GetInfo(Guid? id)
        {
            BillInfo billInfo = new BillInfo();
            billInfo.Id = id;
            billInfo.Number = 123;
            return billInfo;
        }

    }
}