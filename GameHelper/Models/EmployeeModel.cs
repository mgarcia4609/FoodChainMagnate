using System.Collections.Generic;
using GameHelper.GameLogic;
using Phases = GameHelper.StaticFiles.Constants.ActivePhase;
using Constants = GameHelper.StaticFiles.Constants;

namespace GameHelper.Models
{
    public class EmployeeModel
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Salary { get; set; }
        public bool IsMarketer { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public EmployeeRequirement HiringRequirement { get; set; }
        public List<MarketingCampaign> MarketingCampaigns { get; set; }

        public EmployeeModel(string employeeName = null)
        {
            Name = employeeName;
            Status = "Beach";

            if (employeeName == "Kitchen Trainee")
            {
                Salary = Constants.EmployeeSalary;
                IsMarketer = false;
                EmployeeType = new EmployeeType("cook") {Magnitude = 1, Phase = Phases.OrderOfBusiness };
            }
            if (employeeName == "Marketing Trainee")
            {
                Salary = Constants.EmployeeSalary;
                IsMarketer = false;
                EmployeeType = new EmployeeType("marketer") { Magnitude = 1, Phase = Phases.OrderOfBusiness };
            }
            if (employeeName == "Management Trainee")
            {
                Salary = 0;
                IsMarketer = true;
                EmployeeType = new EmployeeType("management") { Magnitude = 1, Phase = Phases.Restructuring };
            }
        }

        public bool EmployeeActiveThisPhase(Phases activePhase)
        {
            if (EmployeeType.Phase == activePhase)
            { 
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
