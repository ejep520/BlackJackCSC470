using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_CSC470
{
    [Serializable]
    public class Player
    {
        public int HardHandValue = 0;
        public int SoftHandValue = 0;
        private List<Card> PrivHand = new List<Card>();
        Deck theDeck;
        public Guid UserID;

        public Player(Deck thedeck)
        {
            theDeck = thedeck;
            UserID = Guid.NewGuid();
        }
        public Player(Deck thedeck, Guid userID)
        {
            theDeck = thedeck;
            UserID = userID;
        }
        public void addcardvalue(Card card)
        {
            HardHandValue += card.ValueOf;
            if (card.Face == 1)
                SoftHandValue += 11;
            else
                SoftHandValue += card.ValueOf;
            PrivHand.Add(card);
        }

        public bool isplayerbusted()
        {
            return HardHandValue > 21;
        }

        public Card playerhit()
        {
            Card drawncard = theDeck.drawcard();
            this.addcardvalue(drawncard);
            return drawncard;
        }

        public void resetplayer()
        {
            HardHandValue = 0;
            SoftHandValue = 0;
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
