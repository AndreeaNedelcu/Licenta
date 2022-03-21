using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_tutorials.Models
{
    //to provide an implementation to this interface we need anoyher class MockEmployeeRepository
 public   interface IEmployeeRepository
    {

        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployees();

        Employee Add(Employee employee);
        Employee Update(Employee employeeChanges);
        Employee Delete(int id);
    }
}
