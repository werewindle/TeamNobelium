using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGame
{
    public class WordsRepository
    {
        private readonly string[] wordsCollection =
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
        private readonly string theChosenWord = wordsCollection[randomWord.Next(0, 10)];
        private readonly int lengthOfTheWord = theChosenWord.Length;
        private readonly char[] secretWord = new char[lengthOfTheWord];

        public string GenerateWord()
        {        
            for (int i = 0; i < lengthOfTheWord; i++)
            {
                secretWord[i] = '_';
            }

            return secretWord.ToString();
        }
    }   
}
