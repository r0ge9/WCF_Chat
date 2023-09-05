using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChatAPI.Models;

public partial class ChatDbContext : DbContext
{
    public ChatDbContext()
    {
    }

    public ChatDbContext(DbContextOptions<ChatDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dialog> Dialogs { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ChatDB;AttachDbFilename=|DataDirectory|\\Data\\ChatDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dialog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Dialog__3214EC07070AFD61");

            entity.ToTable("Dialog");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FirstUser).WithMany(p => p.DialogFirstUsers)
                .HasForeignKey(d => d.FirstUserId)
                .HasConstraintName("FK__Dialog__FirstUse__01142BA1");

            entity.HasOne(d => d.SecondUser).WithMany(p => p.DialogSecondUsers)
                .HasForeignKey(d => d.SecondUserId)
                .HasConstraintName("FK__Dialog__SecondUs__02084FDA");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Message__3214EC0744A48EFB");

            entity.ToTable("Message");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IP");
            entity.Property(e => e.IsRead).HasColumnName("isRead");
            entity.Property(e => e.IsVisibleFirstUser)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("isVisibleFirstUser");
            entity.Property(e => e.IsVisibleSecondUser)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("isVisibleSecondUser");
            entity.Property(e => e.SendDateTime).HasColumnType("smalldatetime");
            entity.Property(e => e.ToUserId).HasColumnName("toUserId");

            entity.HasOne(d => d.Dialog).WithMany(p => p.Messages)
                .HasForeignKey(d => d.DialogId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Message__DialogI__07C12930");

            entity.HasOne(d => d.ToUser).WithMany(p => p.MessageToUsers)
                .HasForeignKey(d => d.ToUserId)
                .HasConstraintName("FK__Message__toUserI__09A971A2");

            entity.HasOne(d => d.User).WithMany(p => p.MessageUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Message__UserId__08B54D69");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07C4742625");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.IsOnline).HasColumnName("isOnline");
            entity.Property(e => e.LastTimeOnline).HasColumnType("smalldatetime");
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Username).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
