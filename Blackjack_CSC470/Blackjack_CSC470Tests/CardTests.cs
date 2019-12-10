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
            // Arrange: Declare valid and invalid card parameters.
            const int testCardFace = 1; //Ace
            const int testCardSuit = 0; //Hearts
            const int testCardDeck = 0; //Deck #

            const int badCardFace = 14; //Invalid face
            const int badCardSuit = 5; //Invalid suit
            const int badCardDeck = 0; //Deck #

            try
            {
                Card test = new Card(testCardFace, testCardSuit, testCardDeck); // Act: Can I create an ace of hearts?
            }
            catch (Exception)
            {
                Assert.Fail(); // Assert: This should be a valid card for creation. If it fails, it fails.
                throw;
            }
            try
            {
                Card badCard = new Card(badCardFace, badCardSuit, badCardDeck); // Act: Make a ... Dictator-for-life of ... um... nukes! This should fail.
            }
            catch (ArgumentOutOfRangeException) // This should fail. If it does,
            { return; } // Awesome. Test passes.
            Assert.Fail(); // We made a dictator-for-life of nukes. Fail.
        }

        [TestMethod]
        public void CardFrontTest()
        {
            // Arrange: Declare parameters for ace of hearts test card
            const int testCardFace = 1; //Ace
            const int testCardSuit = 0; //Hearts
            const int testCardDeck = 0; //Deck #

            Card card = new Card(testCardFace, testCardSuit, testCardDeck); 
            Image image = card.CardFront(); // Act: Call the function to get the front of the card's image. Throw any exceptions as failures.
            return;// Assert: We got the image without exceptions? Awesome. Good night.
        }
    }
}