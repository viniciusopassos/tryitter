using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tryitter.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [MaxLength(300, ErrorMessage="Text must be a maximum of 300 characters")]
        public string Content { get; set; } = default!;
        public string Url { get; set; } = default!;
        public int StudentId { get; set; }
        [JsonIgnore]
        public Student? Student { get; set; }
    }
}