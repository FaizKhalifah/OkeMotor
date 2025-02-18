using Microsoft.EntityFrameworkCore;
using OkeMotor.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OkeMotor.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Motor> motors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Tambahkan peran default saat database dibuat
            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.Role)
                .IsUnique(false);

            builder.Entity<Motor>()
            .HasOne(m => m.Seller)
            .WithMany(u => u.Motors)
            .HasForeignKey(m => m.SellerId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
