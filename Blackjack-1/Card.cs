using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_1
{
    public enum Rank
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Ace = 11,
        Jack = 12,
        Queen,
        King
    }

    public enum Suit
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    public class Card
    {
        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;

            if ((int)rank < 11)
            {
                Value = (int)rank;
            }
            else if ((int)rank > 11)
            {
                Value = 10;
            }
            else
            {
                Value = 11;
            }
        }

        public Card() 
            : this(Rank.Ace, Suit.Spades)
        {
        }

        public string Name()
        {
            return Rank + " of " + Suit;
        }

        public void Print()
        {
            Console.WriteLine("{0} - {1} points", Name(), Value);
        }

        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }
        public int Value { get; private set; }
    }
}
