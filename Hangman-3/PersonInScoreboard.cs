using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGame
{
    public class PersonInScoreboard: IComparable<PersonInScreboard>
    {
        private string name;

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
       private int mistakeNumber;

       public int MistakeNumber
       {
           get
           {
               return this.mistakeNumber;
           }
           private set
           {
               this.mistakeNumber = value;
           }
       }

        public int CompareTo(PersonInScreboard other)
        {
            return this.mistakeNumber.CompareTo(other.mistakeNumber);
            throw new NotImplementedException();
        }
    }
}
