using System;
using System.Collections.Generic;
using System.Text;

namespace layihe1.Models
{
    public class Employee : BaseModel   
    {
        public string surname { get; set; } 
        public int salary { get; set; } 
        public string profession { get; set; }
        public Employee(string name ,string surname ,int salary,string profession)
        {
            this.Name = name;
            this.surname = surname;
            this.salary = salary;
            this.profession = profession;
            SoftDelete = false;
        }
    }
}
