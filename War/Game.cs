using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    internal class Game
    {
        private Player[] players;
        private Deck initialDeck;
        private int turnKeeper;

        public Game(Player player,Player player1)
        {
            players = new Player[2];
            players[0] = player;
            players[1] = player1;
            makeDeck();
            turnKeeper = 0;
        }

        public void setUpGame()
        {
            initialDeck.shuffle();

            List<Card> firstPlayers = initialDeck.getCards().GetRange(0,initialDeck.size()/2);
            List<Card> secondPlayers = initialDeck.getCards().GetRange( initialDeck.size() / 2,initialDeck.size()/2);

            players[0].getOnHand().addCards(firstPlayers);
            players[1].getOnHand().addCards(secondPlayers);
        }
        
        public String currentPlayer()
        {
            return players[turnKeeper].getName();
        }

        public bool isWinner()
        {
            return players[0].getOnHand().size() + players[0].getOffHand().size() == 54 ||
                players[1].getOnHand().size() + players[1].getOffHand().size() == 54;
        }

        public String getWinner()
        {
            return players[0].getOnHand().size() + players[0].getOffHand().size() == 54 ? players[0].getName() : players[1].getName();
        }

        private void makeDeck()
        {
            initialDeck = new Deck();
            List<Card> cards = new List<Card>();
            cards.Add(new Card(15,"Joker (red)"));
            cards.Add(new Card(15, "Joker (black)"));
            cards.Add(new Card(14, "Ace of Hearts"));
            String[] suits = { "Hearts,Diamonds,Clubs,Spades" };
            int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < values.Length; j++) { 
                    if(j == 12 && i < suits.Length - 1)
                    {
                        cards.Add(new Card(values[j],  "Ace of " + suits[i + 1]));
                        continue;
                    }
                    else
                    {
                        if(j == 11)
                        {
                            cards.Add(new Card(values[j],  "King of " + suits[i]));
                        }
                        else if(j == 10)
                        {
                            cards.Add(new Card(values[j], "Queen of " + suits[i]));
                        }
                        else if(j == 9)
                        {
                            cards.Add(new Card(values[j], "Jack of " + suits[i]));
                        }
                        else
                        {
                            cards.Add(new Card(values[j], values[j] + " of " + suits[i]));
                        }
                    }
                    
                }
            }
        }

    }
}
