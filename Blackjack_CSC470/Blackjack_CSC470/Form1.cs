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
        public Form1()
        {
            InitializeComponent();
            Deck theDeck = new Deck();
            Dealer theDealer = new Dealer(theDeck);
            Player thePlayer = new Player(theDeck);
            try
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //load player balance
            //player
            pictureBox1.Image = Card.GetBackImage();
            pictureBox2.Image = Card.GetBackImage();
            //dealer
            pictureBox3.Image = Card.GetBackImage();
            pictureBox4.Image = Card.GetBackImage();
            //enter bet amount
        }

        private void hit_Click(object sender, EventArgs e)
        {
            
        }

        private void stand_Click(object sender, EventArgs e)
        {
            
        }
    }
}
