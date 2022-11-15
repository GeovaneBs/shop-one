using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using UserManager.Models;
using UserManager.Persistence;

namespace UserManager.Controllers
{
    [Route("api/[Controller]")]
    public class UserController : Controller
    {
        private readonly UserManagerDbContext _userManagerDbContext;

        public UserController(UserManagerDbContext userManagerDbContext)
        {
            _userManagerDbContext = userManagerDbContext;
        }

        // GET: UserController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUsers()
        {
            return await _userManagerDbContext.User.ToListAsync();
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var product = _userManagerDbContext.User.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET: UserController/Create
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserInputModel user)
        {
            if (user == null)
                return BadRequest("Usuário Invalido");

            var newUser = new UserModel(user.Name, user.Email, user.Password);

            _userManagerDbContext.User.Add(newUser);
            _userManagerDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
        }
    }
}
