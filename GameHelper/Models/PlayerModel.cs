using System;
using System.Collections.Generic;
using GameHelper.StaticFiles;
namespace GameHelper.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public int TurnOrderPosition { get; set; }
        public bool IsTurn { get; set; }
        public string RestaurantName { get; set; }
        public List<EmployeeModel> Employees { get; set; }
        public int Dollars { get; set; }

        public PlayerModel()
        {
            // TODO: Create logic to assign player numbers
            Id = 1;
            TurnOrderPosition = 1;
            IsTurn = true;
            //TODO: Implement logic to choose restaurant name
            RestaurantName = "Fried Geese & Donkey";
            Employees = new List<EmployeeModel>();
            Dollars = 0;

        }

        public void HireEmployee(string employeeName)
        {
            EmployeeModel newEmployee = new EmployeeModel(employeeName);
            Employees.Add(newEmployee);
        }

        public void PaySalaries()
        {
            int totalSalaryOwed = CalculateSalariesOwed();
            decimal numEmployeesToFire = 0;
            int roundedNumEmployeesToFire = 0;

            if (totalSalaryOwed > 0)
            {
                Dollars -= totalSalaryOwed;
            }

            if (Dollars < 0)
            {
                numEmployeesToFire = Math.Abs(Dollars) / StaticFiles.Constants.EmployeeSalary;
                roundedNumEmployeesToFire = (int)Math.Ceiling(numEmployeesToFire);

                Dollars = 0;
            }

            if (roundedNumEmployeesToFire > 0)
            {
                FireEmployees(roundedNumEmployeesToFire);
            }
        }

        private void FireEmployees(int num)
        {
            Console.WriteLine($"Player {Id}, choose employees to fire...");
            Console.WriteLine("-----------------");
            ListEmployees();

        }

        public void PrintEmployeeList()
        {
            Console.WriteLine($"Player {Id}'s employees:");
            Console.WriteLine("-----------------");
            ListEmployees();
        }

        private void ListEmployees()
        {
            int count = 1;

            foreach (EmployeeModel employee in Employees)
            {
                Console.WriteLine($"{count}. {employee.Name}");
            }
        }

        private int CalculateSalariesOwed()
        {
            int total = 0;

            foreach (EmployeeModel employee in this.Employees)
            {
                total += employee.Salary;
            }

            return total;
        }
    }
}
