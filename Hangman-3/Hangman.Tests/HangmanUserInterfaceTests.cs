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
            StringBuilder expected = new StringBuilder();
            string secretWord = "develepor";
            expected.Append("The secret word is: ");
            for (int i = 0; i < secretWord.Length; i++)
            {
                expected.AppendFormat("{0} ", secretWord[i]);
            }
            expected.ToString();
                  
            string result = HangmanUserInterface.SecretWordMessage(secretWord);
            Assert.AreEqual(expected,result);
        }*/
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
