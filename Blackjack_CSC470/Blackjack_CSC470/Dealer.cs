using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack_CSC470
{
    public class Dealer
    {
        public int handvalue = 0;
        private List<Card> privHand = new List<Card>();
        Deck theDeck;
        
        public Dealer(Deck thedeck)
        {
            theDeck = thedeck;
        }

        public Card getonedealercard()
        {
            Card drawncard = theDeck.drawcard();
            handvalue += drawncard.ValueOf;
            privHand.Add(drawncard);
            return drawncard;
        }

        public bool isdealerbusted()
        {
            return handvalue > 21;
        }

        public Card getdealerslastcard()
        {
            return privHand.Last();
        }

        public void dealeraction(int playerHandValue, int betAmount)
        {
            //dealer draw from deck into dealer's hand
            Card drawncard = theDeck.drawcard();
            //add card value to handvalue
            handvalue += drawncard.ValueOf;
            privHand.Add(drawncard);
            //assign card image to picturebox
        }

        public void resetdealer()
        {
            handvalue = 0;
            privHand.Clear();
        }
        public IReadOnlyCollection<Card> DealerHand
        {
            get => privHand.AsReadOnly();
        }
    }
}
