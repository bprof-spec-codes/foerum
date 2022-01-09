using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using MySql.Data.MySqlClient;
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
                var builder = new SqlConnectionStringBuilder("server=95.111.254.24;database=foerumtst;user=foerumtst");
                builder.Password = ConnectionStrinPassword;
                var serverVersion = ServerVersion.AutoDetect(builder.ConnectionString);
                optionsBuilder.UseMySql(builder.ConnectionString, serverVersion);
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

            // User Roles
            modelBuilder.Entity<MyUserRoles>(e =>
            {
                e.HasOne(mur => mur.User)
                 .WithMany(u => u.Role)
                 .HasForeignKey(mur=>mur.UserID);
            });

            // Comment-User
            modelBuilder.Entity<CommentReacters>(entity =>
            {
                entity
                .HasKey(commentReacters => new { commentReacters.CommentID, commentReacters.UserID });
            });
            modelBuilder.Entity<CommentReacters>(entity =>
            {
                entity
                .HasOne(commentReacters => commentReacters.Comment)
                .WithMany(comment => comment.Reacters)
                .HasForeignKey(commentReacters => commentReacters.CommentID);
            });
            modelBuilder.Entity<CommentReacters>(entity =>
            {
                entity
                .HasOne(commentReacters => commentReacters.User)
                .WithMany(user => user.Comments)
                .HasForeignKey(commentReacters => commentReacters.UserID);
            });

            // Subject-User
            modelBuilder.Entity<SubjectUsers>(entity =>
            {
                entity
                .HasKey(subjectUsers => new { subjectUsers.SubjectID, subjectUsers.UserID });
            });
            modelBuilder.Entity<SubjectUsers>(entity =>
            {
                entity
                .HasOne(subjectUsers => subjectUsers.Subject)
                .WithMany(subject => subject.Users)
                .HasForeignKey(subjectUsers => subjectUsers.SubjectID);
            });
            modelBuilder.Entity<SubjectUsers>(entity =>
            {
                entity
                .HasOne(subjectUsers => subjectUsers.User)
                .WithMany(user => user.Subjects)
                .HasForeignKey(subjectUsers => subjectUsers.UserID);
            });

            // Topic-Tag
            modelBuilder.Entity<TopicTags>(entity =>
            {
                entity
                .HasKey(topicTags => new { topicTags.TopicID, topicTags.TagID });
            });
            modelBuilder.Entity<TopicTags>(entity =>
            {
                entity
                .HasOne(topicTags => topicTags.Topic)
                .WithMany(topic => topic.Tags)
                .HasForeignKey(topicTags => topicTags.TopicID);
            });
            modelBuilder.Entity<TopicTags>(entity =>
            {
                entity
                .HasOne(topicTags => topicTags.Tag)
                .WithMany(user => user.Topics)
                .HasForeignKey(topicTags => topicTags.TagID);
            });
        }
        public virtual DbSet<Models.MyRole> MyRole { get; set; }
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
