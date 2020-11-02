﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;

namespace WebApiMediator.Models
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
                entity.Property(e => e.Id).UseIdentityColumn();

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