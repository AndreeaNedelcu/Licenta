using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_tutorials.Models
{//we are using the interface in order to be able to use dependency injection
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() {Id=1, Name="Mary", Department=Dept.HR, Email="mary@yahoo.com"},
                new Employee() {Id=2, Name="John", Department=Dept.IT, Email="john@yahoo.com"},
                new Employee() {Id=3, Name="Sam", Department=Dept.IT, Email="sam@yahoo.com"}

            };
        }

        public Employee Add(Employee employee)
        {
           employee.Id= _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee e=_employeeList.FirstOrDefault(e=> e.Id==id);
            if(e != null)
            {
                _employeeList.Remove(e);
            }
            return e;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee e = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (e != null)
            {
                e.Name = employeeChanges.Name;
                e.Email = employeeChanges.Email;
                e.Department = employeeChanges.Department;
            }
            return e;
        }
    }
}
