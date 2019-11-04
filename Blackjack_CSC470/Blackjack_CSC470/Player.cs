using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_CSC470
{
    public class Player
    {
        public int handvalue = 0;
        List<Card> playerhand = new List<Card>();
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

        public bool isplayerbusted()
        {
            return handvalue > 21;
        }

        public Card playerhit()
        {
            Card drawncard = theDeck.drawcard();
            this.addcardvalue(drawncard);
            return drawncard;
        }

        public void resetplayer()
        {
            handvalue = 0;
            playerhand.Clear();
        }

        public Card getplayerhand()
        {
            return playerhand.Last();
        }
    }
}
