using System;
using System.Collections.Generic;
using System.Text;

namespace GameHelper.StaticFiles
{
    public static class Constants
    {
        public static readonly int EmployeeSalary = 5;

        public static readonly List<string> RestaurantBrandsList = new List<string>
        {
            "Fried Geese & Donkey",
            "Golden Duck Diner",
            "Santa Maria Pizza",
            "Xango Blues Bar",
            "Gluttony Inc. Burgers"
        };


        public enum ActivePhase
            {
            Restructuring = 1,
            OrderOfBusiness = 2,
            Working = 3,
            DinnerTime = 4,
            PayDay = 5 }

        public static SortedDictionary<string, List<string>> EmployeeCategories = 
            new SortedDictionary<string, List<string>>()
            {
                { "finance", FinanceEmployeeNames },
                { "management", ManagementEmployeeNames },
                {"pricing", PricingEmployeeNames},
                {"hr", HREmployeeNames },
                {"beverage", BeverageEmployeeNames},
                {"marketing", MarketingEmployeeNames},
                {"kitchen", KitchenEmployeeNames}
            };


        public static List<string> FinanceEmployeeNames =
            new List<string>()
            {
                "Waitress",
                "New Business Developer",
                "CFO"
            };

        public static List<string> ManagementEmployeeNames =
            new List<string>()
            {
                "Management Trainee",
                "Junior Vice President",
                "Vice President",
                "Senior Vice President",
                "Executive Vice President"
            };

        public static List<string> PricingEmployeeNames =
            new List<string>()
            {
                "Pricing Manager",
                "Luxuries Manager",
                "Discount Manager"
            };

        public static List<string> HREmployeeNames =
            new List<string>()
            {
                "Recruiting Girl",
                "Trainer",
                "Recruiting Manager",
                "Coach",
                "Guru",
                "HR Director"
            };

        public static List<string> BeverageEmployeeNames =
            new List<string>()
            {
                "Errand Boy",
                "Cart Operator",
                "Truck Driver",
                "Zeppelin Pilot"
            };
        public static List<string> MarketingEmployeeNames =
        new List<string>()
            {
                "Marketing Trainee",
                "Campaign Manager",
                "Brand Manager",
                "Zeppelin Pilot"
            };
        public static List<string> KitchenEmployeeNames =
        new List<string>()
            { 
                "Kitche Trainee",
                "Burger Cook",
                "Pizza Cook",
                "Burger Chef",
                "Pizza Chef"
            };
    }
}
