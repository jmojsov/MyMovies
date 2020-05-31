using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyMovies.Data
{
    public partial class MyMoviesContext : DbContext
    {
        public MyMoviesContext(DbContextOptions<MyMoviesContext> options) : base(options)
        {
        }

       

        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
