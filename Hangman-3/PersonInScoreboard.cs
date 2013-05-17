namespace HangmanGame
{
    using System;
    using System.Linq;

    public class PersonInScoreboard : IComparable<PersonInScoreboard>
    {
        private string name;
        private int mistakeNumber;

        public PersonInScoreboard(string name, int personMistakes)
        {
            this.Name = name;
            this.MistakeNumber = personMistakes;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Name can not be NULL!!!");
                }
                this.name = value;
            }
        }

        public int MistakeNumber
        {
            get
            {
                return this.mistakeNumber;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Mistake number can not be less than zero");
                }

                this.mistakeNumber = value;
            }
        }

        public int CompareTo(PersonInScoreboard other)
        {
            return this.mistakeNumber.CompareTo(other.mistakeNumber);
        }
    }
}
