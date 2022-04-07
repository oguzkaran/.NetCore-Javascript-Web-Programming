using System;
using CSD.PostalCodeSearchApp.Data.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CSD.PostalCodeSearchApp.Data.Repositories.Context
{
    public partial class PostalCodeSearchAppDbContext : DbContext
    {
        public PostalCodeSearchAppDbContext()
        {
        }

        //public PostalCodeSearchAppDbContext(DbContextOptions<PostalCodeSearchAppDbContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<PostalCode> PostalCodes { get; set; }
        public virtual DbSet<PostalCodeSearch> PostalCodeSearches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                return;
             
            optionsBuilder.UseSqlServer("Server = aws-mssql.cct1ehgoywdp.us-east-2.rds.amazonaws.com; Database = DCJSWPA21_PostalCodeSearchAppDb; User Id = admin; Password = csystem1993;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<PostalCode>(entity =>
            {
                entity.ToTable("PostalCode");

                entity.Property(e => e.AdminCode1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminCode2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminName1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminName2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Iso31662)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ISO31662");

                entity.Property(e => e.PlaceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode1).HasColumnName("PostalCode");

                entity.Property(e => e.PostalCodeUrl).IsUnicode(false);

                entity.HasOne(d => d.PostalCodeSearch)
                    .WithMany(p => p.PostalCodes)
                    .HasForeignKey(d => d.PostalCodeSearchId)
                    .HasConstraintName("FK__PostalCod__Posta__2C3393D0");
            });

            modelBuilder.Entity<PostalCodeSearch>(entity =>
            {
                entity.ToTable("PostalCodeSearch");

                entity.HasIndex(e => e.Q, "UQ__PostalCo__3BD019BFA5DF6AF0")
                    .IsUnique();

                entity.Property(e => e.Q)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SearchTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
