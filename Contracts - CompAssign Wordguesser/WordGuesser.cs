using System;
using System.Collections.Generic;
using System.Linq;
using WordGuesser_Logic;

namespace Contracts___CompAssign_Wordguesser
{
    public class WordGuesser
    {
        private IGameLogic logic;

      

        public WordGuesser()
        {
            logic = new WordLogicContract();
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to Word Guesser <beta version>");
            string input = "";
            do
            {
                string word = logic.GetRandomWord();
                playRound(word);
                Console.WriteLine("\nenter 'q' to quit");
                input = Console.ReadLine();
            } while (!input.ToLower().StartsWith("q"));
        }

        private void playRound(string word)
        {
            string blanks = getBlanks(word);
            Console.WriteLine("Enter word or character from word to guess: " + blanks + " " + word);
            for (int i = 0; i < word.Length; i++)
            {
                string guess = Console.ReadLine();
                bool correct = logic.Evaluate(guess);
                if (correct)
                    blanks = substituteLetters(word, blanks, guess);
                else
                {
                    //TODO subtract life
                }
            }
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
                Console.WriteLine(blanks);
            }
            return blanks;
        }

        private int[] getIndicesOf(string value, string key)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < value.Length; i++)
            {
                string character = value[i].ToString().ToLower();
                if(character == key)
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
