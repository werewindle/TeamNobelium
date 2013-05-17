using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanGame;
using System.Text;

namespace Hangman.Tests
{
    [TestClass]
    public class HangmanUserInterfaceTests
    {
        [TestMethod]
        public void TestWonMessage()
        {
            int mistakesNumber = 3;
            string expected = string.Format("You won with {0} mistakes.\n", mistakesNumber);
            string result = HangmanUserInterface.WonMessage(mistakesNumber);
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void TestWonWithCheatingMessage()
        {            
            int mistakesNumber = 3;
            string expected = string.Format("You won with {0} mistakes but you have cheated. You are not allowed\n to enter into the scoreboard.\n", mistakesNumber);
            string result = HangmanUserInterface.WonWithCheatingMessage(mistakesNumber);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSecretWordMessage()
        {
            string expected = "The secret word is: d e v e l o p e r ";
            string secretWord = "developer";
            string result = HangmanUserInterface.SecretWordMessage(secretWord);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWrongLetterMessage()
        {            
            string letterer = "a";
            string expected = string.Format("Sorry! There are no unrevealed letters \"{0}\".\n", letterer);
            string result = HangmanUserInterface.WrongLetterMessage(letterer);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLettersKnownMessage()
        {            
            int numberOfknownLetters = 2;
            string expected = string.Format("Good job! You revealed {0} letters.\n", numberOfknownLetters);
            string result = HangmanUserInterface.LettersKnownMessage(numberOfknownLetters);
            Assert.AreEqual(expected, result);
        }
    }
}
