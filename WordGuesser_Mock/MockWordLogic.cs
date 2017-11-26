using System;
using WordGuesser_Logic;

namespace WordGuesser_Mock
{
    public class MockWordLogic : IWordLogic
    {
        public string GetRandomWord(string[] words)
        {
            Random rnd = new Random();
            int index = rnd.Next(0, words.Length);

            return words[index];
        }

        public bool EvaluateLetter(string word, string blanks, string guess)
        {
            if (string.IsNullOrWhiteSpace(guess) ||
                string.IsNullOrWhiteSpace(word) ||
                guess.Length > 1 ||
                blanks.Contains(guess))
                return false;

            return word.Contains(guess);
        }

        public bool EvaluateWord(string word, string guess)
        {
            if (string.IsNullOrWhiteSpace(guess) || string.IsNullOrWhiteSpace(word))
                return false;

            return word.Equals(guess);
        }
    }
}
