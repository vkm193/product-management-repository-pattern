using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Product.Service.Services.Products;
using Product.Service.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.Web.ApiController
{
    [Produces("application/json")]
    [Route("api/Product")]    
    public class ProductController : Controller
    {
        public IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        // GET: api/<controller>
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetAll()
        {
            List<ProductModel> products = productService.GetAll();
            //var settings = new JsonSerializerSettings { TypeNameHandBling = TypeNameHandling.Auto };

            return new JsonResult(products);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetById(Guid id)
        {
            ProductModel product = productService.GetById(id);
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

            return new JsonResult(product, settings);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Save([FromBody]ProductModel product)
        {
            productService.Save(product);
            return Ok("Added Successfully");
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Edit([FromBody]ProductModel product)
        {
            productService.Edit(product);
            return Ok("Updated Successfully");
        }

        // PUT api/<controller>
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult EditPrice(Guid id, decimal price)
        {
            productService.UpdatePrice(id,price);
            return Ok("Updated Successfully");
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Delete(Guid id)
        {
            productService.Delete(id);
            return Ok("Deleted Successfully");
        }
    }
}
