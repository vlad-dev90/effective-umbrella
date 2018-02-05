using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FanficSite.Models;



namespace FanficSite.Data
{
 
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Fanfic> Fanfics { get; set; }
        public DbSet<FanficTag> FanficTags { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            ConfigureFanficTag(modelBuilder);
            
            ConfigureFanficAuthor(modelBuilder);
            
            ConfigureVotes(modelBuilder);
            
            ConfigureChapters(modelBuilder);

            ConfigureComments(modelBuilder);

            ConfigureCommentLikes(modelBuilder);
        }

        private void ConfigureFanficTag(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FanficTag>()
                .HasKey(t => new { t.FanficId, t.TagId });
            
            modelBuilder.Entity<FanficTag>()
                .HasOne(pt => pt.Fanfic)
                .WithMany("FanficTags");
 
            modelBuilder.Entity<FanficTag>()
                .HasOne(pt => pt.Tag)
                .WithMany("FanficTags");
        }

        private void ConfigureFanficAuthor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(au => au.Fanfics)
                .WithOne(f => f.Author)
                .OnDelete(DeleteBehavior.SetNull);
        }

        private void ConfigureVotes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(au => au.Votes)
                .WithOne(v => v.Author)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Chapter>()
                .HasMany(c => c.Votes)
                .WithOne(v => v.Chapter)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureChapters(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fanfic>()
                .HasMany(f => f.Chapters)
                .WithOne(c => c.Fanfic)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureComments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(au => au.Comments)
                .WithOne(c => c.Author)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Author)
                .WithMany(a => a.Comments)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Fanfic>()
                .HasMany(f => f.Comments)
                .WithOne(c => c.Fanfic)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Fanfic)
                .WithMany(f => f.Comments)
                .OnDelete(DeleteBehavior.SetNull);
        }

        private void ConfigureCommentLikes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(au => au.CommentLikes)
                .WithOne(cl => cl.Author)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasMany(c => c.CommentLikes)
                .WithOne(cl => cl.Comment)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CommentLike>()
                .HasOne(cl => cl.Author)
                .WithMany(a => a.CommentLikes)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<CommentLike>()
                .HasOne(cl => cl.Comment)
                .WithMany(c => c.CommentLikes)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
