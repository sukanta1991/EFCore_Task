using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoreEF.DataEntity
{
    public class EmpDbContext :DbContext
    {
        public EmpDbContext()
        {

        }
        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(x => x.Id);
        }

    }
}
