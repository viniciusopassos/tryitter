using tryitter.Context;
using tryitter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAll()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            try
            {
                var student = await _context.Students.Where(s => s.StudentId == id).FirstAsync();
                return Ok(student);
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

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> Update(int id, Student student)
        {
            try
            {
                var studentBD = await _context.Students.FirstAsync(s => s.StudentId == id);

                if (studentBD == null) throw new ArgumentException("Student Not Found!");

                studentBD.Name = student.Name;
                studentBD.Email = student.Email;
                studentBD.Password = student.Password;
                studentBD.CurrentModule = student.CurrentModule;
                studentBD.status = student.status;

                _context.Students.Update(studentBD);
                await _context.SaveChangesAsync();
                return Ok(studentBD);
            }
            catch (InvalidOperationException err)
            {
                Console.WriteLine(err.Message);
                return NotFound("Student Not Found!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Remove(int id)
        {
            try
            {
                var student = await _context.Students.Where(s => s.StudentId == id).FirstAsync();

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
    }
}