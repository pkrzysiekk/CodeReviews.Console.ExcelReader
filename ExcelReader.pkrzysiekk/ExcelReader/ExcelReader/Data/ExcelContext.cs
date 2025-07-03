using ExcelReader.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelReader.Data;

public class ExcelContext : DbContext
{
    public DbSet<Coffee> Coffees { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=>
        optionsBuilder.UseSqlite("Data Source=coffee.db");

    public void Initialize()
    {
        this.Database.EnsureDeleted();
        this.Database.EnsureCreated();
        
    }
}