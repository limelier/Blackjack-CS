using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_1
{
    public class Hand
    {
        public Hand()
        {
            Cards = new List<Card>();
        }

        public void Add(Card card)
        {
            Cards.Add(card);
        }

        public int Score()
        {
            int score = 0, aces = 0;
            foreach (Card card in Cards)
            {
                score += card.Value;

                if (card.Rank == Rank.Ace)
                    aces++;
            }

            if (score > 21)
            {
                while (score > 21 && aces > 0)
                {
                    score -= 10;
                    aces--;
                }
            }

            return score;
        }

        protected void PrintCards()
        {
            foreach (Card card in Cards)
            {
                Console.WriteLine("- a {0} of {1}", card.Rank, card.Suit);
            }
        }

        public List<Card> Cards { get; private set; }
    }
}
