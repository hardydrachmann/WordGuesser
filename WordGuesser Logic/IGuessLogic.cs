using System;
using System.Diagnostics.Contracts;

namespace WordGuesser_Logic
{
    // Interface - Informal specification
    [ContractClass(typeof(GuessLogicContract))]
    public interface IGuessLogic
    {
        IGuessLogic Initialize(int guessLimit);

        // Return the guess count
        int GetGuessCount();

        // Increment guess count
        void IncrementGuess();

        // Decrement guess count
        void DecrementGuess();

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
        // Post: Return value is greater or equals 0
        [Pure]
        public int GetGuessCount()
        {
            Contract.Ensures(Contract.Result<int>() >= 0);
            return default(int);
        }

        // Pre:
        // Post: Increment guess count by 1
        public void IncrementGuess()
        {
            Contract.Ensures(GetGuessCount() == Contract.OldValue(GetGuessCount()) + 1);
        }

        // Pre: GetGuessCount > 0
        // Post: Decrement guess count by 1
        public void DecrementGuess()
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

        public void IncrementGuess()
        {
            guesses++;
        }

        public void DecrementGuess()
        {
            guesses--;
        }

        public void ResetGuessCount()
        {
            guesses = 5;
        }
    }
}
