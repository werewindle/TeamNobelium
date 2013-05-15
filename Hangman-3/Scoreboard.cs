using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGame
{
    class Scoreboard
    {
       private readonly int TopRecordsNumber = 5;

        private QalifiesForScoreboard()
        {

        }


        

        private AddInScoreboard()
        {
          PersonInScoreBoard.name = Console.ReadLine(); 
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
                break;
            }
        }

        Console.WriteLine();
    }
    }
}
