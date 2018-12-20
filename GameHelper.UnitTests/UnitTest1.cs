using GameHelper.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GameHelper.UnitTests
{
    [TestClass]
    public class PlayerTests
    {

        [TestMethod]
        public void HireEmployee_EmployeeHired_AddedToEmployees()
        {
            // Arrange
            var player = new PlayerModel();
            var playerEmployee = new EmployeeModel();

            // Act
            player.HireEmployee("Kitchen Trainee");
            playerEmployee = player.Employees.Find(e => e.Name == "Kitchen Trainee");


            // Assert
            Assert.AreEqual(1, player.Employees.Count);
            Assert.AreEqual("Kitchen Trainee", playerEmployee.Name);
            Assert.AreEqual(false, playerEmployee.IsMarketer);
            Assert.AreEqual("Beach", playerEmployee.Status);
        }

        [TestMethod]
        public void FireEmployee_EmployeeFired_RemovedFromEmployees()
        {
            // Arrange
            var player = new PlayerModel();
            var playerEmployee = new EmployeeModel("Kitchen Trainee");

            player.Employees.Add(playerEmployee);

            // Act            
            player.FireEmployee(playerEmployee);

            // Assert
            Assert.AreEqual(0, player.Employees.Count);
        }

        [TestMethod]
        public void CalculateSalariesOwed_CalculateSalaris_SuccessfulCalculation()
        {
            // Arrange
            int employeeSalary = 5;
            int expectedAmountOwed = 15;
            var player = new PlayerModel() { Dollars = 20 };
            var employeeList = new List<EmployeeModel>()
            {
                new EmployeeModel("Kitchen Trainee") { Salary = employeeSalary },
                new EmployeeModel("Marketing Trainee") { Salary = employeeSalary },
                new EmployeeModel("Management Trainee") { Salary = employeeSalary }
            };

            player.Employees = employeeList;

            // Act            
            int amountOwed = player.CalculateSalariesOwed();

            // Assert
            Assert.AreEqual(3, player.Employees.Count);
            Assert.AreEqual(expectedAmountOwed, amountOwed);
            Assert.AreEqual(5, player.Dollars - amountOwed);
        }

        [TestMethod]
        public void UpdateEmployeeNumbers_EmployeesOrdered_OrderedAlphabetically()
        {
            // Arrange
            int employeeNumber = 1;
            var player = new PlayerModel();
            var employeeList = new List<EmployeeModel>()
            {
                new EmployeeModel("Kitchen Trainee") {Status = "Active", Salary = 0 },
                new EmployeeModel("Marketing Trainee") {Salary = 0 },
                new EmployeeModel("Management Trainee") {Salary = 5 }
            };

            player.Employees = employeeList;

            // Act            
            player.UpdateEmployeeNumbers();

            // Assert
            Assert.AreEqual(3, player.Employees.Count);
            for (int count = 1; count < player.Employees.Count; count ++)
            {
                EmployeeModel employee = player.Employees.Find(e => e.Number == count);

                if (employee.Number == 1)
                {
                    Assert.AreEqual("Kitchen Trainee", employee.Name);
                    Assert.AreEqual(0, employee.Salary);
                    Assert.AreEqual("Active", employee.Status);
                }
                else if (employee.Number == 2)
                {
                    Assert.AreEqual("Management Trainee", employee.Name);
                    Assert.AreEqual(5, employee.Salary);
                    Assert.AreEqual("Beach", employee.Status);
                }
                else if (employee.Number == 3)
                {
                    Assert.AreEqual("Marketing Trainee", employee.Name);
                    Assert.AreEqual(0, employee.Salary);
                    Assert.AreEqual("Beach", employee.Status);
                }
                employeeNumber++;
            }
        }
    }
}
