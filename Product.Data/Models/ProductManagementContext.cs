using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Data.Models
{
    public partial class ProductManagementContext : DbContext
    {
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<UserProduct> UserProduct { get; set; }
        public ProductManagementContext(DbContextOptions<ProductManagementContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired().HasDefaultValueSql("NewId()");
                entity.Property(e => e.RoleName).IsRequired();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired().HasDefaultValueSql("NewId()");
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Address).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Mobile).IsRequired();
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");
                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
                entity.Property(e => e.IsActive).HasColumnName("IsActive").HasDefaultValue(true);
                entity.HasOne(d => d.UserRole)
                      .WithMany(f => f.Users)
                      .HasForeignKey(e => e.UserRoleId)
                      .HasConstraintName("FK_UserRoles_Users")
                      .IsRequired();
                entity.Property(e => e.Password).IsRequired();
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired().HasDefaultValueSql("NewId()");
                entity.Property(e => e.Name).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.ImageUrl).IsRequired();
                entity.Property(e => e.SalePrice).IsRequired();
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");
                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
                entity.Property(e => e.IsActive).HasColumnName("IsActive").HasDefaultValue(true);
                entity.Property(e => e.CreatedBy).IsRequired();                
                entity.HasOne(d => d.User)
                      .WithMany(f => f.Products)
                      .HasForeignKey(e => e.CreatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_User_Products")
                      .IsRequired();
                entity.Property(e => e.UpdatedBy).IsRequired();
                entity.HasOne(d => d.User1)
                      .WithMany(f => f.Products1)
                      .HasForeignKey(e=>e.UpdatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_User1_Products1")
                      .IsRequired();
            });

            modelBuilder.Entity<UserProduct>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired().HasDefaultValueSql("NewId()");
                entity.Property(e => e.OrderedOn).HasColumnType("datetime").IsRequired(false);
                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
                entity.HasOne(d => d.Product)
                      .WithMany(f => f.UserProduct)
                      .HasForeignKey(e => e.ProductId)
                      .HasConstraintName("FK_Product_UserProduct")
                      .IsRequired();
                entity.HasOne(d => d.User)
                      .WithMany(f => f.UserProducts)
                      .HasForeignKey(e => e.UserId)
                      .HasConstraintName("FK_User_UserProduct")
                      .IsRequired();
                entity.Property(e => e.IsOrdered).HasColumnName("IsOrdered").HasDefaultValue(false);
            });
        }

    }
}
