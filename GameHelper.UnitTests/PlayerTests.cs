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

        [TestMethod]
        public void GetNumberToFire_SalariesPayed_CanNotPay()
        {
            // Arrange
            int numberToFire;
            var player = new PlayerModel() { Dollars = 5 };
            var employeeList = new List<EmployeeModel>()
            {
                new EmployeeModel("Kitchen Trainee") {Salary = 0 },
                new EmployeeModel("Marketing Trainee") {Salary = 5 },
                new EmployeeModel("Management Trainee") {Salary = 5 }
            };
            player.Employees = employeeList;

            // Act
            numberToFire = player.GetNumberToFire();

            // Assert
            Assert.AreEqual(1, numberToFire);
            Assert.AreEqual(3, player.Employees.Count);
            Assert.AreEqual(0, player.Dollars);
        }

        [TestMethod]
        public void GetNumberToFire_SalariesPayed_CanPay()
        {
            // Arrange
            int numberToFire;
            var player = new PlayerModel() { Dollars = 35 };
            var employeeList = new List<EmployeeModel>()
            {
                new EmployeeModel("Kitchen Trainee") {Salary = 5 },
                new EmployeeModel("Marketing Trainee") {Salary = 5 },
                new EmployeeModel("Management Trainee") {Salary = 5 }
            };
            player.Employees = employeeList;

            // Act
            numberToFire = player.GetNumberToFire();

            // Assert
            Assert.AreEqual(3, player.Employees.Count);
            Assert.AreEqual(0, numberToFire);
            Assert.AreEqual(20, player.Dollars);
        }
        [TestMethod]
        public void FireEmployees_EmployeesFired_RemoveEmployees()
        {
            // Arrange
            var player = new PlayerModel();
            var employeeList = new List<EmployeeModel>()
            {
                new EmployeeModel("Kitchen Trainee"),
                new EmployeeModel("Marketing Trainee"),
                new EmployeeModel("Management Trainee")
            };
            player.Employees = employeeList;

            // Act
            player.FireEmployees(1, 2);
            player.FireEmployees(1, 2);

            // Assert
            Assert.AreEqual(1, player.Employees.Count);
            Assert.AreEqual("Kitchen Trainee", 
                player.Employees.Find(e => e.IsMarketer == false).Name);
            Assert.IsNull(player.Employees.Find(e => e.Name == "Marketing Trainee"));
        }

        [TestMethod]
        public void FireEmployees_EmployeesNotFired_EmployeesUnchanged()
        {
            // Arrange
            var player = new PlayerModel();
            var employeeList = new List<EmployeeModel>()
            {
                new EmployeeModel("Kitchen Trainee"),
                new EmployeeModel("Marketing Trainee"),
                new EmployeeModel("Management Trainee")
            };
            player.Employees = employeeList;

            // Act
            player.FireEmployees(0);

            // Assert
            Assert.AreEqual(3, player.Employees.Count);
            Assert.AreEqual(1,
                player.Employees.Find(e => e.Name == "Kitchen Trainee").Number);
            Assert.AreEqual(2,
                player.Employees.Find(e => e.Name == "Management Trainee").Number);
            Assert.AreEqual(3,
                player.Employees.Find(e => e.Name == "Marketing Trainee").Number);
        }
    }
}
