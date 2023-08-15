using Microsoft.EntityFrameworkCore;
using OSDSII.api.Models;
using System.Security.Cryptography.X509Certificates;

namespace OSDSII.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasIndex(customer => customer.Email)
                .IsUnique();
        }
    }
}