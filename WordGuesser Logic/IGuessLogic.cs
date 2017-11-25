using System;
using System.Diagnostics.Contracts;

namespace WordGuesser_Logic
{
    // Interface - Informal specification
    [ContractClass(typeof(GuessLogicContract))]
    public interface IGuessLogic
    {
        // Return the number of guesses count
        int GetGuesses();

        // Add guess
        void AddGuess();

        // Remove guess
        void RemoveGuess();

        // Reset guess count
        void ResetGuessCount();
    }

    // Contract Class - Formal specification
    [ContractClassFor(typeof(IGuessLogic))]
    internal abstract class GuessLogicContract : IGuessLogic
    {
        // Pre: 
        // Post: 
        [Pure]
        public int GetGuesses()
        {
            Contract.Ensures(Contract.Result<int>() >= 0);
            return default(int);
        }

        // Pre:
        // Post: 
        public void AddGuess()
        {
            Contract.Ensures(Contract.OldValue(GetGuesses()) == GetGuesses() + 1);
        }

        // Pre:
        // Post:
        public void RemoveGuess()
        {
            Contract.Requires(GetGuesses() > 0);
            Contract.Ensures(Contract.OldValue(GetGuesses()) == GetGuesses()- 1);
        }

        // Pre:
        // Post:
        public void ResetGuessCount()
        {
            Contract.Ensures(GetGuesses()> 0);
        }
    }

    // Implementation Class
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
