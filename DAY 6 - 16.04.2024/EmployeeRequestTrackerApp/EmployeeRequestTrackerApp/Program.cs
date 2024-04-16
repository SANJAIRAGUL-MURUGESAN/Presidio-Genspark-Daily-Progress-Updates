using EmployeeRequestTrackerModelLibrary;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
namespace EmployeeRequestTrackerApp
{
    public class Program
    {
        public void PrintDetails()
        {
            Console.WriteLine("Enter the Company Name : ");
            string CompanyName = Console.ReadLine()??string.Empty;
            CTS Cts2 = new CTS();
            Accenture accenture2 = new Accenture();
            if (CompanyName == "CTS")
            { 
                Cts2.GetEmployerDetails();
                Cts2.DetailsShowcase();
                // Parameterized Constructor
                CTS Cts = new CTS(101, "SANJAI RAGUL M", "Dev", "Engineer", "CTS", 60000, 7);
            }
            else if (CompanyName == "Accenture")
            {
                accenture2.GetEmployerDetails();
                accenture2.DetailsShowcase();
                // Parameterized Constructor
                Accenture accenture = new Accenture(01, "SANJAI RAGUL M", "Dev", "Engineer", "Accenture", 60000, 6);
            }
            else
            {
                Console.WriteLine("Invalid Company Name!");
            }

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.PrintDetails();
        }
    }
}
