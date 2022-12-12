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
    public class StudentController : ControllerBase
    {
        private readonly TryitterContext _context;
        public StudentController(TryitterContext context)
        {
            _context = context;
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