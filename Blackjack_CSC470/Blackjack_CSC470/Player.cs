using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_CSC470
{
    class Player
    {
        int handvalue = 0;

        void addcardvalue(Card card)
        {
            handvalue = handvalue + card.Face;
        }

        bool isplayerbusted()
        {
            if (handvalue > 21)
                return true;
            else
                return false;
        }
    }
}
