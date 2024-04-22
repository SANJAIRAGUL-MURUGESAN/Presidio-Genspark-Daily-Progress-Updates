using QuizAppBLLibrary;
using QuizAppModelLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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
            try
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
            }catch(QuizNotFoundException qnfe)
            {
                Console.WriteLine(qnfe.Message);
            }
        }

        public void GetQuiz()
        {
            try
            {
                List<Quiz> list = quizBL.GetAllQuiz();
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine($"Quiz ID : {list[i].Id}");
                        Console.WriteLine();
                        Console.WriteLine($"Quiz Title : {list[i].Title}");
                        Console.WriteLine();
                        Console.WriteLine($"Quiz Discription : {list[i].Description}");
                        Console.WriteLine("------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("No Quizs Found!");
                }
            }catch(QuizNotFoundException qnfe){
                Console.WriteLine(qnfe.Message);
            }
        }

        public void TakeQuiz()
        {
            try
            {
                Dictionary<string, int> Review = new Dictionary<string, int>(); ;
                List<Quiz> quizes = quizBL.GetAllQuiz();
                if (quizes.Count == 0)
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

                    foreach (var question in current.Questions)
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
                        else
                            Review.Add(question.Question, question.CorrectOptionIndex);
                    }
                    Console.WriteLine("Your score : " + score);
                    Console.WriteLine("Need to Review the Current Quiz ?(yes/no)");
                    string input = Console.ReadLine();
                    if (input == "yes")
                    {
                        int flag = 0;
                        foreach (var question in current.Questions)
                        {
                            if (Review.ContainsKey(question.Question))
                            {
                                Console.WriteLine("Question:");
                                flag = 1;
                                Console.WriteLine($"{question.Question}");
                                for (int i = 0; i < question.Options.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {question.Options[i]}");
                                }
                                Console.WriteLine("Correct Answer is:" + question.Options[question.CorrectOptionIndex]);
                            }
                        }
                        if (flag == 0)
                        {
                            Console.WriteLine("Hurray! All correct.");
                        }

                    }

                }
            }catch(QuizNotFoundException qnfe)
            {
                Console.WriteLine(qnfe.Message);
            }
        }
        public void EditQuiz()
        {
            try
            {
                List<Quiz> quizes = quizBL.GetAllQuiz();
                if (quizes.Count == 0)
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
                    Console.WriteLine("Please Enter the Quiz ID You need to Edit!");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Quiz current = quizBL.GetById(id);
                    Console.WriteLine("Here We go for your Quiz!");
                    Console.WriteLine($"1. Edit Title");
                    Console.WriteLine($"2. Edit Description");
                    Console.WriteLine($"3. Edit Questions");
                    Console.WriteLine($"4. Edit Correct Answer Option");
                    String Property = null;
                    while (true)
                    {
                        Console.WriteLine("Enter the Option:");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Property = "Title";
                                break;
                            case 2:
                                Property = "Description";
                                break;
                            case 3:
                                Property = "Questions";
                                break;
                            case 4:
                                Property = "CorrectAnswerOption";
                                break;
                            default:
                                Console.WriteLine("Invalid choice! Please try again.");
                                break;
                        }
                        break;
                    }
                    Console.WriteLine("Updated Quiz Title : " + quizBL.UpdateById(id, Property).Title);
                }
            }catch(QuizNotFoundException qnfe)
            {
                Console.WriteLine(qnfe.Message);
            }
        }

        public void DeleteQuiz()
        {
            try
            {
                Console.WriteLine("Enter the ID of the Quiz to Delete : ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Deleted Quiz Title : " + quizBL.GetById(id).Title);
            }
            catch (QuizNotFoundException qnfe)
            {
                Console.WriteLine(qnfe.Message);
            }
        }
    }
}
