using Microsoft.EntityFrameworkCore;
using StockPilot.Api.Models;

namespace StockPilot.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}