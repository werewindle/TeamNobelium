using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public string ChosenWord {get; private set;}
        public char[] SecretWord {get; private set;}


        public WordsRepository(string chosenWord, char[] secretWord)
        {
            this.ChosenWord = chosenWord;
            this.SecretWord = secretWord;
        }

        public string GenerateHiddenWord()
        {
            ChosenWord = wordsCollection[randomWord.Next(0, 10)];
            int lengthOfTheWord = ChosenWord.Length;
            for (int i = 0; i < lengthOfTheWord; i++)
            {
                SecretWord[i] = '_';
            }

            return SecretWord.ToString();
        }
    }   
}
