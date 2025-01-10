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
        private List<Card> pack;//pack of cards placed during turns
                            //in a normal turn it would be just two, but this number increases if tie
                            //it is cleared after turn end

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
        
        public Card playerPlay()
        {
            Card card = players[turnKeeper].placeCard();
            turnKeeper = (turnKeeper + 1) % 2;
            return card;
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
            String[] suits = { "Hearts" ,"Diamonds","Clubs","Spades"};//XD
            int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < values.Length; j++) { 
                    if(j == 12 && i < suits.Length - 1)
                    {
                        cards.Add(new Card(values[j],  "Ace of " + suits[i + 1]));
                        continue;
                    }
                    else if(j!= 12)
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
            initialDeck.addCards(cards);
        }
        public void handleTurn()
        {
            while (!isWinner())
            {
                Console.WriteLine(currentPlayer() + " press enter to pop your card");
                Console.ReadKey();
                Card card1 = playerPlay();
                Console.WriteLine(card1 + "\n");

                Console.WriteLine(currentPlayer() + " press enter to pop your card");
                Console.ReadKey();
                Card card2 = playerPlay();
                Console.WriteLine(card2 + "\n");

                pack.Add(card1);
                pack.Add(card2);
                
                CardComparer cardComparer = new CardComparer();

                switch (cardComparer.Compare(card1, card2))
                {
                    case 1:
                        {
                            Console.WriteLine(players[0].getName() + " wins turn\n");
                            players[0].getOffHand().addCards(pack);
                            pack.Clear();
                        }
                        break;
                    case -1:
                        {
                            Console.WriteLine(players[1].getName() + " wins turn \n");
                            players[1].getOffHand().addCards(pack);
                            pack.Clear();
                        }break;
                    case 0:
                        {
                            Console.WriteLine("Tie!!! \n Three cards are placed face down by each player\n");
                            pack.AddRange(players[0].placeThreeCards());
                            pack.AddRange(players[1].placeThreeCards());
                        }break;
                }
            }

            Console.WriteLine("Winner: " + getWinner());
            
        }
    }
}
