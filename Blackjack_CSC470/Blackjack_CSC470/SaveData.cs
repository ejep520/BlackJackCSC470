using System;
using System.Collections.Generic;

namespace Blackjack_CSC470
{
    [Serializable]
    public class SaveData
    {
        Deck deck;
        Player player;
        Dealer dealer;
        List<User> userlist;
    }
}