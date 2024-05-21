using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace projCoreMVC.Models;

public partial class DbRoomContext : DbContext
{
    public DbRoomContext()
    {
    }

    public DbRoomContext(DbContextOptions<DbRoomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TCustomer> TCustomers { get; set; }

    public virtual DbSet<TOrder> TOrders { get; set; }

    public virtual DbSet<TRoom> TRooms { get; set; }

    public virtual DbSet<TShoppingCart> TShoppingCarts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=dbRoom;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TCustomer>(entity =>
        {
            entity.HasKey(e => e.Fid);

            entity.ToTable("tCustomer");

            entity.Property(e => e.Fid).HasColumnName("fid");
            entity.Property(e => e.Faddress)
                .HasMaxLength(50)
                .HasColumnName("faddress");
            entity.Property(e => e.Femail)
                .HasMaxLength(50)
                .HasColumnName("femail");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .HasColumnName("fname");
            entity.Property(e => e.Fpassword)
                .HasMaxLength(50)
                .HasColumnName("fpassword");
            entity.Property(e => e.Fphone)
                .HasMaxLength(50)
                .HasColumnName("fphone");
        });

        modelBuilder.Entity<TOrder>(entity =>
        {
            entity.HasKey(e => e.FId);

            entity.ToTable("tOrder");

            entity.Property(e => e.FId).HasColumnName("fID");
            entity.Property(e => e.FCustomerId).HasColumnName("fCustomerID");
            entity.Property(e => e.FDate)
                .HasMaxLength(50)
                .HasColumnName("fDate");
            entity.Property(e => e.FPrice)
                .HasColumnType("money")
                .HasColumnName("fPrice");
            entity.Property(e => e.FRoomId).HasColumnName("fRoomID");
        });

        modelBuilder.Entity<TRoom>(entity =>
        {
            entity.HasKey(e => e.Fid);

            entity.ToTable("tRoom");

            entity.Property(e => e.Fid).HasColumnName("fid");
            entity.Property(e => e.FAmount).HasColumnName("fAmount");
            entity.Property(e => e.FDescription)
                .HasMaxLength(50)
                .HasColumnName("fDescription");
            entity.Property(e => e.FImagePath)
                .HasMaxLength(50)
                .HasColumnName("fImagePath");
            entity.Property(e => e.FName)
                .HasMaxLength(50)
                .HasColumnName("fName");
            entity.Property(e => e.FPrice)
                .HasColumnType("money")
                .HasColumnName("fPrice");
        });

        modelBuilder.Entity<TShoppingCart>(entity =>
        {
            entity.HasKey(e => e.Fid);

            entity.ToTable("tShoppingCart");

            entity.Property(e => e.Fid).HasColumnName("fid");
            entity.Property(e => e.FAmount).HasColumnName("fAmount");
            entity.Property(e => e.FCustomerId).HasColumnName("fCustomerID");
            entity.Property(e => e.FDate)
                .HasMaxLength(50)
                .HasColumnName("fDate");
            entity.Property(e => e.FPrice)
                .HasColumnType("money")
                .HasColumnName("fPrice");
            entity.Property(e => e.FRoomId).HasColumnName("fRoomID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
