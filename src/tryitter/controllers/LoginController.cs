using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tryitter.Context;
using tryitter.Requesties;
using tryitter.Services;

namespace tryitter.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly TryitterContext _context;
        public LoginController(TryitterContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Authentication>> Login(StudentLogin login)
        {
            try
            {
                var student = await _context.Students.FirstOrDefaultAsync(x => x.Email == login.Email);
                if(student == null || student.Password != login.Password) throw new DbUpdateException("Email or Password invalid!");

                var token = new TokenGenerator().Generate(student);
                var newAuthentication = new Authentication { Token = token };

                return Ok(newAuthentication);
            }
            catch (DbUpdateException err)
            {
                Console.WriteLine(err.Message);
                return NotFound("Email or Password invalid!");
            }
        }
    }
}