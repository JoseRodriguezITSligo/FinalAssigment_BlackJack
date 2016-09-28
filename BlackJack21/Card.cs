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
    class Card
    {
        //1.- Definition of properties
        public string Suit { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }

        //2.- Constructor
        public Card(string suit, string type, int value, string name)
        {
            this.Suit = suit;
            this.Type = type;
            this.Value = value;
            this.Name = name;
        }// End of Card constructor 

        //3.- Override ToString()
        public override string ToString()
        {
            return string.Format("Card dealt is the {0} of {1}, value {2}.", this.Name, this.Suit, this.Value);
        }// End of ToString method
    }// End of Cardnclass
}// End of namespace