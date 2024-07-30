using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalApiMongo.Domains;
using minimalApiMongo.Services;
using minimalApiMongo.ViewModels;
using MongoDB.Driver;

namespace minimalApiMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _Order;
        private readonly IMongoCollection<Client> _Client;
        private readonly IMongoCollection<Product> _Product;
        public OrderController(MongoDBService mongoDBService)
        {
            _Order = mongoDBService.GetDatabase.GetCollection<Order>("order");
            _Client = mongoDBService.GetDatabase.GetCollection<Client>("client");
            _Product = mongoDBService.GetDatabase.GetCollection<Product>("product");
        }


        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAll()
        {
            try
            {
                var Orders = await _Order.Find(FilterDefinition<Order>.Empty).ToListAsync();
                return Ok(Orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Order>> AddOrder(OrderViewModel Order)
        {
            try
            {
                Order o = new Order()
                {
                    Date = Order.Date,
                    Status = Order.Status,
                    Client = await _Client.Find(x => x.Id == Order.ClientId).FirstOrDefaultAsync(),
                    Products = new List<Product>()
                };
                foreach (var item in Order.ProductId)
                {
                    o.Products.Add(await _Product.Find(x => x.Id == item).FirstOrDefaultAsync());
                }
                await _Order.InsertOneAsync(o);
                return Ok(o);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(string id)
        {
            try
            {
                var filter = Builders<Order>.Filter.Eq(x => x.Id, id);
                var Order = await _Order.Find(filter).FirstOrDefaultAsync();
                return Order == null ? NotFound() : Ok(Order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(OrderViewModel Order, string id)
        {
            try
            {
                var filter = Builders<Order>.Filter.Eq(x => x.Id, Order.Id);
                Order o = new Order()
                {
                    Id = id,
                    Date = Order.Date,
                    Status = Order.Status,
                    Client = await _Client.Find(x => x.Id == Order.ClientId).FirstOrDefaultAsync(),
                    Products = new List<Product>(),
                    AdditionalAttributes = Order.AdditionalAttributes
                };
                foreach (var item in Order.ProductId)
                {
                    o.Products.Add(await _Product.Find(x => x.Id == item).FirstOrDefaultAsync());
                }
                await _Order.ReplaceOneAsync(filter, o);
                return Order == null ? NotFound() : Ok(o);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrderById(string id)
        {
            try
            {
                var filter = Builders<Order>.Filter.Eq(x => x.Id, id);
                if (filter == null)
                {
                    NotFound();
                }
                await _Order.DeleteOneAsync(filter);
                return Ok(filter);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
