using System;
using System.Collections.Generic;
using System.Linq;
using GameHelper.StaticFiles;
namespace GameHelper.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public int TurnOrderPosition { get; set; }
        public int ActiveEmployeeSlotsAvailable { get; set; }
        public int ActiveEmployees { get; set; }
        public bool IsTurn { get; set; }
        public string RestaurantName { get; set; }
        public List<EmployeeModel> Employees { get; set; }
        public List<RestaurantModel> Restaurants { get; set; }
        public int Dollars { get; set; }


        public PlayerModel()
        {
            Id = 1;
            Console.WriteLine($"Creating Player {Id}...");

            TurnOrderPosition = 1;
            IsTurn = true;
            RestaurantName = "Fried Geese & Donkey";
            Employees = new List<EmployeeModel>();
            ActiveEmployeeSlotsAvailable = 1;
            ActiveEmployees = 0;

            Dollars = 5;

            Console.WriteLine("Player Created!");
        }

        public void CalculateAvailableActiveEmployeeSlots()
        {
            foreach (EmployeeModel employee in Employees
                .Where<EmployeeModel>(e => e.EmployeeType.Type == "management"))
            {
                if (employee.Status == "active")
                {
                    ActiveEmployeeSlotsAvailable += employee.EmployeeType.Magnitude;
                }
            }
        }

        public void HireEmployee(string employeeName)
        {
            int selection = 0;
            EmployeeModel newEmployee = new EmployeeModel(employeeName);

            //PrintEmployeeList("hire", 1);
            ////input loop
            //while (selection <= 0)
            //{
            //    selection = StaticFiles.HelperFunctions.GetNumericInput(Employees.Count);
            //}


            Console.WriteLine($"Hiring {employeeName}");
            Employees.Add(newEmployee);
        }

        public void PaySalaries()
        {
            int totalSalaryOwed = CalculateSalariesOwed();
            int roundedNumEmployeesToFire = 0;
            decimal numEmployeesToFire = 0.0M;

            if (totalSalaryOwed > 0)
            {
                Dollars -= totalSalaryOwed;
            }

            if (Dollars < 0)
            {
                //dollars in the red indicate salaries that can't be paid
                //divide that amount by an employee's salary and round up
                numEmployeesToFire = Math.Abs(Dollars) / StaticFiles.Constants.EmployeeSalary;
                roundedNumEmployeesToFire = (int)Math.Ceiling(numEmployeesToFire);

                //can't go into debt
                Dollars = 0;
            }

            if (roundedNumEmployeesToFire > 0)
            {
                FireEmployees(roundedNumEmployeesToFire);
            }
        }

        private void FireEmployees(int numToFire)
        {
            for (int employeesFired = 0; employeesFired < numToFire; employeesFired++)
            {
                int selection = 0;
                EmployeeModel employee = new EmployeeModel();

                PrintEmployeeList("fire", (numToFire - employeesFired));

                //input loop
                while (selection <= 0)
                {
                    selection = StaticFiles.HelperFunctions.GetNumericInput(Employees.Count);
                }

                if (selection > 0)
                {
                    employee = Employees.Find(e => e.Number == selection);
                    FireEmployee(employee);
                }
            }
        }
        private void FireEmployee(EmployeeModel employee)
        {
            Employees.Remove(employee);
            Console.WriteLine($"{employee.Name} fired.");
        }

        public void PrintEmployeeList(string type, int num = 0)
        {
            Console.WriteLine();
            if (type == "list")
            {
                Console.WriteLine($"Player {Id}'s employees:");
                Console.WriteLine("-----------------");
                ListEmployees();
            }
            else if (type == "fire")
            {
                Console.WriteLine($"Player {Id}, choose {num} employees to fire...");
                Console.WriteLine("-----------------");
                ListEmployees();
            }

        }

        private void ListEmployees()
        {
            UpdateEmployeeNumbers();

            foreach (EmployeeModel employee in Employees)
            {
                Console.WriteLine($"{employee.Number}. {employee.Name}");
            }
        }

        private int CalculateSalariesOwed()
        {
            int total = 0;

            Console.WriteLine($"Calculating Player {Id}'s salaries owed...");

            foreach (EmployeeModel employee in Employees)
            {
                total += employee.Salary;
            }

            return total;
        }
        private void UpdateEmployeeNumbers()
        {
            List<EmployeeModel> sortedList = Employees.OrderBy(o => o.Name).ToList();
            int i = 1;

            foreach (EmployeeModel employee in sortedList)
            {
                employee.Number = i;
                i++;
            }

            Employees = sortedList;
        }
    }
}
