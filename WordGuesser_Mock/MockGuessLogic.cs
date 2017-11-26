using System;
using WordGuesser_Logic;

namespace WordGuesser_Mock
{
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
