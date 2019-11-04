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
    public class CardTests
    {
        [TestMethod()]
        public void CardTest()
        {
            try
            {
                Card test = new Card(1, 0);
            }
            catch (Exception)
            {
                Assert.Fail();
                throw;
            }
            try
            {
                Card badCard = new Card(14, 5);
            }
            catch (ArgumentOutOfRangeException)
            { return; }
            Assert.Fail();
        }

        [TestMethod()]
        public void CardFrontTest()
        {
            Card card = new Card(1, 0);
            Image image = card.CardFront();
            return;
        }
    }
}