using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerApp
{
    internal class Array
    {
        void ToFindTwoDigitRepeatingDigits()
        {
            int[] numbers = { 20, 30, 40, 55 };
            int CountRepeatingNumbers = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int FirstNumber, SecondNumber;
                FirstNumber = numbers[i] / 10;
                SecondNumber = numbers[i] % 10;
                if (FirstNumber == SecondNumber)
                {
                    CountRepeatingNumbers++;
                }
            }
            Console.WriteLine("The Number of Two Digit Repating : " + CountRepeatingNumbers);
        }

        void ToFindThreeDigitRepeatingDigits()
        {
            int[] numbers = { 206, 300, 444, 567 };
            int CountRepeatingNumbers2 = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int FirstNumber, SecondNumber, ThirdNumber;
                FirstNumber = numbers[i] % 10;
                SecondNumber = (numbers[i] / 10) % 10;
                ThirdNumber = (numbers[i] / 100) % 10;
                if (FirstNumber == SecondNumber && SecondNumber == ThirdNumber)
                {
                    CountRepeatingNumbers2++;
                }
            }
            Console.WriteLine("The Number of Three Digit Repating : " + CountRepeatingNumbers2);
        }
        public void UnderstandingArray()
        {
            Array array2 = new Array();
            //array2.ToFindTwoDigitRepeatingDigits();
            //array2.ToFindThreeDigitRepeatingDigits();
        }
        

    }
}
