using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Controllers
{
    [Route("api/products")]
    
    public class ProductsController : Controller
    {
        private IProductManagementRepository _repository;

        public ProductsController(IProductManagementRepository repository)
        {
            _repository = repository;
        }

        // GET api/products
        [HttpGet]
        public List<Product> Get()
        {
            return _repository.GetAllProducts();
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _repository.GetProductById(id);
        }

        //POST api/products/addNewProduct
        [HttpOptions("addNewProduct")]
        [HttpPost("addNewProduct")]
        public JsonResult addNewProduct([FromBody]Product product)
        {
            return _repository.AddNewProduct(product) == true ? Json("Everything ok") : Json("Error occured");
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Put(int id, [FromBody]Review review)
        {
            return await _repository.UpdateReviews(id, review) == true ? Json("Everything ok") : Json("Error occured");
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteProduct(id);
        }
    }
}
