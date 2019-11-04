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
    public class PlayerTests
    {
        [TestMethod()]
        public void TestIsBusted()
        {
            Deck deck = new Deck();
            Player player = new Player(deck)
            {
                handvalue = 22
            };
            if (!player.isplayerbusted())
            {
                Assert.Fail();
            }
            player.handvalue = 20;
            if (player.isplayerbusted())
            {
                Assert.Fail();
            }
            return;
        }
        [TestMethod()]
        public void DrawTest()
        {
            Deck deck = new Deck();
            Player player = new Player(deck);
            Card hitcard = player.playerhit();
            List<Card> cardDump = new List<Card>();
            cardDump.Clear();
            for (int i = 0; i < 51; i++)
            {
                cardDump.Add(deck.drawcard());
            }
            foreach (Card testCard in cardDump)
            {
                if ((testCard.Suit == hitcard.Suit) && (testCard.Face == hitcard.Face))
                {
                    Assert.Fail();
                }
            }
            return;
        }
    }
}