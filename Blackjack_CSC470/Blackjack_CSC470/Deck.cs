using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_CSC470
{
    public class Deck
    {
        // int Num_Cards = 52;
        // int oncard = 0;
        private List<Card> deck = new List<Card>();
        private HashSet<Card> shuffledCards = new HashSet<Card>();
        public Deck()
        {
            deck.Clear();
            for (int counter = 0; counter < 4; counter++)
            {
                for (int face = 1; face < 14; face++)
                {
                    deck.Add(new Card(face, counter));
                }
            }
            shuffledeck();
        }
        public void shuffledeck()
        {
            shuffledCards.Clear();
            Random random = new Random();
            int getCard = random.Next() % 52;
            while (shuffledCards.Count < 52)
            {
                shuffledCards.Add(deck[getCard]);
                getCard = random.Next() % 52;
            }
            return;
        }

        public Card drawcard()
        {
            Card card = (Card)shuffledCards.Take(1).Single();
            shuffledCards.Remove(card);
            return card;
        }
    }
}
