using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sofbeauty_API_MiguelCR.Models;

public partial class SofbeautyContext : DbContext
{
    public SofbeautyContext()
    {
    }

    public SofbeautyContext(DbContextOptions<SofbeautyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CartsItem> CartsItems { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerContact> CustomerContacts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartsItem>(entity =>
        {
            entity.Property(e => e.CartsItemId).HasColumnName("cartsItemID");
            entity.Property(e => e.CartsId).HasColumnName("cartsID");
            entity.Property(e => e.ProductsId).HasColumnName("productsID");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Carts).WithMany(p => p.CartsItems)
                .HasForeignKey(d => d.CartsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartsItems_ShoppingCarts");

            entity.HasOne(d => d.Products).WithMany(p => p.CartsItems)
                .HasForeignKey(d => d.ProductsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartsItems_Products");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomersId);

            entity.Property(e => e.CustomersId).HasColumnName("customersID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CustomersName)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("customersName");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
        });

        modelBuilder.Entity<CustomerContact>(entity =>
        {
            entity.HasKey(e => e.ContactsId);

            entity.Property(e => e.ContactsId).HasColumnName("contactsID");
            entity.Property(e => e.Adress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("adress");
            entity.Property(e => e.CustomersId).HasColumnName("customersID");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.PreferredContact)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("preferredContact");

            entity.HasOne(d => d.Customers).WithMany(p => p.CustomerContacts)
                .HasForeignKey(d => d.CustomersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerContacts_Customers");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdersId);

            entity.Property(e => e.OrdersId).HasColumnName("ordersID");
            entity.Property(e => e.CustomersId).HasColumnName("customersID");
            entity.Property(e => e.DeliveryMethods)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("deliveryMethods");
            entity.Property(e => e.OrdersDate).HasColumnName("ordersDate");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalAmount");

            entity.HasOne(d => d.Customers).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailsId);

            entity.Property(e => e.OrderDetailsId).HasColumnName("orderDetailsID");
            entity.Property(e => e.DeliveryMethod)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("deliveryMethod");
            entity.Property(e => e.OrdersId).HasColumnName("ordersID");
            entity.Property(e => e.ProductsId).HasColumnName("productsID");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("unitPrice");

            entity.HasOne(d => d.Orders).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrdersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Orders");

            entity.HasOne(d => d.Products).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductsId);

            entity.Property(e => e.ProductsId).HasColumnName("productsID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Img)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.ProductsName)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("productsName");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.HasKey(e => e.CartsId);

            entity.Property(e => e.CartsId).HasColumnName("cartsID");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.LoginPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("loginPassword");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.UserRolId).HasColumnName("userRolID");

            entity.HasOne(d => d.UserRol).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_UserRole");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole");

            entity.Property(e => e.UserRoleId).HasColumnName("userRoleID");
            entity.Property(e => e.UserRoleDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("userRoleDescription");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
