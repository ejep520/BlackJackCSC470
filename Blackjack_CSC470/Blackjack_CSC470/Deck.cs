﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_CSC470
{
    [Serializable]
    public class Deck
    {
        private const int decks = 1; // How many decks are getting shuffled together?

        private List<Card> deck = new List<Card>();
        private HashSet<Card> shuffledCards = new HashSet<Card>();
        public Deck()
        {
            deck.Clear();
            for (int deckNo = 0; deckNo < decks; deckNo++)
            {
                for (int suit = 0; suit < 4; suit++)
                {
                    for (int face = 1; face < 14; face++)
                    {
                        deck.Add(new Card(face, suit, deckNo));
                    }
                }
            }
            shuffledeck();
        }
        public void shuffledeck()
        {
            shuffledCards.Clear();
            Random random = new Random();
            int getCard = random.Next() % (52 * decks);
            while (shuffledCards.Count < (52 * decks))
            {
                shuffledCards.Add(deck[getCard]);
                getCard = random.Next() % (52 * decks);
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
