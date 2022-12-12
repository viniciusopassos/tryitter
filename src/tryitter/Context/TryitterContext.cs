using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tryitter.Models;
using Microsoft.EntityFrameworkCore;

namespace tryitter.Context
{
    public class TryitterContext : DbContext
    {
        public TryitterContext(DbContextOptions<TryitterContext> options) : base(options)
        {

        }

        public DbSet<Student> Students{ get; set; }
        public DbSet<Post> Posts{ get; set; }
    }
}