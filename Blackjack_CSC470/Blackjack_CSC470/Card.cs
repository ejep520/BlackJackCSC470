using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_CSC470
{
    class Card
    {
        private int _valueOf = 2;
        private int _suit = 0;
        private int _face = 1;
        /******
         * Suits
         * 0 - Hearts
         * 1 - Diamonds
         * 2 - Clubs
         * 3 - Spades
         ******
         * Face
         * 1 - Ace
         * 11 - Jack
         * 12 - Queen
         * 13 - King
         ******/
        public Card(int SetFace, int SetSuit)
        {
            Face = SetFace;
            ValueOf = SetFace;
            Suit = SetSuit;
        }
        public Bitmap CardFront()
        {
            string Name_0 = "Images\\";
            string Name_1;
            string Name_2 = "_of_";
            string Name_3;
            string Name_4 = ".png";
            switch (Face)
            {
                case 1:
                    Name_1 = "ace";
                    break;
                case 11:
                    Name_1 = "jack";
                    break;
                case 12:
                    Name_1 = "queen";
                    break;
                case 13:
                    Name_1 = "king";
                    break;
                default:
                    Name_1 = Face.ToString();
                    break;
            }
            switch (Suit)
            {
                case 0:
                    Name_3 = "hearts";
                    break;
                case 1:
                    Name_3 = "diamonds";
                    break;
                case 2:
                    Name_3 = "spades";
                    break;
                default:
                    Name_3 = "clubs";
                    break;
            }
            return new Bitmap(new FileStream(string.Concat(Name_0, Name_1, Name_2, Name_3, Name_4), FileMode.Open));
        }
        public int ValueOf
        {
            set
            {
                if (_face >= 2 && _face < 11)
                {
                    _valueOf = _face;
                }
                else if (_face == 1 && ((value == 1) || (value == 11)))
                {
                    _valueOf = value;
                }
                else if (_face >= 11 && _face < 14)
                {
                    _valueOf = 10;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The value must be between 2 and 10, unless the card is an ace.", (Exception)null);
                }
            }
            get => _valueOf;
        }
        public int Suit
        {
            private set
            {
                if ((value >= 0) && (value <= 3))
                {
                    _suit = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The suit must be between 0 and 3 (inclusive).", (Exception)null);
                }
            }
            get => _suit;
        }
        public int Face
        {
            private set
            {
                if ((value > 0) && (value < 14))
                {
                    _face = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The face value must be between 1 and 13.", (Exception)null);
                }
            }
            get => _face;
        }
    }
}
