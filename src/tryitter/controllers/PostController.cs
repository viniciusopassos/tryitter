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
            try
            {
                var posts = await _context.Posts.ToListAsync();
                return Ok(posts);
            }
            catch (InvalidOperationException err)
            {
                Console.WriteLine(err.Message);
                return NotFound("Posts Not Found!");
            }              
        }

        [HttpGet("{postId}")]
        public async Task<ActionResult<Post>> GetById(int postId)
        {
            try
            {
                var post = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == postId);
                return Ok(post);
            }
            catch (InvalidOperationException err)
            {
                Console.WriteLine(err.Message);
                return NotFound("Post Not Found!");
            }   
        }

        [HttpGet("AllByStudent/{studentId}")]
        public async Task<ActionResult<List<Post>>> GetAllPostsByStudent(int studentId)
        {
            var studentAllPosts = await _context.Posts.Where(s => s.StudentId == studentId).ToListAsync();

            if (studentAllPosts.Count == 0) return NotFound("Posts Not Found!");

            return Ok(studentAllPosts);
        }

        [HttpPut("{postId}")]
        public async Task<ActionResult<Post>> Update(int postId, Post post)
        {
            var postBD = await _context.Posts.FirstAsync(s => s.PostId == postId);

            if (post == null) return NotFound("Post Not Found!");

            postBD.Url = post.Url;
            postBD.Content = post.Content;

            await _context.SaveChangesAsync();
            return Ok(postBD);
        }

        [HttpDelete("{postId}")]
        public async Task<ActionResult<Post>> Delete(int postId)
        {
            var post = await _context.Posts.FirstAsync(s => s.PostId == postId);

            if (post == null) return NotFound("Post Not Found!");

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> Create(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return Ok(post);
        }
    }
}