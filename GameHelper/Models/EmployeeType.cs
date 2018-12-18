using System;
using System.Collections.Generic;
using System.Text;

namespace GameHelper.Models
{
    public class EmployeeType
    {
        public string Type { get; set; }
        public int Magnitude { get; set; }
        public string Phase { get; set; }

        public EmployeeType(string type)
        {
            Type = type;
        }

    }
}
