using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_1
{
    public class Deck
    {
        public Deck()
        {
            _cards = new Stack<Card>();
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    _cards.Push(new Card(rank, suit));
                }
            }
            Shuffle(_cards);
        }

        Random rng = new Random();

        private void Shuffle (Stack<Card> deck)
        {
            List<Card> cards = deck.ToList();

            int n = cards.Count();
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }

            deck.Clear();
            foreach (Card card in cards)
            {
                deck.Push(card);
            }
        }

        public Card Draw()
        {
            Card card;
            try
            {
                card = _cards.Pop();
                return card;
            }
            catch (InvalidOperationException ex)
            {
                throw new EmptyDeckDrawException("Attempted to draw card from empty deck.", ex);
            }
        }

        Stack<Card> _cards;
    }
}
