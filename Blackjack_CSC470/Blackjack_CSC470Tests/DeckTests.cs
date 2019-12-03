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
    public class DeckTests
    {
        [TestMethod]
        public void FiftyTwoCount() // Make sure a new deck has 52 cards.
        {
            Deck deck = new Deck(); // Arrange: Make a new deck.
            List<Card> cards = new List<Card>(); // Arrange: Make a container for the cards to go into.
            for (int counter = 0; counter < 51; counter++) // Act: Move 51 cards into the list.
            {
                cards.Add(deck.drawcard()); // Assert: This is a near-edge case and should go off without a hitch.
            }
            Console.WriteLine("51 cards drawn."); // Act: Report success to the console.
            try
            {
                cards.Add(deck.drawcard()); // Act: Draw card #52. This is the edge case, and should succeed.
            }
            catch (ArgumentNullException) // If it fails...
            {
                throw; // Assert: Fail it.
            }
            catch (InvalidOperationException)
            {
                throw; // Assert: Fail it.
            }
            Console.WriteLine("52 cards drawn. Next card draw should fail."); // Act: Report our success to this point.
            try
            {
                cards.Add(deck.drawcard()); // Act: Attempt to draw a 53rd card.
            }
            catch (ArgumentNullException) // Assert: This should fail, but not like this.
            {
                throw;
            }
            catch (InvalidOperationException) // Assert: This is how this should fail. 
            {
                return; // Assert: We have failed in a successful way. or succeeded in a failure.
            }
            Assert.Fail(); // Assert: We didn't fail, which is itself a failure.
            return; // Good evening friends!
        }
    }
}
