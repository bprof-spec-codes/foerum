using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace Data
{
      public class FoerumDbContext : IdentityDbContext<IdentityUser>
      {
            private readonly string ConnectionStrinPassword;

            public FoerumDbContext(string connectpw)
            {
                  this.ConnectionStrinPassword = connectpw;
                  this.Database.EnsureCreated();
            }
            public FoerumDbContext()
            {
                  this.Database.EnsureCreated();
            }

            public FoerumDbContext(DbContextOptions<FoerumDbContext> opt) : base(opt)
            {

            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                  if (!optionsBuilder.IsConfigured)
                  {
                        var builder = new SqlConnectionStringBuilder("server=95.111.254.24:6767;database=foerumtst;user=foerumtst");
                        builder.Password = ConnectionStrinPassword;
                        optionsBuilder.UseMySQL(builder.ConnectionString);
                  }
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                  base.OnModelCreating(modelBuilder);


                  modelBuilder.Entity<IdentityRole>().HasData(
                      new { Id = "27b787da-9626-4302-9dfc-a66675a440db", Name = "Admin", NormalizedName = "ADMIN" },
                      new { Id = "d2b948cc-8ba9-4ad4-b1d0-958432e22d2e", Name = "Moderator", NormalizedName = "MODERATOR" },
                      new { Id = "d2b948cc-8ba9-4ad4-b1b0-958432e22d3e", Name = "User", NormalizedName = "USER" }
                  );
            }
            public virtual DbSet<Models.Award> Award { get; set; }
            public virtual DbSet<Models.Comment> Comment { get; set; }
            public virtual DbSet<Models.CommentReacters> CommentReacters { get; set; }
            public virtual DbSet<Models.MyUser> MyUser { get; set; }
            public virtual DbSet<Models.Subject> Subject { get; set; }
            public virtual DbSet<Models.SubjectUsers> SubjectUsers { get; set; }
            public virtual DbSet<Models.Tag> Tag { get; set; }
            public virtual DbSet<Models.Topic> Topic { get; set; }
            public virtual DbSet<Models.TopicTags> TopicTags { get; set; }
            public virtual DbSet<Models.Transaction> Transaction { get; set; }
            public virtual DbSet<Models.Year> Year { get; set; }
      }
}
