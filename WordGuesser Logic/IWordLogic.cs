using System.Diagnostics.Contracts;
using System.Linq;

namespace WordGuesser_Logic
{
    // Interface - Informal specification
    [ContractClass(typeof(WordLogicContract))]
    public interface IWordLogic
    {
        // Return a random string of randomWords
        string GetRandomWord(string[] words);

        // Return true if guess contain word and blanks doesn't contains guess
        bool EvaluateLetter(string word, string blanks, string guess);

        // Return true if guess is equal word
        bool EvaluateWord(string word, string guess);
    }

    // Contract Class - Formal specification
    [ContractClassFor(typeof(IWordLogic))]
    internal abstract class WordLogicContract : IWordLogic
    {
        /* --- BASIC QUERIES --- */
        
        // Pre: Array argument has a length greater than 1
        // Post: Return value is a string with a length greater than 1 which contains no whitespace
        [Pure]
        public string GetRandomWord(string[] words)
        {
            Contract.Requires(words.Length > 1);
            Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));
            Contract.Ensures(Contract.Result<string>().Length > 1);
            Contract.Ensures(!Contract.Result<string>().Contains(" "));
            Contract.Ensures(words.Contains(Contract.Result<string>()));
            return default(string);
        }

        // Pre: Arguments must not be empty strings and the length of the guess argument must be greater than one.
        // Post: The return value must be a boolean reflecting whether the arguments are equal - or false if preconditions are violated.
        [Pure]
        public bool EvaluateWord(string word, string guess)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(guess));
            Contract.Requires(!string.IsNullOrWhiteSpace(word));
            Contract.Requires(guess.Length > 1);
            Contract.Ensures(Contract.Result<bool>() == word.Equals(guess));
            return default(bool);
        }

        // Pre: Arguments must not be empty strings and the length of the guess argument must be equal to one - the guess argument must also not be contained in the blanks argument.
        // Post: The return value must be a boolean reflecting whether the guess argument is contained within the word argument or false if preconditions are violated.
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
}
