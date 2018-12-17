﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<RestaurantModel> Restaurants { get; set; }
        public int Dollars { get; set; }

        public PlayerModel()
        {

            // TODO: Create logic to assign player numbers
            Id = 1;
            Console.WriteLine($"Creating Player {Id}...");
            TurnOrderPosition = 1;
            IsTurn = true;
            //TODO: Implement logic to choose restaurant name
            RestaurantName = "Fried Geese & Donkey";
            Employees = new List<EmployeeModel>();
            Dollars = 5;
            Console.WriteLine("Player Created!");
        }

        public void HireEmployee(string employeeName)
        {
            Console.WriteLine($"Hiring {employeeName}");
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

        private void FireEmployees(int numToFire)
        {
            for (int employeesFired = 0; employeesFired < numToFire; employeesFired++)
            {
                int selection = 0;
                EmployeeModel employee = new EmployeeModel();

                PrintEmployeeList("fire", (numToFire - employeesFired));

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

        public void PrintEmployeeList(string type, int numToFire = 0)
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
                Console.WriteLine($"Player {Id}, choose {numToFire} employees to fire...");
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
            Console.WriteLine($"Calculating Player {Id}'s salaries owed...");
            int total = 0;

            foreach (EmployeeModel employee in this.Employees)
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
