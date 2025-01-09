using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    internal class CardComparer : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            return x.getValue().CompareTo(y.getValue());
        }
    }
}
