using layihe1.Data;
using layihe1.Models;
using layihe1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace layihe1.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Bank<Employee> employeesDB;
        public EmployeeService()
        {
            employeesDB = Program.employees;
        }

        public void Create(Employee emplye)
        {
            if (emplye.SoftDelete == false)
            {
                employeesDB.Datas.Add(emplye);
            }
        }

        public bool Delete(string name)
        {
            Employee emp = employeesDB.Datas.Find(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            emp.SoftDelete = true;
            GetAll();
            return true;
        }

        public Employee Get(string filter)
        {
            try
            {
                Employee emp = employeesDB.Datas.Find(x => x.Name.ToLower().Trim().Contains(filter.ToLower().Trim()) || x.surname.ToLower().Trim().Contains(filter.ToLower().Trim()));
                return emp;
            }
            catch (Exception)
            {
                Console.WriteLine("employee wasnt found");
                throw;
            }
        }

        public void GetAll()
        {
            foreach (var empl in employeesDB.Datas.Where(m => m.SoftDelete == false))
            {
                Console.WriteLine(empl.Name + " " + empl.surname+ ", "+ empl.profession + ", salary exp.: " + empl.salary);
            }
        }

        public Employee Update(Employee employee, string profession, int salary)
        {
            employee.profession = profession;
            employee.salary = salary;
            return employee;
        }

        public Employee Update(Employee entity, string dataToUptdate)
        {
            throw new NotImplementedException();
        }
    }
}
