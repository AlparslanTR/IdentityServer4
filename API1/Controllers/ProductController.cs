using API1.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [Authorize(Policy = "ReadProduct")]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var productList = new List<Product>() { 
                new Product { Id = 1, Name = "Buzdolabı", Price = 2000, Stock = 100 },
                new Product { Id = 2, Name = "Bilgisayar", Price = 5000, Stock = 50 },
                new Product { Id = 3, Name = "Dolap", Price = 1500, Stock = 75 }
            };
            return Ok(productList);
        }

        [Authorize(Policy ="UpdateOrCreate")] // Program cs de verdiğimiz şartları bu api metotlarında kullanıyoruz.
        public IActionResult Update(int id)
        {
            return Ok($"id'si {id} olan ürün güncellenmiştir");
        }

        [Authorize(Policy = "UpdateOrCreate")]
        public IActionResult Create(Product product)
        {
            return Ok(product);
        }
    }
}
