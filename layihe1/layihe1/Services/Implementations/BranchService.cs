using layihe1.Data;
using layihe1.Models;
using layihe1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace layihe1.Services.Implementations
{
    public class BranchService : IBankService<Branch>
    {
        public Bank<Branch> data;
        public BranchService()
        {
            data = new Bank<Branch>();
        }
        public void Create(Branch branch)
        {
            if (branch.softDelete == false)
            {
                data.Datas.Add(branch);
            }
        }

        public  void Delete(string name)
        {
            Branch brnc = data.Datas.Find(x => x.name.ToLower().Trim() == name.ToLower().Trim());
            brnc.softDelete = true;
            GetAll();
        }

        public void GetAll()
        {
            foreach (var brnch in data.Datas.Where(m => m.softDelete = false))
            {
                Console.WriteLine(brnch.name + " " + brnch.address + " " + brnch.budget);
            }
        }

        public void Get(string filter)
        {
            try
            {
                Branch brnch = data.Datas.Find(x => x.name.Contains(filter.ToLower().Trim()) || x.address.Contains(filter.ToLower().Trim()));
                Console.WriteLine(brnch.name + " " + brnch.address);
            }
            catch (Exception)
            {
                Console.WriteLine("branch wasnt found");
            }
        }


        public void Update(string date1, string date2)
        {
            try
            {


                var e = data.Datas.Where(x => x.name.ToLower().Trim() == date1.ToLower().Trim() &&
                x.address.ToLower().Trim() == date2.ToLower().Trim()).ToList(); // date1 = name , date2 = address

                e.ForEach(x => x.budget = 100000);
                e.ForEach(x => x.address = "28 may");
                Console.WriteLine(e);
            }
            catch(Exception)
            {
                Console.WriteLine("pls enter correct name and address");
            }
        }


        public void GetProfit(Branch branch, Employee employee)
        {
            int lastbudget = branch.budget - employee.salary;
            Console.WriteLine(lastbudget);
        }

        public void HireEmployee(string name, string address)
        {
            var a = data.Datas.Find(x => x.name.ToLower().Trim() == name.ToLower().Trim());

           Branch branch = data.Datas.Find(x => x.address.ToLower().Trim() == address.ToLower().Trim());
            
           


        }

        public void TransferEmployee()
        {
            throw new NotImplementedException();
        }

        public void TransferMoney()
        {

        }
    }
  }

