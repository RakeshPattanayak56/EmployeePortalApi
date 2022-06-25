using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentLoginInfo.Models;

namespace EmployeeLoginInfo.Models
{
    public partial class EmployeeDb2022Context : DbContext
    {
        protected readonly IConfiguration Configuration;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EmployeeDb2022Context()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EmployeeDb2022Context(IConfiguration configuration)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Configuration = configuration;
        }

        //public EmployeeDb2022Context(DbContextOptions<EmployeeDb2022Context> options)
        //    : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=employeecontrol.database.windows.net;Database=employeedb;User Id=rakesh;Password=Employeecontrol@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
