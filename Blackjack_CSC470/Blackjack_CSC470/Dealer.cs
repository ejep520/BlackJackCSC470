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
                    Console.WriteLine("Draw.");  //draw card
                else
                    Console.WriteLine("Stand"); //stand
            }
            else
            {
                Console.WriteLine("Dealer is busted!");//say dealer is busted
            }
        }
    }
}
