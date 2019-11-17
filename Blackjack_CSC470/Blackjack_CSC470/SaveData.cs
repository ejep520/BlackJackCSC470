using System;
using System.Collections.Generic;

namespace Blackjack_CSC470
{
    [Serializable]
    public class SaveData
    {
        public bool playStarted;
        public Deck deck;
        public Player player;
        public Dealer dealer;
        public List<User> userlist;
        public Guid LoggedInPlayer;
        public int balance;
        public int theBet;
        public int Playercardvisible;
        public int Dealercardvisible;
        public bool[] PlayerVisibleBools = new bool[7];
        public bool[] DealerVisibleBools = new bool[7];
    }
}