using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WAD._00013096.Models;

namespace WAD._00013096.Data
{
    public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Estate> Estates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Seller>()
            .HasMany(p => p.Estates)
            .WithOne(e => e.Seller)
            .HasForeignKey(e => e.SellerId)
            .OnDelete(DeleteBehavior.Cascade); 
   
    }
  }
}