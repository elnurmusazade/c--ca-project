using layihe1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace layihe1.Services.Interfaces
{
    public interface IEmployeeService :IBankService<Employee>
    {
        public Employee Update(Employee employee, string profession, int salary);
    }
}
