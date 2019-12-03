using System;
using Blackjack_CSC470;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blackjack_CSC470Tests
{
    [TestClass]
    public class DealerTests
    {
        [TestMethod]
        public void dealerBustedTest() // Test the dealer is busted function.
        {
            Deck deck = new Deck(); // Arrange: Make a deck for the dealer object.
            Dealer dealer = new Dealer(deck); // Arrange: Make the dealer and pass in the deck.
            dealer.handvalue = 22; // Arrange: Artificially set the dealer's hand to a busted value.
            if(!dealer.isdealerbusted()) // Act: Test the method. If it doesn't know the dealer is busted...
            { Assert.Fail(); } // Assert: That's a fail!
            dealer.handvalue = 20; // Arrange: Artificially set the dealer's hand value to valid value.
            if(dealer.isdealerbusted()) // Act: If the method thinks the dealer is busted... 
            { Assert.Fail(); } // Assert: That is a fail!
            return; // Assert: We didn't hit a fail condition, so we passed.
        }
        [TestMethod]
        public void TestDealerDrawOneCard()
        {
            Deck TheDeck = new Deck();
            Dealer TheDealer = new Dealer(TheDeck);

        }
    }
}
