using System.Text.Json;
using Microsoft.EntityFrameworkCore;

public record Customer(string Id, string Name, string Address, string City, string Country, string Phone);

public class CustomerDbContext : DbContext
{
    public CustomerDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customer { get; set; }

    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=customer.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var customersJson = File.ReadAllText("customer.json");
        var customers = JsonSerializer.Deserialize<List<Customer>>(customersJson);
        if (customers is null) return;
        var builder = modelBuilder.Entity<Customer>();
        builder.HasKey(c => c.Id);
        builder.Property(x => x.Id).HasColumnType("TEXT COLLATE NOCASE");
        builder.HasData(customers);
    }
}

