using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScoreSharp
{
    public class CompareScore : IComparer<string>
    {
        string match;

        public CompareScore(string match)
        {
            this.match = match;
        }

        public int Compare(string obj1, string obj2)
        {
            int retorno;
            double comparison = Scorer.score(obj2.ToString(), this.match) - Scorer.score(obj1.ToString(), this.match);
            if (comparison > 0)
                retorno = 1;
            else if (comparison < 0)
                retorno = -1;
            else
                retorno = 0;
            return retorno;
        }
    }
}
