using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PayRoll.Core.Common;
using PayRoll.Core.Enums;
using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {        
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Departments)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .IsRequired();
        }


    }
}
