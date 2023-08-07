using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DynamicFormAPI.Models
{
    public partial class sdirectdbContext : DbContext
    {
        public sdirectdbContext()
        {
        }

        public sdirectdbContext(DbContextOptions<sdirectdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AstitvaStudents508> AstitvaStudents508s { get; set; } = null!;
        public virtual DbSet<AstitvaSubjects508> AstitvaSubjects508s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.0.240;Database=sdirectdb;User ID=sdirectdb;Password=sdirectdb;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AstitvaStudents508>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__AstitvaS__32C52B9982E75E3A");

                entity.ToTable("AstitvaStudents508");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AstitvaSubjects508>(entity =>
            {
                entity.ToTable("AstitvaSubjects508");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AstitvaSubjects508s)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AstitvaSu__Stude__5972B0A0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
