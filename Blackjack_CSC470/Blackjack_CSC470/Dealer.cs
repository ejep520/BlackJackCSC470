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
                if (handvalue<17)
                    //draw card
                else
                    //stand
            }
            else
            {
                //say dealer is busted
            }
        }
    }
}
