using Microsoft.EntityFrameworkCore;
using tryitter.Models;

namespace tryitter.Test
{
    public class TryitterTestContext : DbContext
    {
        public TryitterTestContext(DbContextOptions<TryitterTestContext> options) : base(options)
        {

        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}