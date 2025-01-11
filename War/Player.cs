using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    internal class Player
    {
        private String name;
        private Deck onHand;
        private Deck offHand;

        public Player(String name)
        {
            this.name = name;
            onHand = new Deck();
            offHand = new Deck();
        }

        public Deck getOnHand() { return onHand; }
        public Deck getOffHand() { return offHand; }
        public String getName() { return name; }

        public Card placeCard()
        {
            if (onHand.isEmpty())
            {
                onHand.addCards(offHand.getCards());
                onHand.shuffle();
                offHand.clear();
            }
            return onHand.pop();
        }

        public List<Card> placeThreeCards()
        {
            List<Card> cards = new List<Card>();


            while(cards.Count() < 3 && (!onHand.isEmpty() || !offHand.isEmpty())){

                if (onHand.isEmpty())
                {
                    onHand.addCards(offHand.getCards());
                    onHand.shuffle();
                    offHand.clear();
                }

                cards.Add(onHand.pop());
            }
            return cards;
        }
    }
}
