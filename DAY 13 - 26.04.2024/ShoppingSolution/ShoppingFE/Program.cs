using ShoppingBL;
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingFE
{
    public class Program
    {
        async Task<int> GetResultFromDatabaseServer()
        {
            Thread.Sleep(5000);
            return new Random().Next();
        }
        void PrintNumbers()
        {
            lock (this)// Thread Safe
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("By " + Thread.CurrentThread.Name + " " + i);
                    Thread.Sleep(1000);
                }
            }
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Program program = new Program();
            //var number = program.GetResultFromDatabaseServer();
            //Console.WriteLine("This is the random number from main" + new Random().Next());
            //Console.WriteLine("This is the random number from server " + number.Result);
            //var number1 = await program.GetResultFromDatabaseServer();
            //Console.WriteLine(number1);
            Thread t1 = new Thread(program.PrintNumbers);
            t1.Name = "You";
            Thread t2 = new Thread(program.PrintNumbers);
            t2.Name = "Me";
            t1.Start();
            t2.Start();
            Console.WriteLine("After the thread call");

        }
    }
}

