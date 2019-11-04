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
            if (handvalue > 21)
                return true;
            else
                return false;
        }

        public Card getdealerslastcard()
        {
            return dealerhand.Last();
        }

        public int getdealerhandvalue()
        {
            return handvalue;
        }

        public void dealeraction(int playerHandValue)
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
                    Console.WriteLine("Dealer Stands");  //stands
                    //compare player and dealer hands
                    if (handvalue > playerHandValue)
                    {
                        //print dealer wins
                        MessageBox.Show("Dealer Wins! You lose 'X' amount of money.");
                        //subtract bet from player balance
                        //exit
                    }
                    else if (handvalue < playerHandValue)
                    {//print player wins
                        MessageBox.Show("Player Wins! You win 'X' amount of money.");
                        //add bet to player balance
                        //exit
                    }
                    else
                    {
                        //print push/tie game
                        MessageBox.Show("Push. You get your 'bet' amount back.");
                        //save player balance
                        //exit
                    }
                    dealerdone = true;
                }
            }
            else
            {
                Console.WriteLine("Dealer is busted!");//say dealer is busted
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
