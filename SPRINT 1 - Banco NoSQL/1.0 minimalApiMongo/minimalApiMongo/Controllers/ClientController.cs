using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalApiMongo.Domains;
using minimalApiMongo.Services;
using MongoDB.Driver;

namespace minimalApiMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClientController : ControllerBase
    {
        private readonly IMongoCollection<Client> _Client;
        public ClientController(MongoDBService mongoDBService)
        {
            _Client = mongoDBService.GetDatabase.GetCollection<Client>("client");
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetAll()
        {
            try
            {
                var Clients = await _Client.Find(FilterDefinition<Client>.Empty).ToListAsync();
                return Ok(Clients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Client>> AddClient(Client Client)
        {
            try
            {
                await _Client.InsertOneAsync(Client);
                return Ok(User);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientById(string id)
        {
            try
            {
                var filter = Builders<Client>.Filter.Eq(x => x.Id, id);
                var Client = await _Client.Find(filter).FirstOrDefaultAsync();
                return Client == null ? NotFound() : Ok(Client);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> UpdateClient(Client Client)
        {
            try
            {
                var filter = Builders<Client>.Filter.Eq(x => x.Id, Client.Id);
                await _Client.ReplaceOneAsync(filter, Client);
                return Client == null ? NotFound() : Ok(Client);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClientById(string id)
        {
            try
            {
                var filter = Builders<Client>.Filter.Eq(x => x.Id, id);
                if (filter == null)
                {
                    NotFound();
                }
                await _Client.DeleteOneAsync(filter);
                return Ok(filter);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
