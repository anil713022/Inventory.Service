using Inventory.Service.Api.Persistance;
using Inventory.Service.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryServices.Tes
{
    class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(IventoryDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            //context.Product.AddRange(
            //    new Inventoryes() { Title = "Test Title 1", Name="huyy", Description = "Test Description 1", CategoryId = 12,  },
            //    new Inventoryes() { Title = "Test Title 2", Name="trr", Description = "Test Description 2", CategoryId = 13, }
            //);
            //context.SaveChanges();
        }
    }
}

