using tryitter.Context;
using tryitter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace tryitter.controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PostController : ControllerBase
    {
        private readonly TryitterContext _context;
        public PostController(TryitterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAll()
        {
            var posts = await _context.Posts.ToListAsync();

            if (posts == null) return NotFound("Posts Not Found!");

            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> Create(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetById", new { id = post.PostId}, post);
        }
    }
}