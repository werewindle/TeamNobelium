using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanGame;

namespace Hangman.Tests
{
    [TestClass]
    public class WordsRepositoryTests
    {
        [TestMethod]
        public void TestGenerateRandomWord()
        {
            Random randomWord = new Random();
            string[] wordsCollection =
            {
                "computer",
                "programmer",
                "software",
                "debugger",
                "compiler",
                "developer",
                "algorithm",
                "array",
                "method",
                "variable"
            };
            string expected = wordsCollection[randomWord.Next(0, 10)];
            WordsRepository wordGenerator = new WordsRepository();
            string result = wordGenerator.GenerateRandomWord();
            Assert.AreEqual(expected, result);            
        }

        [TestMethod]
        public void TestGenerateHiddenWord()
        {
          
        }
    }
}
