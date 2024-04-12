using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class DivisibleBy7
    {
        static int CalculateDivisbleBy7()
        {
            int count = 0, sum = 0;
            while (true)
            {
                Console.WriteLine("Enter the number: ");
                int Number = Convert.ToInt32(Console.ReadLine());

                if (Number < 0)
                    break;

                if (Number % 7 == 0)
                {
                    count++;
                    sum = sum + Number;
                }
            }
            if (count == 0)
            {
                return 0;
            }
            return sum / count;
        }
        static void Main(string[] args)
        {
            int average = CalculateDivisbleBy7();
            if (average == 0)
            {
                Console.WriteLine("There were no Valid Numbers Added!");
            }
            else
                Console.WriteLine("The Average of the Numbers divisible by 7 is " + average);
        }
    }
}
