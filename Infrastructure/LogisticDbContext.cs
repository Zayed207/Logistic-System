using Domain.Entities;
using LogisticSystem.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LogisticSystem.Infrastructure.Data;

public class LogisticDbContext : DbContext
{
    public LogisticDbContext(DbContextOptions<LogisticDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<CustomerContact> CustomerContacts => Set<CustomerContact>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<ShipmentRequest> ShipmentRequests => Set<ShipmentRequest>();
    public DbSet<ShipmentPackage> ShipmentPackages => Set<ShipmentPackage>();
    public DbSet<Shipment> Shipments => Set<Shipment>();
    public DbSet<ShipmentAssignment> ShipmentAssignments => Set<ShipmentAssignment>();
    public DbSet<StateHistory> StateHistories => Set<StateHistory>();
    public DbSet<ProofDocument> ProofDocuments => Set<ProofDocument>();
    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Apply all configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
