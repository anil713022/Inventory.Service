using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Service.Domain;
using Inventory.Service.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Service.Api.Persistance
{
    public class ProductRepositories :IProductRepositories
    {
        
        private readonly IventoryDbContext appDbContext;

        public ProductRepositories(IventoryDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

       
        public async Task<IEnumerable<Inventoryes>> GetProduct()
        {
            return await appDbContext.Product.ToListAsync();
        }

        public async Task<int> AddProduct(Inventoryes post)
        {
            if (appDbContext != null)
            {
                await appDbContext.Product.AddAsync(post);
                await appDbContext.SaveChangesAsync();

                return post.PostId;
            }

            return 0;
        }

        public async Task<int> DeleteProduct(int? postId)
        {
            int result = 0;

            if (appDbContext != null)
            {
                //Find the post for specific post id
                var post = await appDbContext.Product.FirstOrDefaultAsync(x => x.PostId == postId);

                if (post != null)
                {
                    //Delete that post
                    appDbContext.Product.Remove(post);

                    //Commit the transaction
                    result = await appDbContext.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task UpdateProduct(Inventoryes post)
        {
            if (appDbContext != null)
            {
                //Delete that post
                appDbContext.Product.Update(post);

                //Commit the transaction
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Inventoryes> GetProductById(int? postId)
        {
            if (appDbContext != null)
            {
                return await (from p in appDbContext.Product
                              
                              where p.PostId == postId
                              select new Inventoryes
                              {
                                  PostId = p.PostId,
                                  Title = p.Title,
                                  Description = p.Description,
                                  CategoryId = p.CategoryId,
                                  
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

       

    }
}
