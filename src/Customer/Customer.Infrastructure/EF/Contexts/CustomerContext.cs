using System;
using Customer.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.EF.Contexts
{
	public class CustomerContext : DbContext
	{
        public DbSet<CustomerModel> Customers { get; set; }
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerModel>().ToTable("Customers");
        }
    }
}

