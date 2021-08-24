using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace toDoAPP.Models
{
    public partial class ToDoDBContext : DbContext
    {
        public ToDoDBContext()
        {
        }

        public ToDoDBContext(DbContextOptions<ToDoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Obaveze> Obavezes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=HP1708\\SQLEXPRESS;Database=To-Do-DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Obaveze>(entity =>
            {
                entity.HasKey(e => e.ObavezaId)
                    .HasName("PK__Obaveze__7140730DFE25312E");

                entity.ToTable("Obaveze");

                entity.Property(e => e.ObavezaId).HasColumnName("ObavezaID");

                entity.Property(e => e.DatIzvrsenja)
                    .HasColumnType("date")
                    .HasColumnName("Dat_izvrsenja");

                entity.Property(e => e.Kategorija).HasMaxLength(30);

                entity.Property(e => e.Naziv).HasMaxLength(30);

                entity.Property(e => e.Opis).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
