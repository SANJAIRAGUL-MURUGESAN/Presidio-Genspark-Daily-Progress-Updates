using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppModelLibrary
{
    public class QuizNotFoundException : Exception
    {
        string msg;
        public QuizNotFoundException()
        {
            msg = "No Quiz Found!";
        }
        public override string Message => msg;
    }
}
