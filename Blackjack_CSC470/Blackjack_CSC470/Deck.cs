using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_CSC470
{
    class Deck
    {
        int Num_Cards = 52;
        int oncard = 0;
        List<Card> deck;
        HashSet<Card> shuffledCards;
        void shuffledeck()
        {
            deck.Clear();
            Random random = new Random();
            int getCard = random.Next() % 52;
            while (shuffledCards.Count < 52)
            {
                shuffledCards.Add(deck[getCard]);
                getCard = random.Next() % 52;
            }
            return;
        }

        Card drawcard()
        {
            Card card = (Card)shuffledCards.Take(1);
            shuffledCards.Remove(card);
            return card;
        }
    }
}
