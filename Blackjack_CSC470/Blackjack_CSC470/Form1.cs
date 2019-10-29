using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack_CSC470
{
    public partial class Form1 : Form
    {
        static Deck theDeck = new Deck();
        Dealer theDealer = new Dealer(theDeck);
        Player thePlayer = new Player(theDeck);
        int Playercardvisible = 2;
        int Dealercardvisible = 2;
        PictureBox[] Playercards = new PictureBox[7];
        PictureBox[] Dealercards = new PictureBox[7];
        
        public Form1()
        {
            InitializeComponent();

            //game loop (work in progress)
            while(thePlayer.isplayerbusted() == false)
            {
                
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            //load player balance
            //player
            Playercard1.Image = Card.GetBackImage();
            Playercard2.Image = Card.GetBackImage();
            //dealer
            Dealercard1.Image = Card.GetBackImage();
            Dealercard2.Image = Card.GetBackImage();
            //make unneeded cards invisible
            Playercard3.Visible = false;
            Playercard4.Visible = false;
            Playercard5.Visible = false;
            Playercard6.Visible = false;
            Playercard7.Visible = false;
            Dealercard3.Visible = false;
            Dealercard4.Visible = false;
            Dealercard5.Visible = false;
            Dealercard6.Visible = false;
            Dealercard7.Visible = false;
            //enter bet amount

            //set array for visible cards
            Playercards[0] = Playercard1;
            Playercards[1] = Playercard2;
            Playercards[2] = Playercard3;
            Playercards[3] = Playercard4;
            Playercards[4] = Playercard5;
            Playercards[5] = Playercard6;
            Playercards[6] = Playercard7;
            Dealercards[0] = Dealercard1;
            Dealercards[1] = Dealercard2;
            Dealercards[2] = Dealercard3;
            Dealercards[3] = Dealercard4;
            Dealercards[4] = Dealercard5;
            Dealercards[5] = Dealercard6;
            Dealercards[6] = Dealercard7;
        }

        private void hit_Click(object sender, EventArgs e)
        {
            //player draws card, adds value to handvalue, and card to hand.
            thePlayer.playerhit();
            //players new card is displayed
            
        }

        private void stand_Click(object sender, EventArgs e)
        {
            //player chooses to stand. Start dealer functions
            
             theDealer.dealeraction();
        }

        private void betvalues_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Newgame_Click(object sender, EventArgs e)
        {
            theDeck.shuffledeck();
            Playercard1.Image = Card.GetBackImage();
            Playercard2.Image = Card.GetBackImage();
            Playercard3.Visible = false;
            Playercard4.Visible = false;
            Playercard5.Visible = false;
            Playercard6.Visible = false;
            Playercard7.Visible = false;
            Dealercard1.Image = Card.GetBackImage();
            Dealercard2.Image = Card.GetBackImage();
            Dealercard3.Visible = false;
            Dealercard4.Visible = false;
            Dealercard5.Visible = false;
            Dealercard6.Visible = false;
            Dealercard7.Visible = false;
            thePlayer.resetplayer();
            theDealer.resetdealer();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
