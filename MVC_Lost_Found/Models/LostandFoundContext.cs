using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_Lost_Found.Models;

public partial class LostandFoundContext : DbContext
{
    public LostandFoundContext()
    {
    }

    public LostandFoundContext(DbContextOptions<LostandFoundContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Userdetail> Userdetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CVC222;Initial Catalog=LostandFound;Persist Security Info=True;User ID=sa;Password=cybage@123456;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemIdPk).HasName("Item_IteamId_Pk");

            entity.Property(e => e.ItemIdPk).HasColumnName("ItemId_pk");
            entity.Property(e => e.FloorDetails)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Floor_details");
            entity.Property(e => e.IsFound).HasDefaultValueSql("((0))");
            entity.Property(e => e.IteamDesc)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Iteam_Desc");
            entity.Property(e => e.LostLoctionDesc)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Lost_loctionDesc");
            entity.Property(e => e.Uname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UName");
            entity.Property(e => e.UserContact).HasMaxLength(50);
        });

        modelBuilder.Entity<Userdetail>(entity =>
        {
            entity.HasKey(e => e.UserIdPk).HasName("User_UserId_Pk");

            entity.HasIndex(e => e.UserName, "User_User_uq").IsUnique();

            entity.Property(e => e.UserIdPk).HasColumnName("UserId_pk");
            entity.Property(e => e.Uname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UName");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPhonenumber).HasMaxLength(50);
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
