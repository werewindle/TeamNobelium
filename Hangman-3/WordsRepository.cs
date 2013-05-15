using System;
using System.Linq;

namespace HangmanGame
{
    public class WordsRepository
    {
        public string[] wordsCollection =
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

        readonly Random randomWord = new Random();

        public string GenerateRandomWord()
        {
            string randomlySelectedWord = wordsCollection[randomWord.Next(0, 10)];
            return randomlySelectedWord;
        }

        public string GenerateHiddenWord(string secretWord)
        {
            int lengthOfTheWord = secretWord.Length;
            for (int i = 0; i < lengthOfTheWord; i++)
            {
                secretWord[i] = '_';
            }

            return secretWord.ToString();
        }
    }   
}
