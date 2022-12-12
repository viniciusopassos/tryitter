using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tryitter.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [MaxLength(300, ErrorMessage="Text must be a maximum of 300 characters")]
        public string Content { get; set; } = default!;
        public string Url { get; set; } = default!;
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; } = default!;
    }
}