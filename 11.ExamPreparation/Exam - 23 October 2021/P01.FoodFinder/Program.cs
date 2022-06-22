using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = new string[4] { "pear", "flour", "pork", "olive" };

            char[] firstInput = Console.ReadLine()
                                .Split(" ", StringSplitOptions
                                .RemoveEmptyEntries)
                                .Select(char.Parse).ToArray();

            char[] secondInput = Console.ReadLine()
                               .Split(" ", StringSplitOptions
                               .RemoveEmptyEntries)
                               .Select(char.Parse).ToArray();

            Queue<char> vowels = new Queue<char>(firstInput);
            Stack<char> consonants = new Stack<char>(secondInput);
            List<char> storedLetters = new List<char>();

            while (consonants.Count > 0)
            {
                char currVowel = vowels.Dequeue();
                char currConsonant = consonants.Pop();
                foreach (string word in words)
                {
                    if (word.Contains(currVowel) && !storedLetters.Contains(currVowel))
                    {
                        storedLetters.Add(currVowel);
                    }

                    if (word.Contains(currConsonant) && !storedLetters.Contains(currConsonant))
                    {
                        storedLetters.Add(currConsonant);
                    }
                }

                vowels.Enqueue(currVowel);
            }

            List<string> wordsFound = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                string currWord = words[i];

                foreach (char  letter in storedLetters)
                {
                    if (words[i].Contains(letter))
                    {
                        int currLetterIndex = currWord.IndexOf(letter);
                        currWord = currWord.Remove(currLetterIndex, 1);

                        if (string.IsNullOrWhiteSpace(currWord))
                        {
                            wordsFound.Add(words[i]);
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"Words found: {wordsFound.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, wordsFound));
        }
    }
}
