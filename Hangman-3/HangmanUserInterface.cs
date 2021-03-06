﻿namespace HangmanGame
{
    using System;
    using System.Linq;
    using System.Text;

    public static class HangmanUserInterface
    {
        public static string GetStartMessage()
        {
            string result = "Welcome to “Hangman” game. Please try to guess my secret word. \n" +
                                            "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' \nto cheat and 'exit' " +
                                            "to quit the game.\n";
            return result;
        }

        public static string GuessMessage()
        {
            string result = "Enter your guess: ";
            return result;
        }

        public static string WonMessage(int mistakesNumber)
        {
            string result = string.Format("You won with {0} mistakes.\n", mistakesNumber);
            return result;
        }

        public static string ScoreboardMessage()
        {
            string result = "Please enter your name for the top scoreboard: ";
            return result;
        }

        public static string WonWithCheatingMessage(int mistakesNumber)
        {
            string result = string.Format("You won with {0} mistakes but you have cheated. You are not allowed\n to enter into the scoreboard.\n",
                mistakesNumber);
            return result;
        }

        public static string EndMessage()
        {
            string result = "Good bye!\n";
            return result;
        }

        public static string LettersKnownMessage(int numberOfknownLetters)
        {
            string result = string.Format("Good job! You revealed {0} letters.\n", numberOfknownLetters);
            return result;
        }

        public static string WrongLetterMessage(string letteter)
        {
            string result = string.Format("Sorry! There are no unrevealed letters \"{0}\".\n", letteter);
            return result;
        }

        public static string IncorrectCommandMessage()
        {
            string result = "Incorrect guess or command!\n";
            return result;
        }

        public static string SecretWordMessage(string secretWord)
        {
            StringBuilder result = new StringBuilder();
            result.Append("The secret word is: ");
            for (int i = 0; i < secretWord.Length; i++)
            {
                result.AppendFormat("{0} ", secretWord[i]);
            }

            return result.ToString();
        }

        public static string NameAlreadyExistMessage()
        {
            string result = "This name already exists in the Scoreboard! Type another: ";
            return result;
        }

        public static string EmptyScoreboardMessage()
        {
            string result = "Empty Scoreboard!\n";
            return result;
        }
    }
}
