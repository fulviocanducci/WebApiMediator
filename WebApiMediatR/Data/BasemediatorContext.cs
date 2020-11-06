using Microsoft.EntityFrameworkCore;
using WebApiMediatR.Models;

namespace WebApiMediatR.Data
{
    public partial class BasemediatorContext : DbContext
    {
        public BasemediatorContext()
        {
        }

        public BasemediatorContext(DbContextOptions<BasemediatorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<People> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}