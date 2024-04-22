using QuizAppModelLibrary;

namespace QuizApp
{
    public class Program
    {
    private static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Welcome to the Quiz Application!");
            Console.WriteLine($"1. Add Quiz");
            Console.WriteLine($"2. Get Quiz");
            Console.WriteLine($"3. Take Quiz");
            QuizFrontend quizfrontend = new QuizFrontend();
            while (true)
            {
                Console.WriteLine("Enter the Option:");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        quizfrontend.CreateQuiz();
                        break;
                    case 2:
                        quizfrontend.GetQuiz();
                        break;
                    case 3:
                        quizfrontend.TakeQuiz();
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
    }
}
