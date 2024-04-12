using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class Mathematics
    {
        static int Sum(int num1, int num2)
        {
            checked
            {
                int result = num1 + num2;
                return result;
            }
        }

        static int Product(int num1, int num2)
        {
            return (num1 * num2);
        }

        static int Substract(int num1, int num2)
        {
            return num2 - num1;
        }
        static int Divide(int num1, int num2)
        {
            if (num2 != 0)
            {
                return num1 / num2;
            }
            return num1;
        }

        static int RemainderFind(int num1, int num2)
        {
            return num1 % num2;
        }
        static void GetNumbers()
        {
            Console.WriteLine("Enter the Number 1 : ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Number 2 : ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int Addition = Sum(num1, num2);
            int Multiplication = Product(num1, num2);
            int Substraction = Substract(num1, num2);
            int Division = Divide(num1, num2);
            Console.WriteLine($"The Sum of the {num1} and {num2} is {Addition}");
            Console.WriteLine($"The Multiplication of the {num1} and {num2} is {Multiplication}");
            Console.WriteLine($"The Subsrtaction of the {num1} and {num2} is {Substraction}");
            Console.WriteLine($"The Divsion of the {num1} and {num2} is {Division}");
            if (num1 % num2 == 0)
            {
                int Remainder = RemainderFind(num1, num2);
                Console.WriteLine($"The Remainder of the {num1} and {num2} is {Remainder}");
            }

        }
        static void Calculate()
        {
            GetNumbers();
        }
        static void Main(string[] args)
        {
            Calculate();
        }
    }
}
