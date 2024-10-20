using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace EMS.Models
{
    public class EMS_DbContext : DbContext
    {
        public EMS_DbContext(DbContextOptions<EMS_DbContext> options)
            : base(options)
        {
        }

        public DbSet<Employees> EmployeesTbl { get; set; }
    }
}
