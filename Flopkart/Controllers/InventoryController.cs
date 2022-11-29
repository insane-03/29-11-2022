
using Flopkart_Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.ComponentModel.DataAnnotations;

using Flopkart_Model;

using Microsoft.Extensions.Logging;

namespace Flopkart.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]

    public class InventoryController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly ILogger<InventoryController> _logger;
        public InventoryController(IProductService productService,ILogger<InventoryController> logger) 
        {
            _logger= logger;
            _productService= productService;
        }


        [HttpGet("GetAllProducts")]

        public List<ProductModel> GetProducts()
        {
            try
            {

                
                return _productService.GetAllProducts();

            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
        }

        [HttpGet("GetProduct/{ProductId}")]

        public IActionResult GetProduct(int ProductId)
        {
            try
            {
                if (ProductId != null)
                {
                    return Ok(_productService.GetItem(ProductId));
                }
                return NotFound();


            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
        }

        [HttpPost("PostProduct")]

        public IActionResult PostProduct([FromBody] ProductModel product)
        {
            try
            {
                if (product != null)
                {
                    return Ok(_productService.AddProduct(product));
                }
                return NotFound();


            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
        }

        [HttpPut("UpdateProduct/{ProductId}")]

        public IActionResult UpdateProduct([FromBody] ProductModel product, int ProductId)
        {
            try
            {
                if (product != null)
                {
                    return Ok(_productService.ChangeProduct(product, ProductId));
                }
                return NotFound();


            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
        }

        [HttpDelete("DeleteProduct/{ProductId}")]

        public IActionResult DeleteProduct(int ProductId)
        {
            try
            {
                if (ProductId != null)
                {
                    return Ok(_productService.DeleteItem(ProductId));
                }
                return NotFound();


            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
        }

        

    }
}
