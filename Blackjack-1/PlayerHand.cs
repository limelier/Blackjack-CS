using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_1
{
    class PlayerHand : Hand
    {
        public void Print()
        {
            Console.WriteLine("Your score is {0}, and your hand is:", Score());
            PrintCards();
        }
    }
}
