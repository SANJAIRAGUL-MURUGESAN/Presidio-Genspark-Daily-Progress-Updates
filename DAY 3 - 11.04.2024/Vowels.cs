﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class Vowels
    {
        static int CountRepeatingVowels(string word)
        {
            string vowels = "aeiouAEIOU";
            int count = 0;
            HashSet<char> counted = new HashSet<char>();

            foreach (char c in word)
            { 
                if (vowels.Contains(c) && !counted.Contains(c))
                {
                    int occurrences = word.Count(ch => ch == c);
                    if (occurrences > 1)
                    {
                        count += occurrences - 1; 
                        counted.Add(c);
                    }
                }
            }
            return count;
        }
        static void FindMinimum()
        {
            Console.WriteLine("Enter the String : ");
            string String = Console.ReadLine();
            string[] words = String.Split(",");
            Dictionary<string, int> WordVowelCounts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                int vowelCount = CountRepeatingVowels(word);
                Console.WriteLine(word + " " + vowelCount);
                if (!WordVowelCounts.ContainsKey(word))
                {
                    WordVowelCounts.Add(word, vowelCount);
                }
            }
            int minVowelCount = WordVowelCounts.Min(kv => kv.Value);
            List<string> minVowelWords = WordVowelCounts.Where(kv => kv.Value == minVowelCount).Select(kv => kv.Key).ToList();
            foreach (string word in minVowelWords)
            {
                Console.WriteLine($"Word: {word}, Vowel Count: {minVowelCount}");
            }
        }
        static void Main(string[] args)
        {
            FindMinimum();
        }
    }
}
