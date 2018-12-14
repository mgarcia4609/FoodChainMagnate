using System;
using System.Collections.Generic;
using System.Text;
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

        public void PrintEmployeeList()
        {
            Console.WriteLine($"Player {Id}'s employees:");
            Console.WriteLine("-----------------");
            foreach (EmployeeModel employee in this.Employees)
            {
                Console.WriteLine(employee.Name);
            }
        }
    }
}
