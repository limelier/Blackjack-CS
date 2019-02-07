using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_1
{
    class DealerHand : Hand
    {
        public void InitialPrint()
        {
            if (Cards.Count == 2)
            {
                Console.WriteLine("The dealer's hand is an {0} of {1}, and one other card.",
                    Cards[0].Rank, Cards[0].Suit);
            }
            else
            {
                throw new InvalidOperationException("Attempted to initial-print a hand of less or more than two.");
            }
        }

        public void NormalPrint()
        {
            Console.WriteLine("The dealer's hand has a score of {0}, with the cards:", Score());
            PrintCards();
        }
    }
}
