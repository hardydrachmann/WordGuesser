using System;
using System.Diagnostics.Contracts;

namespace WordGuesser_Logic
{
    // Interface
    [ContractClass(typeof(GuessLogicContract))]
    public interface IGuessLogic
    {
        int GetGuessCount();

        void PutGuess();

        void RemoveGuess();

        void ResetGuessCount();
    }

    // Contract Class
    [ContractClassFor(typeof(IGuessLogic))]
    internal abstract class GuessLogicContract : IGuessLogic
    {
        /* BASIC QUERY */
        
        [Pure]
        public int GetGuessCount()
        {
            Contract.Ensures(Contract.Result<int>() >= 0);
            return default(int);
        }

        /* COMMANDS */
        public void PutGuess()
        {
            Contract.Ensures(GetGuessCount() == Contract.OldValue(GetGuessCount()) + 1);
        }

        public void RemoveGuess()
        {
            Contract.Requires(GetGuessCount() > 0);
            Contract.Ensures(GetGuessCount() == Contract.OldValue(GetGuessCount()) + 1);
        }

        public void ResetGuessCount()
        {
            Contract.Ensures(GetGuessCount()> 0);
        }
    }

    // Implementation Class
    public class MockGuessLogic : IGuessLogic
    {
        private int guesses = 5;

        public int GetGuessCount()
        {
            return guesses;
        }

        public void PutGuess()
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
