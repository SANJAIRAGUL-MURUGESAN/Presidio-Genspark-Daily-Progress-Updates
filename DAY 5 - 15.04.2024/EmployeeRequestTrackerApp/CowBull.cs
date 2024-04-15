using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerApp
{
    public class CowBull
    {
        public void StartGame()
        {
            string word = "golf";
            int cows = 0;
            int bulls = 0;

            Console.WriteLine("Welcome to the Cow and Bull game!");
            Console.WriteLine("Try to guess the 4-letter word.");

            while (true)
            {
                Console.Write("Enter your guess: ");
                string guess = Console.ReadLine();

                if (guess.Length == 0 || guess.Length != 4)
                {
                    Console.WriteLine("Please enter a 4-letter word.");
                    continue;
                }

                cows = 0;
                bulls = 0;

                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == guess[i])
                    {
                        cows++;
                    }
                    else if (word.Contains(guess[i]))
                    {
                        bulls++;
                    }
                }

                Console.WriteLine($"cows - {cows}, bulls - {bulls}");

                if (cows == 4)
                {
                    Console.WriteLine("Congrats!!! you won!!!!!");
                    break;
                }
            }
        }
        
    }
}
