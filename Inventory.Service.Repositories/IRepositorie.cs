using Inventory.Service.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Service.Repositories
{
   public interface IRepositorie
    {
        //Task<IEnumerable<Inventoryes>> GetProduct();
        Task<IEnumerable<Inventoryes>> GetProduct();
        Task<int> AddProduct(Inventoryes inventoryesst);
        Task<Inventoryes> GetProductById(int? postId);
        Task<int> DeleteProduct(int? postId);

        Task UpdateProduct(Inventoryes post);
    }
}
