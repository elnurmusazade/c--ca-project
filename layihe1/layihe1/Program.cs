using layihe1.Data;
using layihe1.Models;
using layihe1.Services.Implementations;
using System;
using System.Collections.Generic;

namespace layihe1
{
    public static class Program
    {

        public static Bank<Employee> employees = new Bank<Employee>();
        public static Bank<Branch> branches = new Bank<Branch>();
        public static EmployeeService employeeService = new EmployeeService();
        public static BranchService branchService = new BranchService();

        static void Main(string[] args)
        {

            SeedDataBase();
            Manager validManager = new Manager("Fidan", "123");
            int count = 0;
            //while (true)
            //{
            //    if (count > 0)
            //    {
            //        Console.WriteLine("\nInvalid username or password. Please try again.");
            //    }
            //    Manager manager = Authorize();
            //    count++;
            //    if (validManager.UserName == manager.UserName && validManager.Password == manager.Password)
            //        break;
            //}

            InitializeMenu();
        }
        public static void InitializeMenu()
        {
            int mode = 0;
            while (mode == 0)
            {
                mode = ChooseMode();
            }

            switch (mode)
            {
                case 1:
                    BranchActions();
                    break;
                case 2:
                    EmployeeActions();
                    break;
                default:
                    Console.WriteLine("Wrong input.");
                    break;

            }
        }
        public static void BranchActions()
        {
            while (true)
            {
                Console.WriteLine("\nPlease choose which action do you want to make:");
                Console.WriteLine(
                    "1. List all branches.\n" +
                    "2. Get a special branch.\n" +
                    "3. Create a new branch.\n" +
                    "4. Delete existing branch.\n" +
                    "5. Update a branch.\n" +
                    "6. Get Profit.\n" +
                    "7. Hire employee.\n" +
                    "8. Transfer money.\n" +
                    "9. Transfer employee.\n" +
                    "10. Back to main menu.\n" +
                    "0. Quit."
                    );

                int branchModeChoice;

                while (!int.TryParse(Console.ReadLine(), out branchModeChoice))
                {
                    Console.WriteLine("Your choice was in a wrong format. Try number values.");
                }

                if (branchModeChoice == 0)
                    break;
                switch (branchModeChoice)
                {
                    case 1:
                        branchService.GetAll();
                        break;
                    case 2:
                        Console.WriteLine("\nPlease enter the Branch's name:");
                        string branchName = Console.ReadLine();
                        Branch brnch = branchService.Get(branchName);
                        if (brnch != null)
                        {
                            Console.WriteLine(brnch.Name + " " + brnch.Address + " " + brnch.Budget);
                        }
                        else
                        {
                            Console.WriteLine($"\nBranch with name \"{branchName}\" not found");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Bank name:");
                        string newBranchName = Console.ReadLine();
                        Console.WriteLine("Bank address:");
                        string newBranchAddress = Console.ReadLine();
                        Console.WriteLine("Bank budget in AZN (ex. 1500000):");
                        int newBranchBudget = int.Parse(Console.ReadLine());
                        Branch branch = new Branch(name: newBranchName, address: newBranchAddress, budget: newBranchBudget);
                        branchService.Create(branch);
                        break;
                    case 4:
                        Console.WriteLine("Please enter the name of branch you want to delete:");
                        string branchToDelete = Console.ReadLine();
                        string result = branchService.Delete(branchToDelete) == true ?
                            $"Branch {branchToDelete} has been deleted from db." :
                            $"Couldn't find branch with name {branchToDelete}";
                        Console.WriteLine(result);
                        break;
                    case 5:
                        Console.WriteLine("Please enter the name of the branch to update:");
                        string name1 = Console.ReadLine();
                        Branch branchToUpdate = branchService.Get(name1);
                        if (branchToUpdate == null)
                        {
                            Console.WriteLine($"Branch with name {name1} not found.");
                            break;
                        }
                        Console.WriteLine($"Please enter the new amount of budget (present budget is: {branchToUpdate.Budget} AZN):");
                        string newBudget = Console.ReadLine();
                        branchService.Update(branchToUpdate, newBudget);
                        Console.WriteLine($"New branch budget is {branchToUpdate.Budget} AZN.");
                        break;
                    case 6:
                        // HireEmployee methodu ishcini goturerken Branch budgetinden maash cixildigina gore burada sadece budget gosterilir.
                        Console.WriteLine("Please enter the name of the branch to get the profit of:");
                        string brname = Console.ReadLine();
                        Branch br = branchService.Get(brname);
                        if (br == null)
                        {
                            Console.WriteLine($"Branch with name {brname} not found.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Branch profit is: {br.Budget}");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Please write Branch name to hire an employee:");
                        string hiringBranchName = Console.ReadLine();
                        Branch hiringBranch = branchService.Get(hiringBranchName);
                        if (hiringBranch == null)
                        {
                            Console.WriteLine($"Branch with name {hiringBranchName} not found.");
                            break;
                        }
                        Console.WriteLine("\nPlease write name OR surname of an employee from list to hire:");
                        employeeService.GetAll();
                        string empFilter = Console.ReadLine();
                        Employee empToHire = employeeService.Get(empFilter);
                        if (empToHire == null)
                        {
                            Console.WriteLine("Wrong employee information. Try again later.");
                            break;
                        }
                        if (empToHire.salary <= hiringBranch.Budget)
                        {
                            hiringBranch.Employees.Add(empToHire);
                            Console.WriteLine("Employee hired successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Employee's salary expectation is high. Can't hire.");
                        }
                        break;
                    case 8:
                        Console.WriteLine("Please write Branch name to transfer from:");
                        string from = Console.ReadLine();
                        Branch fromBranch = branchService.Get(from);
                        if (fromBranch == null)
                        {
                            Console.WriteLine("Branch not found.");
                            break;
                        }
                        Console.WriteLine("Please write Branch name to transfer to:");
                        string to = Console.ReadLine();
                        Branch toBranch = branchService.Get(to);
                        if (toBranch == null)
                        {
                            Console.WriteLine("Branch not found.");
                            break;
                        }
                        Console.WriteLine("Please write amount to transfer:");
                        bool isValidAmount = int.TryParse(Console.ReadLine(), out int amount);
                        if (isValidAmount)
                        {
                            bool transferResult = branchService.TransferMoney(fromBranch, toBranch, amount);
                            if (transferResult)
                            {
                                Console.WriteLine("Transfer succeeded");
                            }
                            else
                            {
                                Console.WriteLine("The amount is bigger than the Branch's balance. Transfer canceled.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount type.");
                        }
                        break;
                    case 9:
                        Console.WriteLine("Please write the Branch name to transfer employee from:");
                        string fromBrnchName = Console.ReadLine();
                        Branch fromBrnch = branchService.Get(fromBrnchName);
                        if (fromBrnch == null)
                        {
                            Console.WriteLine("Can't find the branch. Try again later.");
                            break;
                        }

                        if (fromBrnch.Employees.Count == 0)
                        {
                            Console.WriteLine("There is no employees in this branch to transfer. Try again later.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nThe list of employees of this branch:");
                            foreach (var employee in fromBrnch.Employees)
                            {
                                Console.WriteLine($"{employee.Name} {employee.surname}, salary exp. {employee.salary}");
                            }
                        }
                        Console.WriteLine("\nPlease write name OR surname of an employee from list to transfer:");
                        string empfilter = Console.ReadLine();
                        Employee employeeToTransfer = employeeService.Get(empfilter);
                        if (employeeToTransfer == null)
                        {
                            Console.WriteLine("Wrong employee information. Try again later");
                            break;
                        }

                        Console.WriteLine("Please write the Branch name to transfer employee TO:");
                        string toBrnchName = Console.ReadLine();
                        Branch toBrnch = branchService.Get(toBrnchName);
                        if (toBrnch == null)
                        {
                            Console.WriteLine("Can't find the branch. Try again later.");
                            break;
                        }
                        branchService.TransferEmployee(fromBrnch, toBrnch, employeeToTransfer);
                        Console.WriteLine("Employee transfered successfully!");
                        break;
                    case 10:
                        InitializeMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Try again.");
                        break;
                }
                if (branchModeChoice == 10)
                    break;
            }
        }
        public static void EmployeeActions()
        {
            while (true)
            {
                Console.WriteLine("\nPlease choose which action do you want to make:");
                Console.WriteLine(
                    "1. List all employees.\n" +
                    "2. Get an employee.\n" +
                    "3. Create a new employee.\n" +
                    "4. Delete existing employee.\n" +
                    "5. Update an employee.\n" +
                    "6. Back to main menu.\n" +
                    "0. Quit."
                    );

                int employeeModeChoice;

                while (!int.TryParse(Console.ReadLine(), out employeeModeChoice))
                {
                    Console.WriteLine("Your choice was in a wrong format. Try number values.");
                }
                if (employeeModeChoice == 0)
                    break;
                switch (employeeModeChoice)
                {
                    case 1:
                        employeeService.GetAll();
                        break;
                    case 2:
                        Console.WriteLine("\nPlease enter the Employee's name OR surname:");
                        string employeeFilter = Console.ReadLine();
                        Employee employee = employeeService.Get(employeeFilter);
                        if (employee != null)
                        {
                            Console.WriteLine($"{employee.Name} {employee.surname}, {employee.profession}, salary: {employee.salary}");
                        }
                        else
                        {
                            Console.WriteLine($"\nEmployee with name \"{employeeFilter}\" not found");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Employee name:");
                        string newEmployeeName = Console.ReadLine();
                        Console.WriteLine("Employee surname:");
                        string newEmployeeSurname = Console.ReadLine();
                        Console.WriteLine("Employee profession:");
                        string newEmployeeProfession = Console.ReadLine();
                        Console.WriteLine("Salary expectation in AZN (ex. 2000):");
                        int newEmployeeSalary = int.Parse(Console.ReadLine());
                        Employee newEmployee = new Employee(newEmployeeName, newEmployeeSurname, newEmployeeSalary, newEmployeeProfession);
                        employees.Datas.Add(newEmployee);
                        break;

                    case 4:
                        Console.WriteLine("Please enter the name of the employee you want to delete:");
                        string employeeNameToDelete = Console.ReadLine();
                        string result = employeeService.Delete(employeeNameToDelete) == true ?
                            $"Employee {employeeNameToDelete} has been deleted from db." :
                            $"Couldn't find branch with name {employeeNameToDelete}";
                        Console.WriteLine(result);
                        break;

                    case 5:
                        Console.WriteLine("\nPlease enter the Employee's name OR surname:");
                        string employeeUpdFilter = Console.ReadLine();
                        Employee employeeToUpdate = employeeService.Get(employeeUpdFilter);
                        if (employeeToUpdate != null)
                        {
                            Console.WriteLine($"{employeeToUpdate.Name} {employeeToUpdate.surname}, {employeeToUpdate.profession}, salary: {employeeToUpdate.salary}");
                        }
                        else
                        {
                            Console.WriteLine($"\nEmployee with name \"{employeeUpdFilter}\" not found");
                            break;
                        }
                        Console.WriteLine("Type a new profession for this employee:");
                        string newProfession = Console.ReadLine();
                        bool isSalaryParsed = int.TryParse(Console.ReadLine(), out int newSalary);
                        if (!isSalaryParsed)
                        {
                            Console.WriteLine("Invalid value for salary. Try again later.");
                            break;
                        }
                        employeeService.Update(employeeToUpdate, newProfession, newSalary);
                        Console.WriteLine("Employee updated successfully!");
                        break;
                    case 6:
                        InitializeMenu();
                        break;
                }
                if (employeeModeChoice == 6)
                    break;
            }
        }
        public static void SeedDataBase()
        {
            Employee emp1 = new Employee("Fidan", "Karimova", 2000, "Developer");
            Employee emp2 = new Employee("Jale", "Abilova", 3000, "server");
            Employee emp3 = new Employee("omer", "Aliyeva", 4000, "translator");
            Employee emp4 = new Employee("Ayxan", "Karimli", 5000, "teacher");
            Employee emp5 = new Employee("Aylin", "Priyeva", 6000, "backend");
            Employee emp6 = new Employee("Jasmin", "Suleymanli", 7000, "frontend");
            EmployeeService employeeService = new EmployeeService();
            employeeService.Create(emp1);
            employeeService.Create(emp2);
            employeeService.Create(emp3);
            employeeService.Create(emp4);
            employeeService.Create(emp5);
            employeeService.Create(emp6);
        }

        public static int ChooseMode()
        {
            Console.WriteLine("\nPlease choose Branch or Employee");
            Console.WriteLine("1-Branch : 2-Employee");

            int.TryParse(Console.ReadLine(), out int mode);
            return mode;
        }
        public static Manager Authorize()
        {
            Console.Write("Please Enter Your Username: ");
            var usernameInput = Console.ReadLine();
            Console.Write("Please Enter Your Password: ");
            var passwordInput = Console.ReadLine();
            Manager manager = new Manager(usernameInput, passwordInput);
            return manager;
        }
    }
}
