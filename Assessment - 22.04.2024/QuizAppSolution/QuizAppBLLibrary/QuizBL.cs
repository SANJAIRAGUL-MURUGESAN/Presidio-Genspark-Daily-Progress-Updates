using QuizAppModelLibrary;
using QuizDALLibrary;
using System.Collections.Generic;

namespace QuizAppBLLibrary
{
    public class QuizBL : IQuizService
    {
        readonly IRepository<int, Quiz> _quizRepository;
        public QuizBL()
        {
            _quizRepository = new QuizRepository();
        }
        public Quiz AddQuiz(Quiz Quiz)
        {
            var result = _quizRepository.Add(Quiz);
            if(result != null)
            {
                return result;
            }
            throw new NotImplementedException();
        }

        public List<Quiz> GetAllQuiz()
        {
            List<Quiz> list = _quizRepository.GetAll();
            return list;
        }

        public Quiz GetById(int id)
        {
            var result = _quizRepository.GetById(id);
            return result;
            throw new NotImplementedException();
        }
    }
}
