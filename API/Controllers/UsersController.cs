using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // localhost:$port/api/users    -> users : matches the UsersController prefix which is users without controller keyword
    public class UsersController : ControllerBase
    {
        private readonly DataContext context;

        // will create an instance of DataContext
        public UsersController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]   // GET
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        [HttpGet("{id}")]   // localhost.../api/users/{id}
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await context.Users.FindAsync(id);
        }
    }
}