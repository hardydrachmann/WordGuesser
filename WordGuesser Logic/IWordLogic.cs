﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGuesser_Logic
{
    // Interface
    [ContractClass(typeof(WordLogicContract))]
    public interface IWordLogic
    {
        string GetRandomWord();

        bool EvaluateLetter(string word, string blanks, string guess);

        bool EvaluateWord(string word, string blanks, string guess);
    }

    // Contract Class
    [ContractClassFor(typeof(IWordLogic))]
    internal abstract class WordLogicContract : IWordLogic
    {
        [Pure]
        public string GetRandomWord()
        {
            Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));
            Contract.Ensures(!Contract.Result<string>().Contains(" "));
            return default(string);
        }

        [Pure]
        public bool EvaluateWord(string word, string blanks, string guess)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(guess));
            Contract.Requires(!string.IsNullOrWhiteSpace(blanks));
            Contract.Requires(!string.IsNullOrWhiteSpace(word));
            Contract.Requires(guess.Length > 1);
            Contract.Ensures(Contract.Result<bool>() == word.Equals(guess));
            return default(bool);
        }

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

        public bool EvaluateWord(string word, string blanks, string guess)
        {
            if (string.IsNullOrWhiteSpace(guess) || string.IsNullOrWhiteSpace(word))
                return false;
            return word.Equals(guess);
        }
    }
}
