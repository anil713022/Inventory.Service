using Inventory.Service.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Service.Api.Persistance
{
    public class IventoryDbContext : DbContext
    {
        public IventoryDbContext(DbContextOptions<IventoryDbContext> options)
            : base(options)
        {


        }

        public  DbSet<Inventoryes> Product { get; set; }
    }
}
