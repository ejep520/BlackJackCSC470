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
        List<Card> deck;

        void shuffledeck()
        {
            deck.Clear();
            int face;
            int suit;
            for (suit=0; suit<=3; suit++)
            {
                for (face=1; face<=13; face++)
                {
                    deck.Add(new Card(face, suit));
                }
            }
            
        }
    }
}
