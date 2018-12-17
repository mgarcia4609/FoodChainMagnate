using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameHelper.StaticFiles
{
    public static class HelperFunctions
    {
        public static int GetNumericInput(int maxNum)
        {
            string input = null;
            int num = 0;

            Console.WriteLine();
            Console.WriteLine("Enter a value:");
            input = Console.ReadLine();

            //if 'num' is a valid integer and is in range from 1 to 'maxNum'
            if (int.TryParse(input, out num) && RangeIsValid(num, maxNum))
            {
                return num;  
            }
            else
            {
                // if 'num' is not valid, return 0
                num = 0;
                return num;
            }
        }

        public static bool RangeIsValid(int num, int max)
        {
            if (Enumerable.Range(1, max).Contains(num))
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