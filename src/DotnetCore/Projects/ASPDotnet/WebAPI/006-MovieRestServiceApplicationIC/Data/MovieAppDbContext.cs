using CSD.MovieRestServiceApplication.Data.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CSD.MovieRestServiceApplication.Data
{
    public partial class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext()
        {
        }

        public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieToDirector> MovieToDirectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;
            
            optionsBuilder.UseSqlServer("Server = aws-mssql.cct1ehgoywdp.us-east-2.rds.amazonaws.com; Database = DCJSWPA21_MovieAppDb; User Id = admin; Password = csystem1993;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("Director");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Imdb).HasDefaultValueSql("((0.0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Rating).HasDefaultValueSql("((0))");

                entity.Property(e => e.SceneDate).HasColumnType("date");
            });

            modelBuilder.Entity<MovieToDirector>(entity =>
            {
                entity.ToTable("MovieToDirector");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.MovieToDirectors)
                    .HasForeignKey(d => d.DirectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MovieToDi__Direc__3D5E1FD2");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieToDirectors)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MovieToDi__Movie__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
