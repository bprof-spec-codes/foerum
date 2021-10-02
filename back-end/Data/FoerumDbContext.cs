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
                        var builder = new SqlConnectionStringBuilder("server=95.111.254.24;database=projektmunka;user=projektmunka");
                        builder.Password = ConnectionStrinPassword;
                        optionsBuilder.UseMySQL(builder.ConnectionString);
                  }
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                  base.OnModelCreating(modelBuilder);


                  modelBuilder.Entity<IdentityRole>().HasData(
                      new { Id = "27b787da-9626-4302-9dfc-a66a75a440db", Name = "Admin", NormalizedName = "ADMIN" },
                      new { Id = "d2b948cc-8ba9-4ad4-b1b0-958432e22d2e", Name = "Editor", NormalizedName = "EDITOR" },
                       new { Id = "817910e3-aa52-4dc6-976d-a74231aefe95", Name = "Hök", NormalizedName = "HÖK" },
                        new { Id = "886dea29-a9de-4a6a-9805-03391e8d7dec", Name = "Szenátus", NormalizedName = "SZENÁTUS" },
                      new { Id = "0d301757-99d2-4253-aac2-39e298dd0ab7", Name = "Hallgató", NormalizedName = "HALLGATÓ" }
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
