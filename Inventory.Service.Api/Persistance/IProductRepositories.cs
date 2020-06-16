using Inventory.Service.Domain;
using Inventory.Service.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Service.Api.Persistance
{
    public interface IProductRepositories
    {
        //Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<IEnumerable<Inventoryes>> GetProduct();
        Task<int> AddProduct(Inventoryes inventoryesst);
        Task<Inventoryes> GetProductById(int? postId);
        Task<int> DeleteProduct(int? postId);

        Task UpdateProduct(Inventoryes post);
    }
}
