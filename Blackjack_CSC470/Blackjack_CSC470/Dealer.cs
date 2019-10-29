using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_CSC470
{
    class Dealer
    {
        int handvalue = 0;
        List<Card> dealerhand;
        Deck theDeck;
        public Dealer(Deck thedeck)
        {
            theDeck = thedeck;
        }
        bool isdealerbusted()
        {
            if (handvalue > 21)
                return true;
            else
                return false;
        }

        void dealeraction()
        {
            if (!isdealerbusted())
            {
                if (handvalue < 17)
                {
                    Console.WriteLine("Draw.");  //draw card
                    //dealer draw from deck into dealer's hand
                    Card drawncard = theDeck.drawcard();
                    //add card value to handvalue
                    handvalue += drawncard.ValueOf;
                }
                else
                    Console.WriteLine("Dealer Stands");  //stands
            }
            else
            {
                Console.WriteLine("Dealer is busted!");//say dealer is busted
            }
        }
    }
}
