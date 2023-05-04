using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [Authorize]         // only allow pass authorization
    public class UsersController : BaseAPIController
    {
        private readonly DataContext _context;

        // will create an instance of DataContext
        public UsersController(DataContext context)
        {
            this._context = context;
        }

        [AllowAnonymous]
        [HttpGet]   // GET
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]   // localhost.../api/users/{id}
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}