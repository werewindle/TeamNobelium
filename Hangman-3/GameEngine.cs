using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGame
{
    public class GameEngine
    {
        
        private static bool isCheated = false;
        private static bool isRestartRequested = false;

        public static int mistakeCounter = 0;
        private static string theChosenWord;
        private readonly static StringBuilder hiddenWord = new StringBuilder();

        readonly Scoreboard scoreBoard = new Scoreboard();

        public void Run()
        {
            do
            {
                WordsRepository wordGenerator = new WordsRepository();
                theChosenWord = wordGenerator.GenerateRandomWord();
                hiddenWord.Append(wordGenerator.GenerateHiddenWord(theChosenWord));

                ConsoleRender.PrintOnConsole(HangmanUserInterface.GetStartMessage());

                isCheated = false;
                mistakeCounter = 0;

                PlayCurrentWord();

                if (isRestartRequested)
                {
                    isRestartRequested = false;
                    Console.WriteLine();
                    continue;
                }

                WordGuessed();
            }
            while (true);
        }
  
        private void WordGuessed()
        {
            if (!isCheated)
            {
                Console.WriteLine("You won with {0} mistakes.", mistakeCounter);

                PrintTheWord();

                
                scoreBoard.AddInScoreboard(RequestName(), mistakeCounter);
                ConsoleRender.PrintOnConsole(scoreBoard.ToString());
            }
            else
            {
                ConsoleRender.PrintOnConsole(HangmanUserInterface.WonWithCheatingMessage(mistakeCounter));
                PrintTheWord();
            }
        }

        private string RequestName()
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            return name;
        }

        private void PlayCurrentWord()
        {
            do
            {
                PrintTheWord();
                Console.Write("Enter your guess: ");
                string enteredString = Console.ReadLine();
                GetCommand(enteredString);
                if (isRestartRequested)
                {
                    break;
                }
            }
            while (!IsWordKnown());
        }

        public void GetCommand(string command)
        {
            switch (command)
            {
                case "top":
                    ConsoleRender.PrintOnConsole(scoreBoard.ToString());
                    break;
                case "restart":
                    isRestartRequested = true;
                    break;
                case "help":
                    isCheated = true;
                    Help();
                    break;
                case "exit":
                    ConsoleRender.PrintOnConsole(HangmanUserInterface.EndMessage());
                    Environment.Exit(1); // Check how to fix this
                    break;
                default:
                    CheckCommandOrLetter(command);
                    break;
            }
        }
  
        private void CheckCommandOrLetter(string command)
        {
            bool isOneSymbol = (command.Length == 1);
                      
            if (isOneSymbol && char.IsLetter(command, 0))
            {
                ProcessLetter(command);
            }
            else
            {
                ConsoleRender.PrintOnConsole(HangmanUserInterface.IncorrectCommandMessage());
            }
        }

        static bool CheckIsLetter(string enteredString)
        {
            if (enteredString == null)
            {
                throw new ArgumentNullException("Entered string can not be NULL");
            }
            if (enteredString == string.Empty)
            {
                throw new ArgumentNullException("Entered string can not be empty");
            }

            char enteredSymbol;
            bool isChar = char.TryParse(enteredString, out enteredSymbol);
            bool result = false;
            if (isChar && char.IsLetter(enteredSymbol))
            {
                result = true;
            }

            return result;
        }

        private static string ProcessLetter(string letter)
        {
            bool isLetterInTheWord = false;
            int letterKnown = 0;
            char enteredSymbol = char.Parse(letter);
            
            for (int i = 0; i < hiddenWord.Length; i++)
            {
                if (theChosenWord[i] == enteredSymbol)
                {
                    hiddenWord[i] = enteredSymbol;
                    letterKnown++;
                    isLetterInTheWord = true;
                    
                }
            }

            string result = "";
            if (isLetterInTheWord)
            {
                result = HangmanUserInterface.LettersKnownMessage(letterKnown);
            }
            else
            {
                result = HangmanUserInterface.WrongLetterMessage(letter);
                mistakeCounter++;
            }

            return result;
        }

        

        static void PrintTheWord()
        {
            Console.Write("The secret word is: ");
            for (int i = 0; i < hiddenWord.Length; i++)
            {
                Console.Write("{0} ", hiddenWord[i]);
            }
            Console.WriteLine();
        }

        

        static bool IsWordKnown()
        {
            for (int i = 0; i < hiddenWord.Length; i++)
            {
                if (hiddenWord[i] == '_')
                {
                    return false;
                }
            }
            return true;
        }

        static void AddInScoreboard(Dictionary<string, int> score)
        {
            string name = string.Empty;
            bool hasDouble = false;
            do
            {
                hasDouble = false;
                name = Console.ReadLine();
                foreach (var item in score)
                {
                    if (item.Key == name)
                    {
                        Console.Write("This name already exists in the Scoreboard! Type another: ");
                        hasDouble = true;
                        //podari fakta che Dictionary-to ne e Multi (Wintellect Power Collections), ne moje da povarqme imena
                    }
                }
            } while (hasDouble);
            score.Add(name, mistakeCounter);
            mistakeCounter = 0;
        }

        static void PrintBoard(Dictionary<string, int> score)
        {
            if (score.Count == 0)
            {
                Console.WriteLine("Empty Scoreboard!");
                return;
            }
            List<KeyValuePair<string, int>> key = new List<KeyValuePair<string, int>>();
            foreach (var item in score)
            {
                KeyValuePair<string, int> current = new KeyValuePair<string, int>(item.Key, item.Value);
                key.Add(current);
            }
            key.Sort(new OutComparer());
            Console.WriteLine("Scoreboard:");
            for (int i = 0; i < score.Count; i++)
            {
                Console.WriteLine("{0}. {1} --> {2} mistake", i + 1, key[i].Key, key[i].Value);
                if (i == 4)
                {
                    //Ima izlishak ot informacia, pokazvame samo parvite 5, no pazim vsichki (izlishno moje bi)
                    break;
                }
            }
            Console.WriteLine();
        }

        static void Help()
        {
            isCheated = true;
            for (int i = 0; i < hiddenWord.Length; i++)
            {
                if (hiddenWord[i] == '_')
                {
                    hiddenWord[i] = theChosenWord[i];
                    break;
                }
            }
        }
    }
}
