using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using wrBlogs.Net.Model;

namespace wrBlogs.Net.Context
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) 
            : base(options)
        {
            
        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");

            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<User>().Property(x => x.UserName).HasMaxLength(20);
            builder.Entity<User>().Property(x => x.LoginCode).HasMaxLength(20);
            builder.Entity<User>().Property(x => x.LoginPwd).HasMaxLength(50);
            builder.Entity<User>().Property(x => x.IP).HasMaxLength(50);

            base.OnModelCreating(builder);
        }
    }
}
