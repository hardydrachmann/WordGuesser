using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGuesser_Logic
{
    // Interface - Informal specification
    [ContractClass(typeof(WordLogicContract))]
    public interface IWordLogic
    {
        // Return random string of randomWords
        string GetRandomWord();

        // Return true if guess contain word and blanks doesn't contains guess
        bool EvaluateLetter(string word, string blanks, string guess);

        // Return true if guess is equal word
        bool EvaluateWord(string word, string guess);
    }

    // Contract Class - Formal specification
    [ContractClassFor(typeof(IWordLogic))]
    internal abstract class WordLogicContract : IWordLogic
    {
        // Pre:
        // Post:
        [Pure]
        public string GetRandomWord()
        {
            Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));
            Contract.Ensures(Contract.Result<string>().Length > 1);
            Contract.Ensures(!Contract.Result<string>().Contains(" "));
            return default(string);
        }

        // Pre: True
        // Post: Result = 
        [Pure]
        public bool EvaluateWord(string word, string guess)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(guess));
            Contract.Requires(!string.IsNullOrWhiteSpace(word));
            Contract.Requires(guess.Length > 1);
            Contract.Ensures(Contract.Result<bool>() == word.Equals(guess));
            return default(bool);
        }

        // Pre: True
        // Post:
        [Pure]
        public bool EvaluateLetter(string word, string blanks, string guess)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(guess));
            Contract.Requires(!string.IsNullOrWhiteSpace(blanks));
            Contract.Requires(!string.IsNullOrWhiteSpace(word));
            Contract.Requires(!blanks.Contains(guess));
            Contract.Requires(guess.Length == 1);
            Contract.Ensures(Contract.Result<bool>() == word.Contains(guess));
            return default(bool);
        }
    }

    // Implementation Class
    public class MockWordLogic : IWordLogic
    {
        private readonly string[] randomWords = new string[] { "hest", "paris", "fasan", "ugle", "gun", "kaffe", "zorro", "hammer", "london", "radio" };

        public string GetRandomWord()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, randomWords.Length);

            return randomWords[index];
        }

        public bool EvaluateLetter(string word, string blanks, string guess)
        {
            if (string.IsNullOrWhiteSpace(guess) || string.IsNullOrWhiteSpace(word))
                return false;

            if (blanks.Contains(guess))
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
