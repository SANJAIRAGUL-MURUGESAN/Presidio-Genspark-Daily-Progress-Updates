using QuizAppBLLibrary;
using QuizAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace QuizApp
{
    public class QuizFrontend
    {
        QuizBL quizBL = new QuizBL();
        public void CreateQuiz()
        {
            Quiz quiz = new Quiz();
            Console.Write("Enter quiz title: ");
            quiz.Title = Console.ReadLine();
            Console.Write("Enter quiz description: ");
            quiz.Description = Console.ReadLine();
            quiz.Questions = new List<QuizQuestion>();

            while (true)
            {
                QuizQuestion question = new QuizQuestion();
                Console.Write("Enter question: ");
                question.Question = Console.ReadLine();
                question.Options = new List<string>();

                Console.Write("Enter number of options: ");
                int optionCount = int.Parse(Console.ReadLine());
                for (int i = 0; i < optionCount; i++)
                {
                    Console.Write($"Enter option {i + 1}: ");
                    question.Options.Add(Console.ReadLine());
                }

                Console.Write("Enter correct option index (1-based): ");
                question.CorrectOptionIndex = int.Parse(Console.ReadLine()) - 1;

                quiz.Questions.Add(question);

                Console.Write("Do you want to add another question? (yes/no): ");
                string addAnother = Console.ReadLine().ToLower();
                if (addAnother != "yes")
                    break;
            }
            Console.Write("Quiz Added Successfully!, ID is " + quizBL.AddQuiz(quiz).Id);
        }

        public void GetQuiz()
        {
            quizBL.GetAllQuiz();
        }

        public void TakeQuiz()
        {
            List<Quiz> quizes = quizBL.GetAllQuiz();
            if(quizes.Count == 0)
            {
                Console.Write("No Published Quizes Found");
            }
            else
            {
                Console.WriteLine("Here We go for the List of Published Quizes:");
                for (int i = 0; i < quizes.Count; i++)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine($"Quiz ID : {quizes[i].Id}");
                    Console.WriteLine();
                    Console.WriteLine($"Quiz Title : {quizes[i].Title}");
                    Console.WriteLine();
                    Console.WriteLine($"Quiz Discription : {quizes[i].Description}");
                    Console.WriteLine("------------------------------------");
                }
                Console.WriteLine("Please Enter the Quiz ID You need to Take!");
                int id = Convert.ToInt32(Console.ReadLine());
                int score = 0;
                Quiz current = quizBL.GetById(id);

                foreach (var question in current.Questions )
                {
                    Console.WriteLine(question.Question);
                    for (int i = 0; i < question.Options.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {question.Options[i]}");
                    }

                    Console.Write("Your answer (1-based): ");
                    int answer = int.Parse(Console.ReadLine()) - 1;

                    if (answer == question.CorrectOptionIndex)
                        score++;
                }
                Console.WriteLine("Your score : " + score);

            }

        }
    }
}
