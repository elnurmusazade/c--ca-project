using System;
using System.Collections.Generic;
using System.Text;

namespace layihe1.Models
{
    public class Branch :BaseModel 
    {
        public string address { get; set; }
        public int budget { get; set; } 
        public List<Employee> employees { get; set; }
        public Branch(string name,string address, int budget,bool softDelete)
        {
            this.name = name;
            this.address = address;
            this.budget = budget;
            
            softDelete = false;
        }
    }
}
