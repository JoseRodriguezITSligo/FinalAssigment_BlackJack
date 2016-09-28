using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack21
{//0.- Definition of constants
 //1.- Definition of attributes and properties
 //2.- Constructor
 //3.- Define other helper methods
 //4.- Override ToString()
    class Game
    {
        //0.- Definition of constants
        public  const int BLACKJACK = 21;
        public const int CARDS_IN_DECK = 52;
        public const int MIN_TO_STICK = 17;
        public const string STATUS_P = "Playing";
        public const string STATUS_W = "WIN";
        public const string STATUS_L = "LOSE";
        public const string STATUS_D = "DRAW";

        //1.- Definition of attributes and properties

        public Deck DeckInGame { get; set; }
        public Player Player1 { get; set; }
        public Player Dealer { get; set; }
        public int TOP { get; set; }
        public string StatusGame { get; set; }

        //2.- Constructor
        public Game()
        {
            this.Player1 = new Player();
            this.Dealer = new Player();
            this.DeckInGame = new Deck();
            this.DeckInGame.Shuffle();
            this.TOP = 0;
            this.StatusGame = STATUS_P;
        }// End of Constructor method

        //3.- Define other helper methods
        public void InitialDeal(Player P1) {
            P1.ReceiveCard(this.DeckInGame.Cards[TOP]);
            TOP++;
            P1.ReceiveCard(this.DeckInGame.Cards[TOP]);
            TOP++;
            Console.WriteLine(P1.PrintHand());
            Console.WriteLine("Current score is {0}", P1.CalculateScore());
            //P1.PrintHand();
            //Console.Write("The score is: {0}",this.Player1.CalculateScore());
        }// End of InitialDeal method

        //3.1.- Method to deal a card
        public void Deal1Card(Player P1) {
            P1.ReceiveCard(this.DeckInGame.Cards[TOP]);
            TOP++;
            Console.WriteLine(P1.PrintHand());
            Console.WriteLine("Current score is {0}",P1.CalculateScore());
        }// End of Deal1Card Method

        //3.2.- Method to stick a player
        public void Stick(Player P1) {
            P1.Stick();
            Console.WriteLine("Final score is: {0}",P1.CalculateScore());
        }// End of Stick method

        //3.3- Method to determine who wins the game
        public void Veredict() {
            if ((this.Player1.CalculateScore() > BLACKJACK))
            {
                this.StatusGame = STATUS_L;
            }
            else if (this.Dealer.CalculateScore() > BLACKJACK) {
                this.StatusGame = STATUS_W;
            }
            else if (this.Player1.CalculateScore() > this.Dealer.CalculateScore())
            {
                this.StatusGame = STATUS_W;
            }
            else if (this.Player1.CalculateScore() < this.Dealer.CalculateScore())
            {
                this.StatusGame = STATUS_L;
            }
            else {
                this.StatusGame = STATUS_D;
            }
        }// End of Veredict method


    }// End of Game class
}// End of namespace
