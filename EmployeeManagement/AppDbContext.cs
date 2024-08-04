using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeManagement
{
    public class AppDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    
        public AppDbContext() : base("name=DefaultConnection")
        {

        }
    }
}