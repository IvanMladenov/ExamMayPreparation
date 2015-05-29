using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinValidation
{
    class PinValidation
    {
        static void Main(string[] args)
        {
            
        }

        static bool IsValidPin(int[] number, int numberToCheck)
        {
            int[] numbersForProduct = new[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

            int sum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                sum += number[i] * numbersForProduct[i];
            }
            int reminder=sum%11;
            if(reminder==10)
            {
                reminder = 0;
            }
            if (numberToCheck == reminder)
            {
                return true;
            }
            return false;
        }

        static string CheckGender(int number)
        {
            if(number%2==0)
            {
                return "male";
            }
            else
            {
                return "female";
            }
        }
    }
}
