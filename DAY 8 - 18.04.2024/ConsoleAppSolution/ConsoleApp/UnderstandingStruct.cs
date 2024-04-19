using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public struct UnderstandingStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UnderstandingStruct()
        {
            Id = 0;
            Name = string.Empty;
        }

        public UnderstandingStruct(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void PrintCustomerDetails()
        {
            Console.WriteLine("Customer ID : " + Id);
            Console.WriteLine("Customer Name : " + Name);
        }
    }
}
