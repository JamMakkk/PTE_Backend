using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DataContext.PTEContext;

public partial class PTEContext : DbContext
{
    public PTEContext()
    {
    }

    public PTEContext(DbContextOptions<PTEContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RepeatSentence> RepeatSentences { get; set; }

    public virtual DbSet<WriteFromDictation> WriteFromDictations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=pte_db;username=root;password=488255", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.42-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<RepeatSentence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("repeat_sentence");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.IsTested)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_tested");
            entity.Property(e => e.SeqNo).HasColumnName("seq_no");
        });

        modelBuilder.Entity<WriteFromDictation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("write_from_dictation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.IsTested)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_tested");
            entity.Property(e => e.SeqNo).HasColumnName("seq_no");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
