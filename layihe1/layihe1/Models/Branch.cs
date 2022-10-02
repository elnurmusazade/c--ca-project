using System;
using System.Collections.Generic;
using System.Text;

namespace layihe1.Models
{
    public class Branch :BaseModel 
    {
        public string Address { get; set; }
        public int Budget { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public Branch(string name,string address, int budget,bool softDelete = false)
        {
            Name = name;
            SoftDelete = softDelete;
            Address = address;
            Budget = budget;
        }
    }
}
