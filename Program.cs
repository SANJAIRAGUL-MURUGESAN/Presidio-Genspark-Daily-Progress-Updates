//namespace FirstApp
//{
//    internal class Program
//    {
//        static int Add(int a,int b)
//        {
//            checked{
//                int result = a + b;
//                return result;
//            }
//            //return (a + b);
//        }
//        static int TakeNumber()
//        {
//            Console.WriteLine("Please Enter the Number :");
//            return Convert.ToInt32(Console.ReadLine());
//        }
//        static void Print(int Sum)
//        {
//            Console.WriteLine("The sum is " + Sum);
//        }
//        static void calculate()
//        {
//            int num1, num2; 
//            num1 = TakeNumber();
//            num2 = TakeNumber();
//            int sum = Add(num1, num2);
//            Print(sum);
//        }

//        //Out Paramter
//        static bool ConvertName(string name,out string msg)
//        {
//            msg = "";
//            if(name is null)
//            {
//                return false;
//            }
//            msg = "Welcome " + name + " !!!";
//            return true;
//        }
//        ////static void Main(string[] args)
//        ////{
//            //Console.WriteLine("Hello, World!");
//            //int num1 = 10;
//            //Console.WriteLine("The Number is " + num1);
//            ////Console.WriteLine($"The Number is {num1}");
//            //string s1;
//            //Console.WriteLine("Enter Your Name");
//            //s1 = Console.ReadLine();
//            //Console.WriteLine($"Welcome {s1}!");
//            //int num2;
//            //Console.WriteLine($"Enter your First Number {s1}");
//            //num2 = int.Parse(Console.ReadLine());
//            //num2++;
//            //Console.WriteLine("The incremented Number is " + num2);
//            //string s2 = null;
//            //int num3 = Convert.ToInt32(s2);
//            //num3++;
//            //Console.WriteLine("The second incremented number is " + num3);
//            //float fnum1;
//            //int inum2;
//            //Console.WriteLine("Please Enter a Number ");
//            //fnum1 = Convert.ToSingle(Console.ReadLine()); // Unboxing
//            //Console.WriteLine("The Number is " + fnum1);
//            //inum2 = (int)fnum1;
//            //Console.WriteLine("The Number is " + inum2);
//            //calculate();
//            string name = "Sanjai";
//            string message;
//            bool result = ConvertName(name,out message);
//            if(result is true)
//            {
//                Console.WriteLine(message);
//            }
//        }
//    }
//}
