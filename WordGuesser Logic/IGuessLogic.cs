using System;
using System.Diagnostics.Contracts;

namespace WordGuesser_Logic
{
    // Interface - Informal specification
    [ContractClass(typeof(GuessLogicContract))]
    public interface IGuessLogic
    {
        IGuessLogic Initialize(int guessLimit);

        // Return the number of guesses count
        int GetGuessCount();

        // Add guess
        void PutGuess();

        // Remove guess
        void RemoveGuess();

        // Reset guess count
        void ResetGuessCount();
    }

    // Contract Class - Formal specification
    [ContractClassFor(typeof(IGuessLogic))]
    internal abstract class GuessLogicContract : IGuessLogic
    {
        public IGuessLogic Initialize(int guessLimit)
        {
            Contract.Requires(guessLimit > 0);
            Contract.Ensures(GetGuessCount() == guessLimit);
            return default(IGuessLogic);
        }

        /* BASIC QUERY */
        // Pre: 
        // Post: 
        [Pure]
        public int GetGuessCount()
        {
            Contract.Ensures(Contract.Result<int>() >= 0);
            return default(int);
        }

        // Pre:
        // Post: 
        public void PutGuess()
        {
            Contract.Ensures(GetGuessCount() == Contract.OldValue(GetGuessCount()) + 1);
        }

        // Pre:
        // Post:
        public void RemoveGuess()
        {
            Contract.Requires(GetGuessCount() > 0);
            Contract.Ensures(GetGuessCount() == Contract.OldValue(GetGuessCount()) - 1);
        }

        // Pre:
        // Post:
        public void ResetGuessCount()
        {
            Contract.Ensures(GetGuessCount() > 0);
        }
    }

    // Implementation Class
    public class MockGuessLogic : IGuessLogic
    {
        private int guesses;

        public IGuessLogic Initialize(int guessLimit)
        {
            this.guesses = guessLimit;
            return this;
        }

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
