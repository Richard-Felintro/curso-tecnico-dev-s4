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
    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<User> _User;
        public UserController(MongoDBService mongoDBService)
        {
            _User = mongoDBService.GetDatabase.GetCollection<User>("user");
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            try
            {
                var Users = await _User.Find(FilterDefinition<User>.Empty).ToListAsync();
                return Ok(Users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User User)
        {
            try
            {
                await _User.InsertOneAsync(User);
                return Ok(User);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(string id)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(x => x.Id, id);
                var User = await _User.Find(filter).FirstOrDefaultAsync();
                return User == null ? NotFound() : Ok(User);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(User User)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(x => x.Id, User.Id);
                await _User.ReplaceOneAsync(filter, User);
                return User == null ? NotFound() : Ok(User);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUserById(string id)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(x => x.Id, id);
                if (filter == null)
                {
                    NotFound();
                }
                await _User.DeleteOneAsync(filter);
                return Ok(filter);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
