using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalApiMongo.Domains;
using minimalApiMongo.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace minimalApiMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IMongoCollection<Product> _product;
        public ProductController(MongoDBService mongoDBService)
        {
            _product = mongoDBService.GetDatabase.GetCollection<Product>("product");
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            try
            {
                var products = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            try
            {
                await _product.InsertOneAsync(product);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
                var product = await _product.Find(filter).FirstOrDefaultAsync();
                return product == null ? NotFound() : Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq(x => x.Id, product.Id);
                await _product.ReplaceOneAsync(filter, product);
                return product == null ? NotFound() : Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProductById(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
                if (filter == null)
                {
                    NotFound();
                }
                await _product.DeleteOneAsync(filter);
                return Ok(filter);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}