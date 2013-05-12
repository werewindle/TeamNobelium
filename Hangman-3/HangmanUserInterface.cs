using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGame
{
    public static class HangmanUserInterface
    {
        public static string GetStartMessage(){
            string result = "Welcome to “Hangman” game. Please try to guess my secret word. \n" +
                                            "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' \nto cheat and 'exit' " +
                                            "to quit the game.";
            return result;
        }

        public static string GuessMessage()
        {
            string result = "Enter your guess: ";
            return result;
        }

        public static string WonMessage(int mistakesNumber)
        {
            string result = string.Format("You won with {0} mistakes.", mistakesNumber);
            return result;
        }

        public static string ScoreboardMessage(int mistakesNumber)
        {
            string result = "Please enter your name for the top scoreboard: ";
            return result;
        }

        public static string WonWithCheatingMessage(int mistakesNumber)
        {
            string result = string.Format("You won with {0} mistakes but you have cheated. You are not allowed\n to enter into the scoreboard.",
                mistakesNumber);
            return result;
        }

        public static string EndMessage()
        {
            string result = "Good bye!";
            return result;
        }

        public static string LettersKnownMessage(int numberOfknownLetters)
        {
            string result = string.Format("Good job! You revealed {0} letters.", numberOfknownLetters);
            return result;
        }

        public static string WrongLetterMessage(string letteter)
        {
            string result = string.Format("Sorry! There are no unrevealed letters \"{0}\".", letteter);
            return result;
        }

        public static string IncorrectCommandMessage()
        {
            string result = "Incorrect guess or command!";
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
            string result = "Empty Scoreboard!";
            return result;
        }

        public static string ScoreBoardString(List<KeyValuePair<string, int>> scoreboard)
        {
            StringBuilder result = new StringBuilder();
            result.Append("Scoreboard:");
            result.Append(Environment.NewLine);
            for (int i = 0; i < scoreboard.Count; i++)
            {
                result.AppendFormat("{0}. {1} --> {2} mistake", i + 1, scoreboard[i].Key, scoreboard[i].Value);
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }

    }
}
