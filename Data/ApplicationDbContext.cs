using IssueTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        { 
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Issues> Issues { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Solutions> Solutions { get; set; }

    }
}
