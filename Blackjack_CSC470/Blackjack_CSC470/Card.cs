using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_CSC470
{
    /// <summary>
    /// Each instance of this class is a unique card.
    /// </summary>
    public class Card
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
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="SetFace">This is the face value of the card being created.</param>
        /// <param name="SetSuit">This is the suit of the card being created
        /// <list type="bullet">
        /// <item>
        /// <term>0</term>
        /// <description>Hearts</description>
        /// </item>
        /// <item>
        /// <term>1</term>
        /// <description>Diamonds</description>
        /// </item>
        /// <item>
        /// <term>2</term>
        /// <description>Clubs</description>
        /// </item>
        /// <item>
        /// <term>3</term>
        /// <description>Spades</description>
        /// </item>
        /// </list>
        /// </param>
        public Card(int SetFace, int SetSuit)
        {
            Face = SetFace;
            ValueOf = SetFace;
            Suit = SetSuit;
        }
///<returns>
///This returns a bitmap of the front of the card.
///</returns>
        public Image CardFront()
        {
            const string Name_0 = @"Blackjack_CSC470.Images.";
            string Name_1 = Face switch
            {
                1 => "ace",
                11 => "jack",
                12 => "queen",
                13 => "king",
                _ => Face.ToString(),
            };
            const string Name_2 = "_of_";
            string Name_3 = Suit switch
            {
                0 => "hearts",
                1 => "diamonds",
                2 => "spades",
                _ => "clubs",
            };
            const string Name_4 = ".png";
            string filename = string.Concat(Name_0, Name_1, Name_2, Name_3, Name_4);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Image ReturnVal;
            using (Stream stream = assembly.GetManifestResourceStream(filename))
            {
                ReturnVal = Image.FromStream(stream);
            }
            return ReturnVal;
        }
        /// <summary>
        /// This method returns an image of the back of the card.
        /// </summary>
        /// <returns>Image of the back of the card.</returns>
        static public Image GetBackImage()
        {
            const string filename = @"Blackjack_CSC470.Images.back.png";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Image ReturnVal;
            using (Stream stream = assembly.GetManifestResourceStream(filename))
            {
                ReturnVal = Image.FromStream(stream);
            }
            return ReturnVal;
        }
        /// <summary>
        /// This is the value that is used when computing the value of the hand.
        /// </summary>
        /// <value>This int sets/gets the _valueOf private int.</value>
        public int ValueOf
        {
            ///<param name="value">This integer must be between 1 and 11.</param>
            ///<exception cref="ArgumentOutOfRangeException">The value given was <1 or >11.</exception>
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
        /// <summary>This value represents the suit.
        /// <list type="bullet">
        /// <item>
        /// <term>0</term>
        /// <description>Hearts</description>
        /// </item>
        /// <item>
        /// <term>1</term>
        /// <description>Diamonds</description>
        /// </item>
        /// <item>
        /// <term>2</term>
        /// <description>Clubs</description>
        /// </item>
        /// <item>
        /// <term>3</term>
        /// <description>Spades</description>
        /// </item>
        /// </list>
        /// </summary>
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
        /// <summary>
        /// <para>This represents the face value. This is different from the value.</para>
        /// <seealso cref="ValueOf"/>
        /// </summary>
        public int Face
        {
            ///<exception cref="ArgumentOutOfRangeException">The face value must be between 1 and 13.</exception>
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
