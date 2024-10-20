using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<Book> Books {get; set; }

        public DbSet<BookCategory> BookCategories {get; set; }

        public DbSet<BookReview> bookReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>()
                .HasMany(b => b.BookReviews)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookId)
                .IsRequired();

            builder.Entity<BookCategory>()
                .HasMany(c => c.Books)
                .WithOne(c => c.BookCategory)
                .HasForeignKey(c => c.BookCategoryId)
                .IsRequired();


            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "Reviewer",
                    NormalizedName = "REVIEWER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}