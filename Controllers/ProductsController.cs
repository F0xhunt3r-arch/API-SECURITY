using Microsoft.AspNetCore.Mvc;
using API_SECURITY.Models;
using System.Collections.Generic;
using System.Linq;

namespace API_SECURITY.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Product1", Price = 10.0m },
            new Product { Id = 2, Name = "Product2", Price = 20.0m }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(Products);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Product> Get(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            product.Id = Products.Max(p => p.Id) + 1;
            Products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (product == null || product.Id != id)
            {
                return BadRequest();
            }

            var existingProduct = Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            Products.Remove(product);
            return NoContent();
        }
    }
}