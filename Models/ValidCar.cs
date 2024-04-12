using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingBasicsApp.Models
{
    internal class ValidCar
    {
        public void IsValidCar()
        {
            
            Console.WriteLine("Enter the Car Credential : ");

            string String = Console.ReadLine();

            char[] CharArray = String.ToCharArray();

            int[] Arrays = new int[String.Length];

            int index = 0;

            for (int i = CharArray.Length - 1; i >= 0; i--)
            {
                int Number;
                if (int.TryParse(CharArray[i].ToString(), out Number)){
                    Arrays[index] = Number;
                    index++;
                }
                else
                {
                    Console.WriteLine("Something Went Wrong during Convertion! Please Try Again.");
                }

            }

            for (int i = 1; i < Arrays.Length; i=i+2)
            {
                Arrays[i] = Arrays[i] * 2;
            }

            for (int i = 0; i < Arrays.Length; i++)
            {
                if (Arrays[i] >= 10 && Arrays[i] <= 99)
                {
                    int OnesDigit = Arrays[i] % 10;
                    int TensDigit = Arrays[i] / 10;
                    Arrays[i] = OnesDigit + TensDigit;
                }
            }

            int Sum = 0;
            for(int i = 0; i < Arrays.Length; i++)
            {
                Sum = Sum + Arrays[i];
            }
            Console.WriteLine($"{Sum}");

            if (Sum % 10 == 0)
            {
                Console.WriteLine("Provided Number is a Valid Number");
            }
            else
            {
                Console.WriteLine("Provided Number is Not a Valid Number");
            }

        }


    }
}
