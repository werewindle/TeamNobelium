using System.Collections.Generic;

namespace HangmanGame
{
    public class OutComparer : IComparer<KeyValuePair<string, int>>
    {

        public int Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
        {
            return x.Value.CompareTo(y.Value);
        }
    }
}
