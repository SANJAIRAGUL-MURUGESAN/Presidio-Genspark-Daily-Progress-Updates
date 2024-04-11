//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FirstApp
//{
//    internal class Greatest
//    {
//        static void FindTheGreatest()
//        {
//            int Max = int.MinValue;
//            while (true)
//            {
//                Console.Write("Enter the number: ");
//                int number = Convert.ToInt32(Console.ReadLine());

//                if (number < 0)
//                    break;

//                if (number > Max)
//                    Max = number;
//            }
//            if (Max != int.MinValue)
//                Console.WriteLine("The greatest number entered is: " + Max);
//            else
//                Console.WriteLine("No valid numbers were entered.");
//        }
//        static void Main(string[] args)
//        {
//            FindTheGreatest();
//        }
//    }
//}
