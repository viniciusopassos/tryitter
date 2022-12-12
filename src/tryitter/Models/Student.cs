using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tryitter.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string CurrentModule { get; set; } = default!;
        public string status { get; set; } = default!;
        [InverseProperty("Student")]
        public virtual ICollection<Post> Posts { get; } = default!;
    }
}