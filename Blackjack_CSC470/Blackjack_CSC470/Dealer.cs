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

        public void dealeraction()
        {
            while(true)
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
                    {
                        Console.WriteLine("Dealer Stands");  //stands
                        //compare player and dealer hands
                        if (/*dealerhand > playerhand*/)
                        {
                            //print dealer wins
                            MessageBox.Show("Dealer Wins! You lose 'X' amount of money.");
                            //subtract bet from player balance
                            //exit
                        }
                        else if (/*dealerhand < playerhand*/)
                        {//print player wins
                            MessageBox.Show("Player Wins! You win 'X' amount of money.");
                            //add bet to player balance
                            //exit
                        }
                        else
                        {
                            //print push/tie game
                            MessageBox.Show("Push. You get your 'bet' amount back.")
                            //save player balance
                            //exit
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Dealer is busted!");//say dealer is busted
                }
            }
        }

        public void resetdealer()
        {
            handvalue = 0;
            dealerhand.Clear();
        }
    }
}
