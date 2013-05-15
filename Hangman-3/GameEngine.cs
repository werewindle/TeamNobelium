using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGame
{
    class GameEngine
    {
        static string[] someWords = { 
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

        public const string START_MESSAGE = "Welcome to “Hangman” game. Please try to guess my secret word. \n" +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' \nto cheat and 'exit' " +
            "to quit the game.";
        private static bool isCheated = false;
        private static bool isRestartRequested = false;




        public static int mistakeCounter = 0;
        private static string theChosenWord;
        private static string hiddenWord;
        public static Dictionary<string, int> score;

        public void Run()
        {
            score = new Dictionary<string, int>();
            do
            {
                WordsRepository wordGenerator = new WordsRepository();
                theChosenWord = wordGenerator.GenerateRandomWord();
                hiddenWord = wordGenerator.GenerateHiddenWord(theChosenWord);

                Console.WriteLine(START_MESSAGE);
                isCheated = false;
                mistakeCounter = 0;
                do
                {
                    PrintTheWord();
                    Console.Write("Enter your guess: ");
                    string enteredString = Console.ReadLine();
                    MyGetCommand(enteredString);
                    if (isRestartRequested)
                    {
                        break;
                    }

                } while (!IsWordKnown());
                if (isRestartRequested)
                {
                    isRestartRequested = false;
                    Console.WriteLine();
                    continue;
                }
                if (!isCheated)
                {
                    Console.WriteLine("You won with {0} mistakes.", mistakeCounter);
                    PrintTheWord();
                    Console.Write("Please enter your name for the top scoreboard: ");
                    AddInScoreboard(score);
                    printboard(score);
                }
                else
                {
                    Console.WriteLine("You won with {0} mistakes but you have cheated. You are not allowed", mistakeCounter);
                    Console.WriteLine("to enter into the scoreboard.");
                    PrintTheWord();
                }

            } while (true);

        }

        static void MyGetCommand(string command)
        {
            switch (command)
            {
                case "top":
                    printboard(score);
                    break;
                case "restart":
                    isRestartRequested = true;
                    break;
                case "help":
                    isCheated = true;
                    Help();
                    break;
                case "exit":
                    Console.WriteLine("Good bye!");
                    Environment.Exit(1);
                    break;
                default:
                    bool isOneSymbol = command.Length != 1;
                    if (isOneSymbol && char.IsLetter(command, 0))
                    {
                        ProcessLetter(command);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect guess or command!");
                    }
                    break;
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

        static bool check(string enteredString)
        {
            char enteredSymbol;
            if ((char.TryParse(enteredString, out enteredSymbol)) &&
                ((int)enteredSymbol >= 97 && (int)enteredSymbol <= 122))
            {
                return true;
            }
            return false;
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

        private static void gen()
        {
            Random randomNumber = new Random();
            theChosenWord = someWords[randomNumber.Next(0, 10)];
            int lengthOfTheWord = theChosenWord.Length;
            hiddenWord = new char[lengthOfTheWord];
            for (int i = 0; i < lengthOfTheWord; i++)
            {
                hiddenWord[i] = '_';
            }
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

        static void printboard(Dictionary<string, int> score)
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
