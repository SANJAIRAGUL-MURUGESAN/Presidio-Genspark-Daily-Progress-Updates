//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.ComponentModel.DataAnnotations;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FirstApp
//{
//    internal class ValidCredentials
//    {
       
//        static void ValidCheck()
//        {
//            int Flag = 0;
//            int Count = 0;
//            while (Flag < 3)
//            {
//                Console.WriteLine("Enter Username : ");
//                String Username = Console.ReadLine();
//                Console.WriteLine("Enter Password : ");
//                String Password = Console.ReadLine();
//                if (Username == "ABC")
//                {
//                    if (Password == "123")
//                    {
//                        Count = 1;
//                        break;
//                    }
//                    Console.WriteLine("Invalid Password! Please Try Again.");

//                }
//                Console.WriteLine("Invalid Username! Please Try Again.");
//                Flag++;
//            }
//            if(Count == 1)
//            {
//                Console.WriteLine("Valid Username and Password.Login Successful!");
//            }
//            else
//            {
//                Console.WriteLine("You have reached you Access Limits. Access denied!");
//            }
            
            
//        }
//        static void Main(string[] args)
//        {
//            ValidCheck();
//        }
//    }
//}
