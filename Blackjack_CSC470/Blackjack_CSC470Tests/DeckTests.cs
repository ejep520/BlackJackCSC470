using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack_CSC470;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_CSC470.Tests
{
    [TestClass()]
    public class DeckTests
    {
        [TestMethod()]
        public void FiftyTwoCount()
        {
            Deck deck = new Deck();
            List<Card> cards = new List<Card>();
            for (int counter = 0; counter < 51; counter++)
            {
                cards.Add(deck.drawcard());
            }
            Console.WriteLine("51 cards drawn.");
            try
            {
                cards.Add(deck.drawcard());
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Console.WriteLine("52 cards drawn. Next card draw should fail.");
            try
            {
                cards.Add(deck.drawcard());
            }
            catch (ArgumentNullException)
            {
                return;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Assert.Fail();
            return;
        }
    }
}
