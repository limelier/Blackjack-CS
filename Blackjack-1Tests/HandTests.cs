using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_1.Tests
{
    [TestClass()]
    public class CardTests
    {
        [TestMethod()]
        public void AceValueIs11()
        {
            Card card = new Card(Rank.Ace, Suit.Spades);

            Assert.AreEqual(11, card.Value);
        }

        [TestMethod()]
        public void FaceValueIs10()
        {
            for (Rank rank = Rank.Jack; rank < Rank.King; rank++)
            {
                Card card = new Card(rank, Suit.Spades);

                Assert.AreEqual(10, card.Value);
            }
        }

        [TestMethod()]
        public void EmptyConstructorMakesAceOfSpades()
        {
            Card card = new Card();

            Assert.AreEqual(Rank.Ace, card.Rank);
            Assert.AreEqual(Suit.Spades, card.Suit);
        }
    }
}