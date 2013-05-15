﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGame
{
    public class PersonInScoreboard: IComparable<PersonInScoreboard>
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
               this.mistakeNumber = value;
           }
       }

        public int CompareTo(PersonInScoreboard other)
        {
            return this.mistakeNumber.CompareTo(other.mistakeNumber);
        }
    }
}
