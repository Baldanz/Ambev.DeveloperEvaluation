using Ambev.DeveloperEvaluation.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repository;

public class DefaultContext : DbContext
{
    #region constructors

    /// <summary>
    /// DefaultContext constructor
    /// </summary>
    /// <param name="options">db context options for database setup</param>
    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
        PostgreSqlConnectionString = base.Database.GetConnectionString();
    }

    #endregion

    #region tables

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<RatingEntity> Ratings { get; set; }
    public DbSet<CartEntity> Carts { get; set; }
    public DbSet<ProductsInCartEntity> ProductsInCart { get; set; }
    public DbSet<SalesEntity> Sales { get; set; }
    public DbSet<ProductsInSalesEntity> ProductsInSales { get; set; }

    #endregion

    #region methods

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<ProductEntity>(a =>
        {
            a.ToTable("Products");
            a.HasKey(v => v.Id);
        });

        builder.Entity<RatingEntity>()
            .HasOne(v => v.Products)
            .WithMany()
            .HasForeignKey(v => v.ProductId);

        builder.Entity<CartEntity>()
            .HasOne(v => v.Users)
            .WithMany()
            .HasForeignKey(v => v.UserId);

        builder.Entity<ProductsInCartEntity>(a =>
        {
            a.ToTable("ProductsInCart");
            a.HasKey(v => new { v.CartId, v.ProductId });
        });

        builder.Entity<ProductsInSalesEntity>(a =>
        {
            a.ToTable("ProductsInSales");
            a.HasKey(v => new { v.SaleId, v.ProductId });
        });

        builder.Entity<ProductsInCartEntity>()
            .HasOne(v => v.Cart)
            .WithMany()
            .HasForeignKey(v => v.CartId);

        builder.Entity<ProductsInCartEntity>()
            .HasOne(v => v.Products)
            .WithMany()
            .HasForeignKey(v => v.ProductId);

        builder.Entity<SalesEntity>()
            .HasOne(v => v.Users)
            .WithMany()
            .HasForeignKey(v => v.UserId);

        builder.Entity<ProductsInSalesEntity>()
            .HasOne(v => v.Sales)
            .WithMany()
            .HasForeignKey(v => v.SaleId);

        builder.Entity<ProductsInSalesEntity>()
            .HasOne(v => v.Products)
            .WithMany()
            .HasForeignKey(v => v.ProductId);
    }

    #endregion

    #region properties

    public string? PostgreSqlConnectionString { get; private set; }

    #endregion
}
