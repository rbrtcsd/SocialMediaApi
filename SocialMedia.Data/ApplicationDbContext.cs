using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Data.Entities;

namespace SocialMedia.Data;

public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
{
    public DbSet<PostEntity> Posts { get; set; }
    public DbSet<CommentsEntity> Comments { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }

    public ApplicationDbContext()
    {
    }

    public DbSet<RepliesEntity> Replies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserEntity>().ToTable("Users");

        modelBuilder.Entity<CommentsEntity>()
            .HasOne(ce => ce.User) // Specifies that Comment has one User
            .WithMany() // Specifies that User has many Comments (no navigation property back)
            .HasForeignKey(ce => ce.UserId) // Specifies the foreign key in Comment
            .OnDelete(DeleteBehavior.Restrict); // This prevents cascading deletes

        modelBuilder.Entity<CommentsEntity>()
            .HasOne(ce => ce.Post) // Specifies that Comment has one Post
            .WithMany(pe => pe.Comments) // Specifies that Post has many Comments
            .HasForeignKey(ce => ce.PostId) // Specifies the foreign key in Comment
            .OnDelete(DeleteBehavior.Restrict); // This can also prevent cascading deletes 
    }
}