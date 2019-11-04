using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack_CSC470
{
    class Dealer
    {
        int handvalue = 0;
        List<Card> dealerhand = new List<Card>();
        Deck theDeck;
        public bool dealerdone = false;
        
        public Dealer(Deck thedeck)
        {
            theDeck = thedeck;
        }

        public Card getonedealercard()
        {
            Card drawncard = theDeck.drawcard();
            handvalue += drawncard.ValueOf;
            dealerhand.Add(drawncard);
            return drawncard;
        }

        public bool isdealerbusted()
        {
            return handvalue > 21;
        }

        public Card getdealerslastcard()
        {
            return dealerhand.Last();
        }

        public int getdealerhandvalue()
        {
            return handvalue;
        }

        public void dealeraction(int playerHandValue, int betAmount)
        {
            if (!isdealerbusted())
            {
                if (handvalue < 17)
                {
                    //dealer draw from deck into dealer's hand
                    Card drawncard = theDeck.drawcard();
                    //add card value to handvalue
                    handvalue += drawncard.ValueOf;
                    dealerhand.Add(drawncard);
                    //assign card image to picturebox
                }
                else
                {
                    MessageBox.Show("Dealer stands.");  //stands
                    //compare player and dealer hands
                    if (handvalue > playerHandValue)
                    {
                        //print dealer wins
                        MessageBox.Show(string.Format("Dealer Wins! You lose ${0}", betAmount));
                        //subtract bet from player balance
                        //exit
                    }
                    else if (handvalue < playerHandValue)
                    {//print player wins
                        MessageBox.Show(string.Format("Player Wins! You win ${0}!", betAmount));
                        //add bet to player balance
                        //exit
                    }
                    else
                    {
                        //print push/tie game
                        MessageBox.Show(string.Format("Push. You get your bet of ${0} back.", betAmount));
                        //save player balance
                        //exit
                    }
                    dealerdone = true;
                }
            }
            else
            {
                MessageBox.Show("The dealer is busted!");//say dealer is busted
                dealerdone = true;
            }
        }

        public void resetdealer()
        {
            handvalue = 0;
            dealerhand.Clear();
            dealerdone = false;
        }
    }
}
