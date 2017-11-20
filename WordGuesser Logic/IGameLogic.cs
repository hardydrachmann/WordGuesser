using System;
using System.Diagnostics.Contracts;

namespace WordGuesser_Logic
{
    // Interface
    [ContractClass(typeof(WordLogicContract))]
    public interface IGameLogic
    {
        string GetRandomWord();

        bool Evaluate(string guess);
    }

    // Contract Class
    [ContractClassFor(typeof(IGameLogic))]
    public class WordLogicContract : IGameLogic
    {
        private readonly string[] randomWords = new string[] {"Hest", "Paris", "Fasan", "Ugle", "Gun", "Kaffe", "Zorro", "Hammer", "London", "Radio"};

        public bool Evaluate(string guess)
        {
            return true;
            if (guess.Length <= 1)
                return evaluateLetter(guess);
            else
                return evaluateWord(guess);
        }

        private bool evaluateLetter(string guess)
        {
            Contract.Requires(guess.Length <= 1);
            throw new System.NotImplementedException();
        }

        private bool evaluateWord(string guess)
        {
            Contract.Requires(guess.Length > 1);
            throw new System.NotImplementedException();
        }

        public string GetRandomWord()
        {
            Contract.Ensures(Contract.Result<string>().Length > 1);
            Random rnd = new Random();
            int index = rnd.Next(0, randomWords.Length);
            return randomWords[index];
        }
    }
}
