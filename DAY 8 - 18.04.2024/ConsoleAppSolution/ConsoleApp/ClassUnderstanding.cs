using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ClassUnderstanding
    {
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }

        public ClassUnderstanding()
        {
            CustomerFirstName = string.Empty;
            CustomerLastName = string.Empty;
        }

        public ClassUnderstanding(string Customerfirstname,string Customerlastname)
        {
            CustomerFirstName = Customerfirstname;
            CustomerLastName = Customerlastname;
        }
    }
}
