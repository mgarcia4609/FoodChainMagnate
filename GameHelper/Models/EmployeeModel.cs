﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameHelper.Models
{
    public class EmployeeModel
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public int Salary { get; set; }
        public bool IsMarketer { get; set; }
        public EmployeeEffect Effect { get; set; }
        public EmployeeRequirement HiringRequirement { get; set; }
        public List<MarketingCampaign> MarketingCampaigns { get; set; }

        public EmployeeModel(string employeeType)
        {
            Name = employeeType;

            if (employeeType == "Kitchen Trainee")
            {
                Status = "Beach";
                Salary = 0;
                IsMarketer = false;
            }
        }
    }
}