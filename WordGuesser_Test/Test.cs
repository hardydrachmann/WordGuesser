using NUnit.Framework;
using System;
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
            string blanks = "_o__";
            // Returns false when invalid value.
            Assert.IsFalse(logic.EvaluateLetter(word, blanks, ""));
            Assert.IsFalse(logic.EvaluateLetter(word, blanks, " "));
            Assert.IsFalse(logic.EvaluateLetter(word, blanks, "rd"));
            Assert.IsFalse(logic.EvaluateLetter(word, blanks, "k"));

            // Returns true if matches.

        }

        [Test()]
        public void TestEvaluateWord()
        {

        }
    }

    [TestFixture]
    public class GuessLogicTest
    {
        IGuessLogic logic;

        [SetUp()]
        public void SetUp()
        {
            logic = new MockGuessLogic();
        }

        [Test()]
        public void TestGetGuessCount()
        {

        }

        [Test()]
        public void TestAddGuess()
        {

        }

        [Test()]
        public void TestRemoveGuess()
        {

        }

        [Test()]
        public void TestResetGuessCount()
        {

        }
    }
}
