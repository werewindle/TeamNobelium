namespace HangmanGame
{
    using System;
    using System.Linq;
    using System.Text;

    public class GameEngine
    {
        
        private bool isCheated = false;
        private bool isRestartRequested = false;

        public int mistakeCounter = 0;
        private string theChosenWord;
        private StringBuilder hiddenWord = new StringBuilder();

        Scoreboard scoreBoard = new Scoreboard();

        public void Run()
        {
            do
            {
                WordsRepository wordGenerator = new WordsRepository();
                this.theChosenWord = wordGenerator.GenerateRandomWord();
                this.hiddenWord.Append(wordGenerator.GenerateHiddenWord(this.theChosenWord));

                ConsoleRender.PrintOnConsole(HangmanUserInterface.GetStartMessage());

                this.isCheated = false;
                this.mistakeCounter = 0;

                PlayCurrentWord();

                if (this.isRestartRequested)
                {
                    this.isRestartRequested = false;
                    Console.WriteLine();
                    continue;
                }

                WordGuessed();
            }
            while (true);
        }
  
        private void WordGuessed()
        {
            if (!this.isCheated)
            {
                Console.WriteLine("You won with {0} mistakes.", this.mistakeCounter);

                PrintTheWord();

                
                scoreBoard.AddInScoreboard(RequestName(), this.mistakeCounter);
                ConsoleRender.PrintOnConsole(scoreBoard.ToString());
            }
            else
            {
                ConsoleRender.PrintOnConsole(HangmanUserInterface.WonWithCheatingMessage(this.mistakeCounter));
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
                if (this.isRestartRequested)
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
                    this.isRestartRequested = true;
                    break;
                case "help":
                    this.isCheated = true;
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

        private string ProcessLetter(string letter)
        {
            bool isLetterInTheWord = false;
            int letterKnown = 0;
            char enteredSymbol = char.Parse(letter);
            
            for (int i = 0; i < this.hiddenWord.Length; i++)
            {
                if (this.theChosenWord[i] == enteredSymbol)
                {
                    this.hiddenWord[i] = enteredSymbol;
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
                this.mistakeCounter++;
            }

            return result;
        }

        

        private void PrintTheWord()
        {
            Console.Write("The secret word is: ");
            for (int i = 0; i < this.hiddenWord.Length; i++)
            {
                Console.Write("{0} ", this.hiddenWord[i]);
            }
            Console.WriteLine();
        }

        

        private bool IsWordKnown()
        {
            for (int i = 0; i < this.hiddenWord.Length; i++)
            {
                if (this.hiddenWord[i] == '_')
                {
                    return false;
                }
            }
            return true;
        }

        private void Help()
        {
            this.isCheated = true;
            for (int i = 0; i < this.hiddenWord.Length; i++)
            {
                if (this.hiddenWord[i] == '_')
                {
                    this.hiddenWord[i] = this.theChosenWord[i];
                    break;
                }
            }
        }
    }
}
