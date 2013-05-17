using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
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
            var result = wordGenerator.GenerateRandomWord();
            Assert.AreEqual(expected, result);            
        }

        [TestMethod]
        public void TestGenerateHiddenWord()
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
            string rndWord = wordsCollection[randomWord.Next(0, 10)];
            WordsRepository wordGenerator = new WordsRepository();
            string result = wordGenerator.GenerateHiddenWord(rndWord);

            StringBuilder expected = new StringBuilder();
            expected.Append(rndWord);
            for (int i = 0; i < rndWord.Length; i++)
            {
                expected[i] = '_';
            }
            rndWord = expected.ToString();        
            Assert.AreEqual(rndWord, result); 
        }
    }
}