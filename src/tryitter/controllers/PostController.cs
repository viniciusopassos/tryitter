using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tryitter.Context;
using tryitter.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<ActionResult<Post>> Create(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }
    }
}