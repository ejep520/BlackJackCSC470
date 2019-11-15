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
        private List<Card> PrivHand = new List<Card>();
        Deck theDeck;
        Guid UserID;

        public Player(Deck thedeck)
        {
            theDeck = thedeck;
            UserID = new Guid();
        }
        public Player(Deck thedeck, Guid userID)
        {
            theDeck = thedeck;
            UserID = userID;
        }
        public void addcardvalue(Card card)
        {
            handvalue = handvalue + card.ValueOf;
            PrivHand.Add(card);
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
            PrivHand.Clear();
        }

        public Card getplayerhand()
        {
            return PrivHand.Last();
        }
        public IReadOnlyCollection<Card> PlayerHand
        {
            get => PrivHand.AsReadOnly();
        }
    }
}
