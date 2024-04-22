using QuizAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppBLLibrary
{
    public interface IUserService
    {
        public Users AddUser(Users employee);

        public int CheckUser(string name, string password);
    }
}
