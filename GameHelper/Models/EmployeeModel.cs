using System.Collections.Generic;

namespace GameHelper.Models
{
    public class EmployeeModel
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Salary { get; set; }
        public bool IsMarketer { get; set; }
        public EmployeeType Type { get; set; }
        public EmployeeRequirement HiringRequirement { get; set; }
        public List<MarketingCampaign> MarketingCampaigns { get; set; }

        public EmployeeModel(string employeeName = null)
        {
            Name = employeeName;

            if (employeeName == "Kitchen Trainee")
            {
                Status = "Beach";
                Salary = StaticFiles.Constants.EmployeeSalary;
                IsMarketer = false;
                Type = new EmployeeType("cook");
            }
            if (employeeName == "Marketing Trainee")
            {
                Status = "Beach";
                Salary = StaticFiles.Constants.EmployeeSalary;
                IsMarketer = false;
                Type = new EmployeeType("marketer");
            }
            if (employeeName == "Management Trainee")
            {
                Status = "Beach";
                Salary = StaticFiles.Constants.EmployeeSalary;
                IsMarketer = true;
                Type = new EmployeeType("management");
            }
        }

        public bool ActiveThisPhase(string phase)
        {
            if (Type.Phase == phase)
            { 
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ApplyEffect()
        {
            if (ActiveThisPhase(GameLogic.Globals.ActivePhase.))
        }
    }
}
