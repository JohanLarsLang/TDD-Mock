using BikeWorkShop.Controllers;
using BikeWorkShop.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class ItemTests
    {

        [Fact]
        public void GetAllData_ShouldCallGetAllDataOnce()
        {
            var mockRequest = new Mock<IApiRequestSend<Item>>();

            //ItemsController controller = new ItemsController(mockRequest.Object);

            FakeRequestSend controller = new FakeRequestSend(mockRequest.Object);

            controller.GetAllData();

            mockRequest.Verify(m => m.GetAllData(), Times.Once());

        }

        [Fact]
        public void GetRapairCost_CallsGetRapairCostWithCorrectParameter()
        {
            var mockRequest = new Mock<IApiRequestSend<Item>>();

            FakeRequestSend controller = new FakeRequestSend(mockRequest.Object);

            string itemName = "Bike racer";

            controller.GetRepairCost(itemName);

            mockRequest.Verify(m => m.GetRepairCost(itemName), Times.Once());

        }

        [Fact]
        public void AddEntity_CallsAddEntityWithCorrectParameter()
        {
            var mockRequest = new Mock<IApiRequestSend<Item>>();

            FakeRequestSend controller = new FakeRequestSend(mockRequest.Object);

            string itemName = "Bike racer";
            decimal repairCost = 150.50M;

            controller.AddEntity(itemName, repairCost);

            mockRequest.Verify(m => m.AddEntity(It.IsNotNull<string>(), It.Is<decimal>(x => x == repairCost)), Times.Once());

        }

        [Fact]
        public void ModifyEntity_CallsModifyEntityWithCorrectParameter()
        {
            var mockRequest = new Mock<IApiRequestSend<Item>>();

            FakeRequestSend controller = new FakeRequestSend(mockRequest.Object);

            Item item = new Item()
            {
                Id = 1,
                Name = "MTB",
                RepairCost = 215.50M
            };

            controller.ModifyEntity(item.Id, item);

            mockRequest.Verify(m => m.ModifyEntity(It.IsNotNull<int>(), It.Is<Item>(x => x == item)), Times.Once());

        }

        [Fact]
        public void DeleteEntity_CallsDeleteEntityWithCorrectParameter()
        {
            var mockRequest = new Mock<IApiRequestSend<Item>>();

            FakeRequestSend controller = new FakeRequestSend(mockRequest.Object);

            Item item = new Item()
            {
                Id = 1,
                Name = "MTB",
                RepairCost = 215.50M
            };

            controller.DeleteEntity(item);

            mockRequest.Verify(m => m.DeleteEntity(It.Is<Item>(x => x == item)), Times.Once());

        }


        public class FakeRequestSend : IApiRequestSend<Item>
        {
            private IApiRequestSend<Item> _request;


            public FakeRequestSend(IApiRequestSend<Item> request)
            {
                _request = request;
            }

            public IEnumerable<Item> GetAllData()
            {
                return _request.GetAllData();
            }

             public decimal GetRepairCost(string item)
            {
                return _request.GetRepairCost(item);
            }

            public void AddEntity(string item, decimal cost)
            {
                _request.AddEntity(item, cost);
            }

            public void ModifyEntity(int id, Item item)
            {

                _request.ModifyEntity(id, item);

            }

            public void DeleteEntity(Item item)
            {
                _request.DeleteEntity(item);
            }

        }

    }
}
