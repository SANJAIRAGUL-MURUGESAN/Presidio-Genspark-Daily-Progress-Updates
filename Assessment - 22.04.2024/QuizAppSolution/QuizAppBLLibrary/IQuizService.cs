using QuizAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppBLLibrary
{
    public interface IQuizService
    {
        public Quiz AddQuiz(Quiz Quiz);
        public List<Quiz> GetAllQuiz();
        public Quiz GetById(int key);
        public Quiz UpdateById(int Key, string property);
        public Quiz DeleteBYId(int key);

    }
}
