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
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CardCreationTest()
        {
            // Arrange: Nothing to be arranged for this test.
            try
            {
                Card test = new Card(1, 0, 0); // Act: Can I create an ace of hearts?
            }
            catch (Exception)
            {
                Assert.Fail(); // Assert: This should be a valid card for creation. If it fails, it fails.
                throw;
            }
            try
            {
                Card badCard = new Card(14, 5, 0); // Act: Make a ... Dictator-for-life of ... um... nukes! This should fail.
            }
            catch (ArgumentOutOfRangeException) // This should fail. If it does,
            { return; } // Awesome. Test passes.
            Assert.Fail(); // We made a dictator-for-life of nukes. Fail.
        }

        [TestMethod]
        public void CardFrontTest()
        {
            // Arrange:
            Card card = new Card(1, 0, 0); // Make an ace of hearts.
            Image image = card.CardFront(); // Act: Call the function to get the front of the card's image. Throw any exceptions as failures.
            return;// Assert: We got the image without exceptions? Awesome. Good night.
        }
    }
}