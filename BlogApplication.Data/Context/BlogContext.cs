using BlogApplication.Data.Model.DataModel;
using BlogApplication.Model;
using BlogApplication.Model.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace BlogApplication.Data.Context
{
    public class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Teg> Tegs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("users");
            builder.Entity<Article>().ToTable("articles");
            builder.Entity<Teg>().ToTable("tegs");
            builder.Entity<Comment>().ToTable("comment");
            builder.Entity<Role>().ToTable("rolses");

            builder.Entity<Comment>()
                .HasOne(a => a.User)
                .WithMany(b => b.Comments)
                .HasForeignKey(c => c.User_Id)
                .HasPrincipalKey(d => d.Id)
                .IsRequired(false);
        }
    }
}
