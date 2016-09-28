using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack21
{  /* Program structure overview:
       BlackJack21 is made of 4 different classes plus the main class which holds the main method which controls intraction
       with user. The more basic class is the Card class which encapsulates all data structures and methods related to a card.
       All required attributes to make a specific instance of that class are in there. So are the constructor methods and an 
       override of the ToString method to give format when a card has to be displayed in the console.    
       The Deck class is a collection of Card objects. The Deck class stores 52 different cards in an array which are
       created in the constructor in a sorted way(bysuit and number). Another interesting method is implemented in the Deck 
       class, the Shuffle() method will allow an instance of this class to randomly reorder the card array so that it will be 
       available a ready to go. Another class is the Player class which models card players (gambler or dealer). This class
       stores an array to hold a limited number of cards, regarding methods the class has several methods to receive a new card,
       stick, calculate his score or print the player's hand. In addition, there is a Game class which simulates and stablishes
       the rules of a Black Jack game. The game contains two players, one deck of cards  and another features to manage the game.
       Methods to implement players options and define when the game is won or lost are in that method. Finally, the main class
       is responsible to interacts with users so that receives inputs, call other methods in other classes to perform activities
       and retrive that information to console. Error handling is included in this class too.
       Date: 10/12/2015
       Author: Jose Rodriguez
       Student number: S00165794
       IT Sligo - Highier Diploma in science in Computing
    */
    class BlackJackMain

    {
        //0.- Declare varaibles
        //1.- Print Game Header
        //2.- New game object is create
        //3.- Perform initial deal and print the players hand and score
        //4.- Ask the user if he wants to twist or stick?
        //5.- When user sticks or goes bust it's the Dealer's turn
        //6.- Deliver two cards to dealer and print his first hand and score
        //7.- Show the result of the game
        //8.- Ask the user if he wants to play one more time
        static void Main(string[] args)
        {
            //0.- Declare varaibles 
            bool exit=false;
            string option;
            bool validOption;
            //1.-Print Game Header
            Header();
            Console.Write("Your turn...Press any key to start playing:\n>>");
            Console.ReadKey();
            
            do
            { 
                //2.- New game object is created
                Game myGame = new Game();
                
                //Clear the console and print a new heading
                Console.Clear();
                Header();

                //3.- Perform the initial deal and print the player's hand and score
                myGame.InitialDeal(myGame.Player1);
                
                //4.- Ask the user if he wants to twist or stick?
                while (!myGame.Player1.StickStatus) {
                    option = StickOrTwist();
                    Console.WriteLine();
                    if (option.ToLower().Equals("s"))
                    {
                        myGame.Stick(myGame.Player1);
                    }
                    else if (option.ToLower().Equals("t"))
                    {
                        myGame.Deal1Card(myGame.Player1);
                    }
                    else {
                        Console.WriteLine("Wrong option... Please input one of the options available:\nS for Stick or N T for Twist...");
                    }// End of if else statements
                }// End of while loop 

                //5.- When user sticks it's the Dealer's turn. If palyer goes bust he loses the game automatically.
                if (myGame.Player1.CalculateScore() <= Game.BLACKJACK)
                {
                    Console.WriteLine("\nDealer plays now:\n");
                    //6.- Deliver two cards to dealer and print his first hand and score
                    myGame.InitialDeal(myGame.Dealer);
                    Console.WriteLine();

                    //While loop to twist cards for dealer until his score is 17 or greater
                    while (myGame.Dealer.CalculateScore() < Game.MIN_TO_STICK)
                    {
                        myGame.Deal1Card(myGame.Dealer);
                        Console.WriteLine();
                    }// End of while loop to deal cards to dealer

                }// End of if statement to check if player went bust or dealer has to play

                //7.- Show the result of the game
                myGame.Veredict();

                switch (myGame.StatusGame){
                    case Game.STATUS_L:
                        Console.WriteLine("Player loses!!! It's a pity...");
                        break;
                    case Game.STATUS_W:
                        Console.WriteLine("Player wins!!! Congratulations...");
                        break;
                    case Game.STATUS_D:
                        Console.WriteLine("It's a draw...");
                        break;
                }// End of switch statement

                //8.- Ask the user if he wants to play one more time
                do{
                    option = OneMoreGame();
                    switch (option.ToLower())
                    {
                        case "n":
                            exit = true;
                            validOption = true;
                            break;
                        case "y":
                            exit = false;
                            validOption = true;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Wrong option. Please input one of the options available:\nY for Yes or N for No...\n");
                            validOption = false;
                            exit = false;
                            break;
                    }// End of switch statement
                } while (!validOption);
            } while (!exit);
        }// End of main method

        public static void Header() {
            Console.WriteLine("\t*****\tWELCOME TO VIRTUAL BLACKJACK\t*****\n");
        }// End of Header Method

        public static string  StickOrTwist() {
            Console.Write("Do you want to Stick or Twist? S/T >> ");
            return Console.ReadLine();
        }// End of StickOrTwist method

        public static string OneMoreGame() {
            Console.Write("Do you want to play again? Y/N >> ");
            return Console.ReadLine();
        }// End of OneMoreGame method
    }// End of main class
}// End of namespace
