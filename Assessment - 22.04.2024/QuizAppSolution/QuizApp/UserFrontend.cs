using QuizAppBLLibrary;
using QuizAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    public class UserFrontend
    {
        UsersBL usersBL = new UsersBL();
        public void AddUser()
        {
            Users users = new Users();
            Console.WriteLine("Enter the Username : ");
            string name = Console.ReadLine();
            users.Name = name;
            Console.WriteLine("Enter the Password : ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter the EmailID : ");
            string email = Console.ReadLine();
            Console.WriteLine("User Added Successfully!,Username:"+usersBL.AddUser(users).Name);
        }

        public bool ValidUser()
        {
            Console.WriteLine("Enter the Username : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Password : ");
            string password = Console.ReadLine();
            int result = usersBL.CheckUser(name, password);
            if(result == 0)
            {
                Console.WriteLine("No Users Found!");
                return false;
            }else if(result == 1)
            {
                Console.WriteLine("Invalid Username!");
                return false;
            }
            else if(result == 2)
            {
                Console.WriteLine("Invalid Password!");
                return false;
            }
            return true;
        }
    }
}
