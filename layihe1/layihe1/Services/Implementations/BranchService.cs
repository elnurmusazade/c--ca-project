using layihe1.Data;
using layihe1.Models;
using layihe1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace layihe1.Services.Implementations
{
    public class BranchService : IBranchService
    {
        public Bank<Branch> branchDB;
        public BranchService()
        {
            branchDB = Program.branches;
        }
        public void Create(Branch branch)
        {
            if (branch.SoftDelete == false)
            {
                branchDB.Datas.Add(branch);
            }
        }

        public bool Delete(string name)
        {
            try
            {
                Branch brnc = branchDB.Datas.Find(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
                brnc.SoftDelete = true;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void GetAll()
        {
            int count = 1;
            foreach (var brnch in branchDB.Datas.Where(m => m.SoftDelete == false))
            {
                Console.WriteLine(count + ". " + brnch.Name + " " + brnch.Address + " " + brnch.Budget);
                count++;
            }
        }

        public Branch Get(string name)
        {
            try
            {
                Branch brnch = branchDB.Datas.Find(
                    x => x.Name.ToLower().Trim().Contains(name.ToLower().Trim()) ||
                    x.Address.ToLower().Trim().Contains(name.ToLower().Trim())
                    );
                return brnch;
            }
            catch (Exception)
            {
                Console.WriteLine("branch wasnt found");
                throw;
            }
        }


        public Branch Update(Branch branch, string budget)
        {
            try
            {
                bool parseResult = int.TryParse(budget, out int newAmount);
                if (parseResult)
                {
                    branch.Budget = newAmount;
                    return branch;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    Console.WriteLine("Wrong budget type. Try again later.");
                else
                    Console.WriteLine("Error occured. Please try again.");
                return null;
            }
        }


        public void GetProfit(Branch branch, Employee employee)
        {
            int lastbudget = branch.Budget - employee.salary;
            Console.WriteLine(lastbudget);
        }

        public void HireEmployee(string name, string address)
        {
            var a = branchDB.Datas.Find(x => x.Name.ToLower().Trim() == name.ToLower().Trim());

            Branch branch = branchDB.Datas.Find(x => x.Address.ToLower().Trim() == address.ToLower().Trim());
        }

        public bool TransferEmployee(Branch from, Branch to, Employee employee)
        {
            from.Employees.Remove(employee);
            to.Employees.Add(employee);
            return true;
        }

        public bool TransferMoney(Branch from, Branch to, int amount)
        {
            if (amount <= from.Budget)
            {
                from.Budget -= amount;
                to.Budget += amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void HireEmployee()
        {
            throw new NotImplementedException();
        }

        public void GetProfit()
        {
            throw new NotImplementedException();
        }
    }
}

