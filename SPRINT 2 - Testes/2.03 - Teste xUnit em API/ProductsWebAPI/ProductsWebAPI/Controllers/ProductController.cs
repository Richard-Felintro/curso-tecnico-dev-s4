using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsWebAPI.Domains;
using ProductsWebAPI.Interfaces;
using ProductsWebAPI.Repositories;

namespace ProductsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductsRepository productRepository;
        public ProductController()
        {
            productRepository = new ProductRepository();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Products> list = productRepository.Get();
                return Ok(list);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Products p = productRepository.GetById(id);
                return Ok(p);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post(Products p)
        {
            try
            {
                productRepository.Post(p);
                return Ok(p);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Products p = productRepository.Delete(id);
                return Ok(p);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut]
        public IActionResult Put(Products p)
        {
            try
            {
                Products prod = productRepository.Put(p);
                return Ok(prod);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
