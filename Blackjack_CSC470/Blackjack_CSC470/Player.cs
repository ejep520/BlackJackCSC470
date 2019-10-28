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
        decimal balance;
        List<Card> playerhand;
        Deck theDeck;
        public Player(Deck thedeck)
        {
            theDeck = thedeck;
        }
        public void addcardvalue(Card card)
        {
            handvalue = handvalue + card.ValueOf;
            playerhand.Add(card);
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
