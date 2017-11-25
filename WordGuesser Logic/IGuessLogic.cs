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
        void IncrementGuessCount();

        // Decrement guess count
        void DecrementGuessCount();

        // Reset guess count
        void ResetGuessCount();
    }





    // Contract Class - Formal specification
    [ContractClassFor(typeof(IGuessLogic))]
    internal abstract class GuessLogicContract : IGuessLogic
    {


        /* --- BASIC QUERY --- */

        
        // Post: Return value is greater or equals 0
        [Pure]
        public int GetGuessCount()
        {
            Contract.Ensures(Contract.Result<int>() >= 0);
            return default(int);
        }
        

        /* --- COMMANDS --- */
        

        // Pre: GuessLimit > 0
        // Post: 
        public IGuessLogic Initialize(int guessLimit)
        {
            Contract.Requires(guessLimit > 0);
            Contract.Ensures(GetGuessCount() == guessLimit);
            return default(IGuessLogic);
        }
        

        // Post: Guess count has been incremented by 1
        public void IncrementGuessCount()
        {
            Contract.Ensures(GetGuessCount() == Contract.OldValue(GetGuessCount()) + 1);
        }

        // Pre: guess > 0
        // Post: Guess count has been decremented by 1
        public void DecrementGuessCount()
        {
            Contract.Requires(GetGuessCount() > 0);
            Contract.Ensures(GetGuessCount() == Contract.OldValue(GetGuessCount()) - 1);
        }
        
        // Post: Guess count are reset
        public void ResetGuessCount()
        {
            Contract.Ensures(GetGuessCount() > 0);
        }
        
    }





    // Implementation Class
    public class MockGuessLogic : IGuessLogic
    {
        private int guessLimit;
        private int guesses;

        public IGuessLogic Initialize(int guessLimit)
        {
            this.guessLimit = guessLimit;
            this.guesses = guessLimit;
            return this;
        }

        public int GetGuessCount()
        {
            return guesses;
        }

        public void IncrementGuessCount()
        {
            guesses++;
        }

        public void DecrementGuessCount()
        {
            guesses--;
        }

        public void ResetGuessCount()
        {
            guesses = guessLimit;
        }
    }
}
