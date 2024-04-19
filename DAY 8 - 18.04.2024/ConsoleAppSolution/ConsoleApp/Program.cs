using System.Globalization;

namespace ConsoleApp
{
    public class Indexer
    {
        string[] values = new string[3];
        public string this[int index]
        {
            get
            {
                return values[index];
            }
            set
            {
                values[index] = value;
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Indexer indexer = new Indexer();
            indexer[0] = "xxx";
            indexer[1] = "yyy";
            indexer[2] = "zzz";

            Console.WriteLine(indexer[0]+" " + indexer[1]+" " + indexer[2]);
        }
    }
}
