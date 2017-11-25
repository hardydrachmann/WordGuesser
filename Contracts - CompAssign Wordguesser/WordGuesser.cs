using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WordGuesser_Logic;

namespace Contracts___CompAssign_Wordguesser
{
    public class WordGuesser
    {
        private IGuessLogic guessLogic;
        private IWordLogic wordLogic;

        private readonly string[] words = new string[] { "hest", "paris", "fasan", "ugle", "gun", "kaffe", "zorro", "hammer", "london", "radio" };
        private const int guessLimit = 5;

        public WordGuesser()
        {
            guessLogic = new MockGuessLogic().Initialize(guessLimit);
            wordLogic = new MockWordLogic();
        }

        public void StartGame()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Welcome to Word Guesser <beta version>");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            string input = "";
            do
            {
                string word = wordLogic.GetRandomWord(words);
                playRound(word);
                Console.WriteLine("\nType 'q' to quit or press 'Enter' to play");
                input = Console.ReadLine()?.ToLower();
                Console.Clear();
            } while (!input.StartsWith("q"));
        }

        private void playRound(string word)
        {
            string blanks = getBlanks(word);
            Console.WriteLine("Enter word or character from word to guess: " + blanks + " " + word + "\n");
            while (guessLogic.GetGuessCount() > 0)
            {
                Console.Write("> ");
                string guess = Console.ReadLine()?.ToLower();
                bool correct;
                if(guess.Length > 1)
                    correct = wordLogic.EvaluateWord(word, guess);
                else 
                    correct = wordLogic.EvaluateLetter(word, blanks, guess);
                if (correct)
                {
                    blanks = substituteLetters(word, blanks, guess);
                    guessLogic.IncrementGuess();
                    string guessProgress = blanks.Replace(" ", "");
                    bool hasWon = wordLogic.EvaluateWord(word, guessProgress);
                    if (hasWon)
                    {
                        Console.Clear();
                        Console.WriteLine("You Won! " + blanks.Replace(" ", ""));
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("Correct!");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.Write("Wrong!");
                    guessLogic.DecrementGuess();
                }
                Console.WriteLine(" Guesses left: " + guessLogic.GetGuessCount());
                Console.WriteLine(blanks + "\n");
            }
            guessLogic.ResetGuessCount();
        }

        private string substituteLetters(string word, string blanks, string guess)
        {
            if (word.Length == guess.Length)
                return word;
            else
            {
                int[] matches = getIndicesOf(word, guess);
                for (int i = 0; i < matches.Length; i++)
                {
                    int index = matches[i] * 2;
                    string firstHalf = blanks.Substring(0, index);
                    string secondHalf = blanks.Substring(index + 1, blanks.Length - index - 1);
                    blanks = firstHalf + guess + secondHalf;
                }
            }
            return blanks;
        }

        private int[] getIndicesOf(string value, string key)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < value.Length; i++)
            {
                string character = value[i].ToString();
                if (character == key)
                    indices.Add(i);
            }
            return indices.ToArray();
        }

        private string getBlanks(string word)
        {
            string blanks = "";
            for (int i = 0; i < word.Length; i++)
                blanks += "_ ";
            return blanks;
        }
    }
}
