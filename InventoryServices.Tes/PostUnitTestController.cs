using Inventory.Service.Api.Controllers;
using Inventory.Service.Api.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace InventoryServices.Tes
{
    public class PostUnitTestController
    {
        private ProductRepositories repository;
        public static DbContextOptions<IventoryDbContext> dbContextOptions { get; }
        public static string connectionString = "Server=DOTNETFSD02;Database=Inventory;Trusted_Connection=True";
        //"Server=DOTNETFSD02;Database=Inventory;Trusted_Connection=True;"
        static PostUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<IventoryDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }


        public PostUnitTestController()
        {
            var context = new IventoryDbContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);

            repository = new ProductRepositories(context);

        }
        private readonly ILogger<ProductController> _logger;

        [Fact]
        public async void Task_GetPostById_Return_OkResult()
        {
            //Arrange
            var controller = new ProductController(_logger, repository);
            var postId = 2;

            //Act
            var data = await controller.GetProductById(postId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        
    }
}
