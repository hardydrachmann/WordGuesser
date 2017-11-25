using NUnit.Framework;
using WordGuesser_Logic;

namespace WordGuesser_Test
{

    [TestFixture()]
    public class WordLogicTest
    {
        IWordLogic logic;

        [SetUp()]
        public void SetUp()
        {
            logic = new MockWordLogic();
        }

        [Test()]
        public void TestWordGetRandomWord()
        {
            string[] words = new string[] { "hest", "pave", "farm", "buks" };
            string word = logic.GetRandomWord(words);
            Assert.Contains(word, words);
        }

        [Test()]
        public void TestEvaluateLetter()
        {
            string word = "word";
            string blanks = "_ o _ _";

            // Returns a Contract Exception when invalid value.
            Assert.That(() => logic.EvaluateLetter(word, blanks, ""),
                Throws.Exception.With.Property("Message").EqualTo("Precondition failed: !string.IsNullOrWhiteSpace(guess)"));

            Assert.That(() => logic.EvaluateLetter(word, blanks, " "),
                Throws.Exception.With.Property("Message").EqualTo("Precondition failed: !string.IsNullOrWhiteSpace(guess)"));

            Assert.That(() => logic.EvaluateLetter(word, blanks, "rd"),
                Throws.Exception.With.Property("Message").EqualTo("Precondition failed: guess.Length == 1"));

            // Returns false when invalid value.
            Assert.IsFalse(logic.EvaluateLetter(word, blanks, "k"));

            // Returns true if matches.
            Assert.IsTrue(logic.EvaluateLetter(word, blanks, "w"));
            Assert.IsTrue(logic.EvaluateLetter(word, blanks, "r"));
            Assert.IsTrue(logic.EvaluateLetter(word, blanks, "d"));
        }

        [Test()]
        public void TestEvaluateWord()
        {
            string word = "word";

            // Returns a Contract Exception when invalid value.
            Assert.That(() => logic.EvaluateWord(word, ""),
                Throws.Exception.With.Property("Message").EqualTo("Precondition failed: !string.IsNullOrWhiteSpace(guess)"));

            Assert.That(() => logic.EvaluateWord(word, " "),
                Throws.Exception.With.Property("Message").EqualTo("Precondition failed: !string.IsNullOrWhiteSpace(guess)"));

            Assert.That(() => logic.EvaluateWord(word, "w"),
                Throws.Exception.With.Property("Message").EqualTo("Precondition failed: guess.Length > 1"));

            // Returns false when invalid value.
            Assert.IsFalse(logic.EvaluateWord(word, "ord"));

            // Returns true if matches.
            Assert.IsTrue(logic.EvaluateWord(word, "word"));
        }
    }

    [TestFixture]
    public class GuessLogicTest
    {
        IGuessLogic logic;

        const int guessLimit = 5;

        [SetUp()]
        public void SetUp()
        {
            logic = new MockGuessLogic().Initialize(guessLimit);
        }

        [Test()]
        public void TestGetGuessCount()
        {
            Assert.AreEqual(guessLimit, logic.GetGuessCount());
        }

        [Test()]
        public void TestIncrementGuess()
        {
            logic.IncrementGuessCount();
            Assert.AreEqual(guessLimit + 1, logic.GetGuessCount());
        }

        [Test()]
        public void TestDecrementGuess()
        {
            logic.DecrementGuessCount();
            Assert.AreEqual(guessLimit - 1, logic.GetGuessCount());
        }

        [Test()]
        public void TestResetGuessCount()
        {
            // Remove all guesses from logic instance.
            for (int i = 0; i < guessLimit; i++)
                logic.DecrementGuessCount();

            // Assert guesses have changed.
            Assert.AreNotEqual(guessLimit, logic.GetGuessCount());

            // Reset guess count and assert that guesses have correct value.
            logic.ResetGuessCount();
            Assert.AreEqual(guessLimit, logic.GetGuessCount());
        }
    }
}
