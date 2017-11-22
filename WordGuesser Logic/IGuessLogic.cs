using System;
using System.Diagnostics.Contracts;

namespace WordGuesser_Logic
{
    // Interface
    [ContractClass(typeof(GuessLogicContract))]
    public interface IGuessLogic
    {
        int GetGuesses();

        void AddGuess();

        void RemoveGuess();

        void ResetGuessCount();
    }

    // Contract Class
    [ContractClassFor(typeof(IGuessLogic))]
    internal abstract class GuessLogicContract : IGuessLogic
    {
        [Pure]
        public int GetGuesses()
        {
            Contract.Ensures(Contract.Result<int>() >= 0);
            return default(int);
        }

        public void AddGuess()
        {
            //Contract.Ensures(Contract.OldValue(guesses) == guesses + 1);
        }

        public void RemoveGuess()
        {
            //Contract.Ensures(Contract.OldValue(guesses) == guesses - 1);
        }

        public void ResetGuessCount()
        {
            //Contract.Ensures(guesses > 0);
        }
    }

    public class MockGuessLogic : IGuessLogic
    {
        private int guesses = 5;

        public int GetGuesses()
        {
            return guesses;
        }

        public void AddGuess()
        {
            guesses++;
        }

        public void RemoveGuess()
        {
            guesses--;
        }

        public void ResetGuessCount()
        {
            guesses = 5;
        }
    }
}
