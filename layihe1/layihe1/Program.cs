using layihe1.Models;
using layihe1.Services.Implementations;
using System;
using System.Collections.Generic;

namespace layihe1
{
    public class Program
    {
       
        public static List<Employee> employee = new List<Employee>();
       

        static void Main(string[] args)
        {

            SeedDataBase();
            string username = "Fidan";
            string password = "123";
            Console.Write("Please Enter Your Username: ");
            string user = Console.ReadLine();
            Console.Write("Please Enter Your Password: ");
            string pass = Console.ReadLine();
            if (username == user && password == pass)
            {
                Console.WriteLine("pls choose Branch or Employee");
                Console.WriteLine("1-Branch : 2-Employee");

                int a = int.Parse(Console.ReadLine());

                switch (a)
                {
                    case 1:
                     BranchService branchService = new BranchService();
                        Console.WriteLine("pls enter number ");
                   int b = int.Parse(Console.ReadLine());
                        switch (b)
                        {
                            case 1:
                                Branch br1 = new Branch("28 mall", "28 may", 2000, false);
                                branchService.Create(br1);
                                break;
                            case 2:

                            Console.WriteLine("pls enter name");
                             string name = Console.ReadLine();
                                branchService.Delete( name);
                                break;
                            case 3:
                              branchService.GetAll();
                                break;
                            case4:
                                Console.WriteLine("pls enter filter");
                                string filter = Console.ReadLine();
                                branchService.Get(filter);
                                break;
                            case5:
                                Console.WriteLine("pls enter name");
                                string name1 = Console.ReadLine();
                                Console.WriteLine("pls enter address");
                                string address = Console.ReadLine();
                                branchService.Update(name1, address);

                        }
                        break;
                    case 2:

                        EmployeeService employeeService = new EmployeeService();
                        Console.WriteLine("pls enter number ");
                        int c = int.Parse(Console.ReadLine());

                        switch(c)
                        {
                            case 1:
                                
                                break;
                            case 2:
                                Console.WriteLine("pls enter name");
                                string name = Console.ReadLine();
                                employeeService.Delete(name);
                                break;

                            case 3:
                                Console.WriteLine("pls enter filter");
                                string filter = Console.ReadLine();
                                employeeService.Get(filter);
                                break;

                            case 4:
                               employeeService.GetAll();
                                break;

                            case 5:
                                Console.WriteLine("pls enter name");
                                string name1 = Console.ReadLine();
                                Console.WriteLine("pls enter surname");
                                string surname = Console.ReadLine();
                                employeeService.Update(name1, surname);

                                break;


                        }
                        break;

                }

            }
            
          
        }

        public static void SeedDataBase()
        {
            Employee emp1 = new Employee("Fidan", "Karimova", 2000, "Developer", false);
            Employee emp2 = new Employee("Jale", "Abilova", 3000, "server", false);
            Employee emp3 = new Employee("omer", "Aliyeva", 4000, "translator", false);
            Employee emp4 = new Employee("Ayxan", "Karimli", 5000, "teacher", false);
            Employee emp5 = new Employee("Aylin", "Priyeva", 6000, "backend", false);
            Employee emp6 = new Employee("Jasmin", "Suleymanli", 7000, "frontend", false);
            employee.Add(emp1);
            employee.Add(emp2);
            employee.Add(emp3);
            employee.Add(emp4);
            employee.Add(emp5);
            employee.Add(emp6);
        }
    }
}
