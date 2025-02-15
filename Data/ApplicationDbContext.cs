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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Tambahkan peran default saat database dibuat
            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.Role)
                .IsUnique(false);
        }
    }
}
