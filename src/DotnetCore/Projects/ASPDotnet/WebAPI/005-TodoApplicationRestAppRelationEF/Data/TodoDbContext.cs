using CSD.TodoApplicationRestApp.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CSD.TodoApplicationRestApp.Data
{
    public partial class TodoDbContext : DbContext
    {
        public TodoDbContext()
        {
        }

        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ItemInfo> ItemInfos { get; set; }
        public virtual DbSet<TodoInfo> TodoInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;            

            optionsBuilder.UseSqlServer("Server=.;Database=TodoDb;Trusted_Connection=True;");            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ItemInfo>(entity =>
            {
                entity.ToTable("ItemInfo");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Text).IsRequired();

                entity.HasOne(d => d.Todo)
                    .WithMany(p => p.ItemInfos)
                    .HasForeignKey(d => d.TodoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemInfo__TodoId__4BAC3F29");
            });

            modelBuilder.Entity<TodoInfo>(entity =>
            {
                entity.ToTable("TodoInfo");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
