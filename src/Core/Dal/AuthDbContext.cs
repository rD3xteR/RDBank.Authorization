using Core.Dal.Models;

using Microsoft.EntityFrameworkCore;

namespace Core.Dal;

public class AuthDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("auth");
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Email).IsUnique();

            entity.HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .Property(e => e.Id)
                .HasColumnName("id");
            entity
                .Property(e => e.Email)
                .HasColumnName("email");
            entity
                .Property(e => e.Password)
                .HasColumnName("password");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.ToTable("user_profiles");

            entity.HasKey(x => x.Id);
            entity.HasIndex(e => e.UserId);

            entity
                .Property(e => e.Id)
                .HasColumnName("id");
            entity
                .Property(e => e.FirstName)
                .HasColumnName("first_name");
            entity
                .Property(e => e.LastName)
                .HasColumnName("last_name");
            entity
                .Property(e => e.Birthday)
                .HasColumnName("birthday");
            entity
                .Property(e => e.Phone)
                .HasColumnName("phone");
        });
    }
}
