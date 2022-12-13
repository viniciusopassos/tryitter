using tryitter.Context;
using tryitter.Models;
using Microsoft.AspNetCore.Mvc;
using tryitter.Requesties;
using Microsoft.EntityFrameworkCore;
using tryitter.Services;

namespace tryitter.controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StudentController : ControllerBase
    {
        private readonly TryitterContext _context;
        public StudentController(TryitterContext context)
        {
            _context = context;
        }

        [HttpPost("/Login")]
        public async Task<ActionResult<Authentication>> Login(StudentLogin login)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Email == login.Email);

            if(student == null || student.Password != login.Password) throw new DbUpdateException("Student not found!");

            var token = new TokenGenerator().Generate(student);
            var newAuthentication = new Authentication { Token = token };

            return Ok(newAuthentication);
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAll()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Create(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }
    }
}