using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ArvosteluRestApi.Models
{
    public partial class arvosteludbContext : DbContext
    {
        public arvosteludbContext()
        {
        }

        public arvosteludbContext(DbContextOptions<arvosteludbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arvostelut> Arvosteluts { get; set; }
        public virtual DbSet<Tuotteet> Tuotteets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-ANDN7RC\\SQLEXPRESS;Database=arvosteludb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arvostelut>(entity =>
            {
                entity.HasKey(e => e.ArviointiId);

                entity.ToTable("arvostelut");

                entity.Property(e => e.ArviointiId)
                    .ValueGeneratedNever()
                    .HasColumnName("arviointiId");

                entity.Property(e => e.Arvosana).HasColumnName("arvosana");

                entity.Property(e => e.TuoteId).HasColumnName("tuoteId");

                entity.HasOne(d => d.Tuote)
                    .WithMany(p => p.Arvosteluts)
                    .HasForeignKey(d => d.TuoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_arvostelut_tuotteet");
            });

            modelBuilder.Entity<Tuotteet>(entity =>
            {
                entity.HasKey(e => e.TuoteId);

                entity.ToTable("tuotteet");

                entity.Property(e => e.TuoteId)
                    .ValueGeneratedNever()
                    .HasColumnName("tuoteId");

                entity.Property(e => e.Hinta)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("hinta");

                entity.Property(e => e.Nimi)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nimi")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
