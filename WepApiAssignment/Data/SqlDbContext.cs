using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WepApiAssignment.Models;

namespace WepApiAssignment.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        public DbSet<ServiceWorker> ServiceWorkers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Issue> Issues { get; set; }

    }
}
