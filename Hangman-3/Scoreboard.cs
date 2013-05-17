namespace HangmanGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Scoreboard
    {
        private readonly int TopRecordsNumber = 5;

        private List<PersonInScoreboard> players;

        public List<PersonInScoreboard> Players
        {
            get
            {

                return CopyPlayers(this.players);
            }
        }

        public Scoreboard()
        {
            this.players = new List<PersonInScoreboard>();
        }

        public void AddInScoreboard(string name, int personMistakes)
        {
            if (name == null)
            {
                throw new NullReferenceException("Name can not be NULL!!!");
            }
            if (personMistakes < 0)
            {
                throw new ArgumentOutOfRangeException("Mistake number can not be less than zero");
            }

            PersonInScoreboard newPlayer = new PersonInScoreboard(name, personMistakes);
            players.Add(newPlayer);
            players.Sort();

            if (players.Count>TopRecordsNumber)
            {
                players.RemoveAt(TopRecordsNumber);
            }
        }

        public bool QalifiesForScoreboard(int mistakesNumber)
        {
            if (mistakesNumber < 0)
            {
                throw new ArgumentOutOfRangeException("Mistake number can not be less than zero");
            }

            bool result = false;
            if (this.players.Count < TopRecordsNumber)
            {
                result = true;
            }
            else if (this.players[4].MistakeNumber > mistakesNumber)
            {
                result = true;
            }

            return result;
        }

        private List<PersonInScoreboard> CopyPlayers(List<PersonInScoreboard> payers)
        {
            List<PersonInScoreboard> newPlayers = new List<PersonInScoreboard>();

            foreach (var player in payers)
            {
                PersonInScoreboard newPlayer = new PersonInScoreboard(player.Name, player.MistakeNumber);
                newPlayers.Add(newPlayer);
            }

            return newPlayers;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Scoreboard:");
            result.Append(Environment.NewLine);
            for (int i = 0; i < this.Players.Count; i++)
            {
                result.AppendFormat("{0}. {1} --> {2} mistake", i + 1, Players[i].Name, Players[i].MistakeNumber);
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }
    }
}
