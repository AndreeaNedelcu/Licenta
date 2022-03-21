using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_tutorials.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 1,
                   Name = "Mark",
                   Department = Dept.HR,
                   Email = "mark@yahoo.com"
               },
               new Employee
               {
                   Id = 2,
                   Name = "Mary",
                   Department = Dept.IT,
                   Email = "mary@yahoo.com"
               }
               );
        }
    }
}
