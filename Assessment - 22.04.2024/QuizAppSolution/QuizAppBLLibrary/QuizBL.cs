using QuizAppModelLibrary;
using QuizDALLibrary;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using static System.Formats.Asn1.AsnWriter;

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
            throw new QuizNotFoundException();
        }

        public List<Quiz> GetAllQuiz()
        {
            List<Quiz> list = _quizRepository.GetAll();
            if(list != null)
            {
                return list;
            }
            throw new QuizNotFoundException();
        }

        public Quiz GetById(int id)
        {
            var result = _quizRepository.GetById(id);
            if (result != null)
            {
                return result;
            }
            throw new QuizNotFoundException();
        }
        public Quiz UpdateById(int id, string property)
        {
            var result = _quizRepository.GetById(id);
            if( property == "Title")
            {
                Console.WriteLine("Enter the New Title : ");
                result.Title = Console.ReadLine();
                var result2 = _quizRepository.Update(result);
                return result2;
            }
            else if (property == "Description"){
                Console.WriteLine("Enter the New Description : ");
                result.Description = Console.ReadLine();
                var result2 = _quizRepository.Update(result);
                return result2;
            }
            else if(property == "Questions")
            {
                Console.WriteLine("Here we go with the Questions:");
                foreach (var question in result.Questions)
                {
                    Console.WriteLine(question.Question);
                    for (int i = 0; i < question.Options.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {question.Options[i]}");
                    }
                    Console.Write("Is this Question to changed ? (yes/no)");
                    string answer = Console.ReadLine();
                    if (answer == "yes")
                    {
                        Console.WriteLine("Please Enter the Updated Question:");
                        question.Question = Console.ReadLine();
                        var result2 = _quizRepository.Update(result);
                        Console.WriteLine("Updated");
                        return result2;
                    }
                    else
                        continue;
                }
            }else if(property == "CorrectAnswerOption")
            {
                Console.WriteLine("Enter the New Correct Answer Option : ");
                foreach (var question in result.Questions)
                {
                    Console.WriteLine(question.Question);
                    for (int i = 0; i < question.Options.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {question.Options[i]}");
                    }
                    Console.Write("Is this Correct Option for this Question to changed ? ");
                    string answer = Console.ReadLine();
                    if (answer == "yes")
                        Console.WriteLine("Please Enter the Updated Correct Option:");
                    question.CorrectOptionIndex = Convert.ToInt32(Console.ReadLine());
                    var result2 = _quizRepository.Update(result);
                    Console.WriteLine("Updated");
                    return result2;
                }
            }
            throw new QuizNotFoundException();
        }
        

        public Quiz DeleteBYId(int key)
        {
            var result = _quizRepository.Delete(key);
            return result;
            throw new QuizNotFoundException();
        }
    }
}
