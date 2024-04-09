using demo_api.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demo_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return UserRepo.GetRandomUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return UserRepo.GetUserById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public User Post([FromBody] User user)
        {
            return UserRepo.AddUser(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public User Put(int id, [FromBody] User user)
        {
            return UserRepo.UpdateUser(id, user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Assuming UserRepo.RemoveUser(id) handles user removal logic
            if (UserRepo.RemoveUser(id))
            {
                return Ok(new { message = "deleted successfully" });
            }
            else
            {
                return NotFound(); // User not found
            }
        }

       /* [HttpPost("login")]
        public User Login([FromBody] LoginModel user)
        {
            return UserRepo.Login(user);
        }*/

    }
}
