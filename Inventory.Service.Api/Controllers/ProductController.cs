using Inventory.Service.Domain;
using Inventory.Service.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Inventory.Service.Api.Controllers
{
    [ApiController]
    
    //[Authorize]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        

        private readonly ILogger<ProductController> _logger;

       
        private readonly IRepositorie _ProductRepositories1;
        public ProductController(ILogger<ProductController> logger, IRepositorie Repositorie)
        {
            _logger = logger;
            
            _ProductRepositories1 = Repositorie;
        }

        

        [HttpGet]
        [Route("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var categories = await _ProductRepositories1.GetProduct();
                if (categories == null)
                {
                    return NotFound();
                }
                _logger.LogInformation("Data Retuen sucessfully");
                return Ok(categories);
            }
            catch (Exception ex )
            {
                _logger.LogInformation(ex.Message);
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Inventoryes model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _ProductRepositories1.AddProduct(model);
                    if (postId > 0)
                    {
                        _logger.LogInformation(postId.ToString());
                        return Ok(postId);
                    }
                    else
                    {
                        _logger.LogInformation("NotFound");
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                    return BadRequest();
                }

            }
            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Inventoryes model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _ProductRepositories1.UpdateProduct(model);

                    return Ok();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        _logger.LogInformation(ex.Message);
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }


        [HttpGet]
        [Route("GetProductById")]
        public async Task<IActionResult> GetProductById(int? postId)
        {
            if (postId == null)
            {
                _logger.LogInformation("No data ");
                return BadRequest();
            }

            try
            {
                var post = await _ProductRepositories1.GetProductById(postId);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest();
            }
        }

       

        [HttpPost]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int? postId)
        {
            int result = 0;

            if (postId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _ProductRepositories1.DeleteProduct(postId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
