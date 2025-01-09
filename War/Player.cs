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
    }
}
