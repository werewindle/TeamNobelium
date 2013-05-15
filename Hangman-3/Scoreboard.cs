using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGame
{
    public class Scoreboard
    {
       private readonly int TopRecordsNumber = 5;

        private List<PersonInScoreboard> players;

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Scoreboard:");
            result.Append(Environment.NewLine);
            for (int i = 0; i < this.Players.Count ; i++)
            {
                result.AppendFormat("{0}. {1} --> {2} mistake", i + 1, Players[i].Name, Players[i].MistakeNumber);
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }

        public List<PersonInScoreboard> Players
        {
            get
            {
                return this.players;
            }
        }

        public Scoreboard()
        {
            this.players = new List<PersonInScoreboard>();
        }

        public void AddInScoreboard(string name, int personMistakes)
        {
         PersonInScoreboard newPlayer = new PersonInScoreboard(name,personMistakes);
            players.Add(newPlayer);
            players.Sort();
        }

        public bool QalifiesForScoreboard(int mistakesNumber)
        {
            bool result = false;
            if (this.players.Count < TopRecordsNumber)
            {
                result= true;
            }
            else if (this.players[5].MistakeNumber > mistakesNumber)
            {
                result = true;
            }

            return result;
        }

    }
}
