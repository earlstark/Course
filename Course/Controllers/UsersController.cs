using System.Numerics;
using Course.Data;
using Course.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private UserRepository _repository;

        public UsersController()
        {
            _repository = new UserRepository();
            /*Users = new List<User>()
            {
                new User() { Id = 1, FirstName = "Anna", LastName = "Teszt" },
                new User() { Id = 2, FirstName = "Péter", LastName = "Teszt" }
            };*/
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _repository.GetById(id);
            
            return user == null ? NotFound() : user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] User data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _repository.Create(data);

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User data)
        {
            User? user = _repository.Update(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var response = _repository.Delete(id);

            return response ? NoContent() : NotFound();
        }
    }
}
