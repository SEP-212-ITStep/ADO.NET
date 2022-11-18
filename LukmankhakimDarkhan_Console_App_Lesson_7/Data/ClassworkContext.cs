using System;
using System.Collections.Generic;
using LukmankhakimDarkhan_Console_App_Lesson_7.Models;
using Microsoft.EntityFrameworkCore;

namespace LukmankhakimDarkhan_Console_App_Lesson_7.Data;

public partial class ClassworkContext : DbContext
{
    public ClassworkContext()
    {
    }

    public ClassworkContext(DbContextOptions<ClassworkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Table> Tables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=223-5;Initial Catalog=Classwork;Trusted_Connection=true;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Table");

            entity.Property(e => e.AverageMark)
                .HasMaxLength(50)
                .HasColumnName("average_mark");
            entity.Property(e => e.Maxave)
                .HasMaxLength(50)
                .HasColumnName("maxave");
            entity.Property(e => e.Minave)
                .HasMaxLength(50)
                .HasColumnName("minave");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Namegroup)
                .HasMaxLength(50)
                .HasColumnName("namegroup");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
