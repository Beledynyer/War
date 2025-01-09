using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to War!!!!");
            Console.Write("Player 1 enter your name: ");
            String name = Console.ReadLine();
            Player player1 = new Player(name);
            Console.Write("Player 2 enter your name: ");
            name = Console.ReadLine();
            Player player2 = new Player(name);

            Game game = new Game(player1,player2);
            game.setUpGame();

            Console.WriteLine("Game has been set up");

            while (!game.isWinner())
            {
                game.handleTurn();
            }
        }
    }
}
