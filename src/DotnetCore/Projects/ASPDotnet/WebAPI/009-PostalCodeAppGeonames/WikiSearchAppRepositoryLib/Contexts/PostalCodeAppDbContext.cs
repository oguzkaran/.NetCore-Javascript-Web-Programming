using System;
using CSD.PostalCodeApp.Data.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CSD.PostalCodeApp.Data.Repositories.Context
{
    public partial class PostalCodeAppDbContext : DbContext
    {
        public PostalCodeAppDbContext()
        {
        }

        public PostalCodeAppDbContext(DbContextOptions<PostalCodeAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Geoname> Geonames { get; set; }
        public virtual DbSet<PostalCodeInfo> PostalCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            //optionsBuilder.UseSqlServer("Server = aws-mssql.cct1ehgoywdp.us-east-2.rds.amazonaws.com; Database = DCJSWPA21_PostalCodeAppDb; User Id = admin; Password = csystem1993;");
            optionsBuilder.UseSqlServer("Server=.;Database=DCJSWPA21_PostalCodeAppDb;Trusted_Connection=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Geoname>(entity =>
            {
                entity.ToTable("Geoname");

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

                entity.Property(e => e.PostalCodeUrl).IsUnicode(false);

                entity.HasOne(d => d.Search)
                    .WithMany(p => p.Geonames)
                    .HasForeignKey(d => d.SearchId)
                    .HasConstraintName("FK__Geoname__SearchI__3B75D760");
            });

            modelBuilder.Entity<PostalCodeInfo>(entity =>
            {
                entity.ToTable("PostalCodeInfo");

                entity.HasIndex(e => e.PostalCode, "UQ__PostalCo__12D1DBD2D35E0836")
                    .IsUnique();

                entity.Property(e => e.SearchTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
