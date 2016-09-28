using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack21
{
    //0.- Definition of constants
    //1.- Definition of attributes and properties
    //2.- Constructor
    //3.- Define other helper methods
    //4.- Override ToString method
    class Player
    {
        //0.- Definition of constants
        const int MAX_NUMBER_CARDS = 9;

        //1.- Definition of attributes and properties
        public Card[] CardsReceived { get; set; }
        public int NumberOfCards{get;set;}
        public bool StickStatus { get; set; }

        //2.- Constructor
        /* The default constructor creates an array with 9 cells to store up to 9 cards.
         8 is the maximum of cards which would let you get as close as possible to 21 without going over.
         (2+2+2+2+3+3+3+3 = 20). Any other combination will require less than 8 cards.
          An extra cell is included in case the palyer chooses to twist one more time.*/
        public Player()
        {
            this.CardsReceived = new Card[MAX_NUMBER_CARDS];
            this.NumberOfCards = 0;
            this.StickStatus = false;
        }// End of constructor

        //3.- Defining other helper methods
        //3.1.- Method to receive and allocate cards in the player's array
        public void ReceiveCard(Card cardGiven)
        {
            if ((!this.StickStatus)&&(this.CalculateScore()<Game.BLACKJACK))
            {
                this.NumberOfCards++;
                int position = this.NumberOfCards - 1;
                this.CardsReceived[position] = cardGiven;
                if (this.CalculateScore()>Game.BLACKJACK) {
                    this.Stick();
                }// End of if statement
            }// End of if statement to check players's status
        }// End of ReceivedCard method

        //3.2.-Method to calculate the score of one player
        public int CalculateScore()
        {
            int score = 0;
            for (int i = 0; i <this.NumberOfCards; i++)
            {
                score += this.CardsReceived[i].Value;
            }// End of for loop that iterates through the cardsReceived array
            return score;
         }// End of CalculateScore method

        //3.3.- Method to stick in the current score
        public void Stick()
        {
            this.StickStatus = true;
        }// End of Stick method

        //4.- Override ToString method
        // Auxiliar method to print the players hand
        public  string PrintHand() {
            string hand="Current hand:\n";
            foreach (Card x in this.CardsReceived) {
                if (x!=null) { 
                    hand= string.Concat(hand,"\n",x);
                }
            }// End of foreach
            return hand;
        }//End of Printhand method
        public override string ToString()
        {
            return string.Format("Stick: {0}\nNumber of cards: {1}\nThis player's hand is:\n{2}",this.StickStatus,this.NumberOfCards,this.PrintHand());
        }
    }// End of Player class 
}// End of name space
