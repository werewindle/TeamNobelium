using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanGame;

namespace Hangman.Tests
{
    [TestClass]
    public class HangmanUserInterfaceTests
    {
        [TestMethod]
        public void TestGenerateMessageMistakesNumber()
        {
            //string message = HangmanUserInterface.GuessMessage();
            int mistakesNumber = 3;
            string expected = string.Format("You won with {0} mistakes.\n", mistakesNumber);
            string result = HangmanUserInterface.WonMessage(mistakesNumber);
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void TestGenerateMessageWonWithCheating()
        {            
            int mistakesNumber = 3;
            string expected = string.Format("You won with {0} mistakes but you have cheated. You are not allowed\n to enter into the scoreboard.\n", mistakesNumber);
            string result = HangmanUserInterface.WonWithCheatingMessage(mistakesNumber);
            Assert.AreEqual(expected, result);
        }

        /*[TestMethod]
        public void TestGenerateMessageSecretWord()
        {
            string secretWord = "developer";
            string expected = string.Format("The secret word is: {0}",secretWord);
            string result = string.Format(HangmanUserInterface.SecretWordMessage(secretWord));
            Assert.AreEqual(expected, result);
        }*/
    }
}
