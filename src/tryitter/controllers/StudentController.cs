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

            if(student == null || student.Password != login.Password) throw new DbUpdateException("Student Not Found!");

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

        [HttpGet("{studentId}")]
        public async Task<ActionResult<Student>> GetById(int studentId)
        {
            try
            {
                var student = await _context.Students.Where(s => s.StudentId == studentId).FirstAsync();
                return Ok(student);
            }
            catch (InvalidOperationException err)
            {
                Console.WriteLine(err.Message);
                return NotFound("Student Not Found!");
            }   

        }

        [HttpPut("{studentId}")]
        public async Task<ActionResult<Student>> Update(int studentId, Student student)
        {
            try
            {
                var studentDb = await _context.Students.FirstAsync(s => s.StudentId == studentId);

                if(studentDb == null) throw new ArgumentException("Student Not Found!");

                studentDb.Name = student.Name;
                studentDb.Email = student.Email;
                studentDb.Password = student.Password; 
                studentDb.CurrentModule = student.CurrentModule;
                studentDb.status = student.status;

                _context.Students.Update(studentDb);
                await _context.SaveChangesAsync();
                return Ok(studentDb);
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                return NotFound("Student Not Found!");
            }
        }

        [HttpDelete("{studentId}")]
        public async Task<ActionResult<Student>> Remove(int studentId)
        {
            try
            {
                var student = await _context.Students.Where(s => s.StudentId == studentId).FirstAsync();

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (InvalidOperationException err)
            {
                Console.WriteLine(err.Message);
                return NotFound("Student Not Found!");
            }
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