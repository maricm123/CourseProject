using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _ctx;

        public UsersController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _ctx.Users;
            if (users is null)
            {
                throw new Exception("ASddD");

            }
            return users;
        }

        [HttpGet("{userId:int}")]
        public async Task<ActionResult<User>> GetById(int userId)
        {
            var user = await _ctx.Users.FindAsync(userId);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(User user)
        {
            _ctx.Users.Update(user);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{userId:int}")]
        public async Task<ActionResult> Delete(int userId)
        {
            var user = await _ctx.Users.FindAsync(userId);
            _ctx.Users.Remove(user);
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
