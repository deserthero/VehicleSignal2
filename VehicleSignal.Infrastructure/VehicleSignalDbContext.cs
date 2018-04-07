using Microsoft.EntityFrameworkCore;
using System;
using VehicleSignal.Core.Models;

namespace VehicleSignal.Infrastructurex
{
    public class VehicleSignalDbContext : DbContext
    {
        public VehicleSignalDbContext(DbContextOptions<VehicleSignalDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        DbSet<Vehicle> Vehicles { get; set; }
        DbSet<Customer> Customers { get; set; }

    }
}
