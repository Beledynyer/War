using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    internal class Deck
    {
        private List<Card> cards;

        public Deck() {
            cards = new List<Card>();
        }

        public void shuffle()
        {
            //BORROWED FROM STACK OVERFLOW
            cards = cards.OrderBy(_ => Guid.NewGuid()).ToList();
        }

        public void addCards(List<Card> cards)
        {
            cards.AddRange(cards);
        }

        public Card pop()
        {
            Card card = cards.FirstOrDefault();
            if(cards.Count> 0)
            {
                cards.RemoveAt(0);
            }
            return card;
        }

        public bool isEmpty()
        {
            return cards.Count == 0;
        }

        public int size()
        {
            return cards.Count;
        }
        public List<Card> getCards() {return cards;}

        public void clear()
        {
            cards.Clear();
        }
    }
}
