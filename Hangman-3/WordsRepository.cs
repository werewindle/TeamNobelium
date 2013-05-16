namespace HangmanGame
{
    using System;
    using System.Linq;
    using System.Text;

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
            StringBuilder output = new StringBuilder();
            output.Append(secretWord);
            for (int i = 0; i < lengthOfTheWord; i++)
            {
                output[i] = '_';
            }
            secretWord = output.ToString();
            return secretWord.ToString();
        }
    }   
}
