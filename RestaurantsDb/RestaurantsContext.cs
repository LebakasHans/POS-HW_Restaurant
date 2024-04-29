using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestaurantsDb;

public partial class RestaurantsContext : DbContext
{
    public RestaurantsContext()
    {
    }

    public RestaurantsContext(DbContextOptions<RestaurantsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<GoodType> GoodTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<Waiter> Waiters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\mssqllocaldb;attachdbfilename=C:\\Users\\jakob\\Documents\\Schule\\Pos\\Databases\\Restaurants.mdf;integrated security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasIndex(e => e.GoodTypeId, "IX_Goods_GoodTypeId");

            entity.HasOne(d => d.GoodType).WithMany(p => p.Goods).HasForeignKey(d => d.GoodTypeId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.GoodId, "IX_Orders_GoodId");

            entity.HasIndex(e => e.TableId, "IX_Orders_TableId");

            entity.HasIndex(e => e.WaiterAtOrderId, "IX_Orders_WaiterAtOrderId");

            entity.HasIndex(e => e.WaiterAtPaymentId, "IX_Orders_WaiterAtPaymentId");

            entity.HasOne(d => d.Good).WithMany(p => p.Orders).HasForeignKey(d => d.GoodId);

            entity.HasOne(d => d.Table).WithMany(p => p.Orders).HasForeignKey(d => d.TableId);

            entity.HasOne(d => d.WaiterAtOrder).WithMany(p => p.OrderWaiterAtOrders).HasForeignKey(d => d.WaiterAtOrderId);

            entity.HasOne(d => d.WaiterAtPayment).WithMany(p => p.OrderWaiterAtPayments).HasForeignKey(d => d.WaiterAtPaymentId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
