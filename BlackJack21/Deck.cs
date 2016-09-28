using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack21
{
    //1.- Definition of properties
    //2.- Constructor
    //3.- Override ToString()
    class Deck
    {
        //1.- Definition of properties
        // Array to strore 52 card objects
        public Card[] Cards { get; set; }

        //2.- Constructor
        public Deck() {
            this.Cards = new Card[Game.CARDS_IN_DECK];
            // Local variable to define the suit of a card
            string suit;
            // Counter to go throught the cards array. The counter should strart in 0 and fisnish in 51.
            int index=0;
            // Loop to create 4 sets of cards (one per suit)
            for (int i=1;i<5;i++) {
               
                // switch statements to choose the suit
                switch (i) {
                    case 1: suit = "Clubs";
                        break;
                    case 2: suit = "Diamonds";
                        break;
                    case 3: suit = "Hearts";
                        break;
                    case 4: suit = "Spades";
                        break;
                    default: suit = "Not assigned";
                        break;
                }// End of switch statement

                // Loop to create 13 cards for each suit
                for (int j=2;j<15;j++) {
                    //Switch statement to check if the card is a number (2-9) or a figure (Ace,Jack, Queen, King)
                    switch (j) {
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                            // In case the card to be created is a numeric card between 2 and 9 the parameter type is set up as "Number",
                            // the value of the card is equal to the variable j and its name is the character sign for that number.
                            Cards[index] = new Card(suit, "Number", j, j.ToString());
                            break;
                            //In case j is higher than 10 and lower than 14 a figure card must be created (Ace, Jack, Queen or King)
                        case 11: this.Cards[index] = new Card(suit, "Figure", 10, "Jack");
                            break;
                        case 12: this.Cards[index] = new Card(suit, "Figure", 10, "Queen");
                            break;
                        case 13: this.Cards[index] = new Card(suit, "Figure", 10, "King");
                            break;
                        case 14: this.Cards[index] = new Card(suit, "Figure", 11, "Ace");
                            break;
                    }// End of switch statement to choose the card type.

                     // After creating a card the index value is increased by one.
                    index++;
                } // End of inner for loop
            }// End of first for loop
        }// End of Constructor

        //3.- Defining others helper methods
        //3.1- Method to shuffle order of cards in deck (array of Cards).
        public void Shuffle(){
            //Declare a temporary array to store the shuffled card deck
            Card[] shuffledDeck = new Card[Game.CARDS_IN_DECK];
            // Declare a random object which will pick a card a card randomly to shuffle the deck
            Random selector = new Random();
            //Declare a integer variable to store the position in the original array where the card will be copied from
            int position;
            // Declare an integer array to store the positions selected so no card can be stored twice in the shuffled array
            int[] positionList = new int [Game.CARDS_IN_DECK];
            // Using a for loop to go through the new shuffled deck and store a card during each iteration
            for (int i = 0; i <this.Cards.Length; i++)
            {
                // Use a do while loop to check the position list in order to asure no card is stored twice
                bool repeated;
                do
                {
                    //A random number is created to pick out a card in the sorted original deck.
                    position = selector.Next(0, Game.CARDS_IN_DECK); // The range to pick out a card position is between 0 and 51.
                    //Use another do while loop to check the position array until a position is repeated or no repeated value is found 
                    //after going through the whole array.
                    int k = 0; // Counter for second while loop
                    //Checks if the new position (randomly generated) is already in the list of previous positions.
                    //repeated = (positionList[k] == position);
                    do
                    {
                        repeated = (positionList[k] == position);
                        k++;    
                    } while ((k < i) && (!repeated));// End of inner do while loop 

                } while ((repeated) && (i<this.Cards.Length-1));

                // The position is stored in the list that records the already selected positions in the original deck
                positionList[i] = position;
                // Store the card in the position obtained above in the new shuffled array
                shuffledDeck[i] = this.Cards[position];
            }// End of for loop to go through the shuffled array.
            
            //The shuffled cards array is copied into the original array.
            for (int i=0;i<this.Cards.Length;i++) {
                this.Cards[i] = shuffledDeck[i];
            }// End of for loop to copy the shuffled array.  
        }// End of Shuffle method

        //4.- Override ToString()
        public override string ToString()
        {
            foreach (Card x in this.Cards)
            {
                Console.WriteLine(x);
            }// End of foreach to iterate through the array to be printed.
            return string.Format("\n");
        }// End of ToString method
    }// End of Deck class
}// End of namespace
