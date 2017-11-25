using System;
using System.Diagnostics.Contracts;

namespace WordGuesser_Logic
{
    // Interface - Informal specification
    [ContractClass(typeof(GuessLogicContract))]
    public interface IGuessLogic
    {

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
            Contract.Ensures(GetGuessCount() == Contract.OldValue(GetGuessCount()) + 1);
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
