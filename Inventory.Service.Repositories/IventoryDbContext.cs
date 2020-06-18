using Inventory.Service.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Service.Repositories
{
  
        public class IventoryDbContext : DbContext
        {
            public IventoryDbContext(DbContextOptions<IventoryDbContext> options)
                : base(options)
            {


            }

            public DbSet<Inventoryes> Product { get; set; }
        }
    
}
