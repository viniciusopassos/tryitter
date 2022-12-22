using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        public string Status { get; set; } = default!;
        [JsonIgnore]
        public ICollection<Post>? Posts { get; }
    }
}