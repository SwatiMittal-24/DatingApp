using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> getMembers()
        {
            var members = await context.Users.ToListAsync();
            return members;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> getMember(string id)
        {
            var member = await context.Users.FindAsync(id);
            if(member == null)
            {
                return NotFound();
            }
            return member;
        }
    }
}
