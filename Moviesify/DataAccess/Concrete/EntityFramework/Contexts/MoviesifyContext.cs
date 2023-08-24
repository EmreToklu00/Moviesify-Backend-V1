using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class MoviesifyContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MoviesifyDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().HasKey(c => new { c.PublisherId });
            modelBuilder.Entity<Category>().HasKey(c => new { c.CategoryId });
            modelBuilder.Entity<Movie>().HasKey(c => new { c.MovieId });

            modelBuilder.Entity<Movie>().HasOne(m => m.Category).WithMany(c => c.Movies).HasForeignKey(m => m.CategoryId);
            modelBuilder.Entity<Movie>().HasOne(m => m.Publisher).WithMany(p => p.Movies).HasForeignKey(m => m.PublisherId);



        }


    }
}
