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
        public int PlayerBalance = 100;
        int playerbet = 0;
        int Playercardvisible = 0;
        int Dealercardvisible = 0;
        bool saveTheData = true;
        PictureBox[] Playercards = new PictureBox[7];
        PictureBox[] Dealercards = new PictureBox[7];
        bool isgameover = false;
        bool hashit;
        //List<string> BetsList = new List<string>();
        // ComboBox betsList = new ComboBox();
        
        
        public Form1()
        {
            InitializeComponent();
            PlayerBalanceLabel.Text = string.Format("Your balance is {0}", PlayerBalance.ToString("C0"));
            //game loop (work in progress)
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            bets.Items.Add(0);
            bets.Items.Add(5); //betsList.Items.Add("$5.00");
            bets.Items.Add(10); //betsList.Items.Add("$10.00");
            bets.Items.Add(15); //betsList.Items.Add("$15.00");
            bets.SelectedIndex = 0;
            _ = bets.Focus();
            //load player balance
            StreamReader reader = null;
            try
            {
                reader = File.OpenText(Path.Combine(Application.UserAppDataPath, "BlackJack07", "Balance.sav"));
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(Path.Combine(Application.UserAppDataPath, "BlackJack07"));
                File.Create(Path.Combine(Application.UserAppDataPath, "BlackJack07", "Balance.sav")).Close();
            }
            catch (FileNotFoundException)
            {
                File.Create(Path.Combine(Application.UserAppDataPath, "BlackJack07", "Balance.sav")).Close();
            }
            catch(PathTooLongException)
            {
                MessageBox.Show("Due to technical issues, we cannot retrieve or save the balance of your game today. Sorry!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                saveTheData = false;
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Due to technical issues, we cannot retrieve or save the balance of your game today. Sorry!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                saveTheData = false;
            }
            finally
            {
                if (reader != null)
                {
                    try
                    {
                        PlayerBalance = int.Parse(reader.ReadToEnd());
                    }
                    catch (FormatException) { }
                    catch (OverflowException)
                    {
                        MessageBox.Show("There was an overflow error!");
                    }
                    reader.Close();
                }
            }
            //player
            Playercard1.Image = Card.GetBackImage();
            Playercard1.Visible = true;
            Playercard2.Image = Card.GetBackImage();
            Playercard2.Visible = true;
            //dealer
            Dealercard1.Image = Card.GetBackImage();
            Dealercard1.Visible = true;
            Dealercard2.Image = Card.GetBackImage();
            Dealercard2.Visible = true;
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

            //display first two cards for dealer like in normal gameplay
            Dealercards[Dealercardvisible].Visible = true;
            Dealercards[Dealercardvisible].Image = theDealer.getonedealercard().CardFront();
            Dealercardvisible++;
            PlayerBalanceLabel.Text = string.Format("Your balance is {0}", PlayerBalance.ToString("C0"));
        }

        private void hit_Click(object sender, EventArgs e)
        {
            if (bets.SelectedIndex == 0)
            {
                MessageBox.Show("You have not placed your bet. Bet and then try again.");
                return;
            }
            bets.Enabled = false;
            if (!hashit)
            {
                PlayerBalance -= int.Parse(bets.SelectedItem.ToString());
                playerbet = int.Parse(bets.SelectedItem.ToString());
                hashit = true;
            }
            PlayerBalanceLabel.Text = string.Format("Your balance is {0}", PlayerBalance.ToString("C0"));
            if ((Playercardvisible < 7) && (thePlayer.handvalue < 21))
            {
                //players new card is displayed
                Playercards[Playercardvisible].Visible = true;
                //player draws card, adds value to handvalue, and card to hand.
                Playercards[Playercardvisible].Image = thePlayer.playerhit().CardFront();
                Playercardvisible++;
                //assign card image to picturebox
            }
            else if (Playercardvisible >= 7)
            {
                MessageBox.Show("You have the max number of cards in hand\n you must stand");
            }
            if (thePlayer.handvalue > 21)
            {
                MessageBox.Show("The player has busted!");
                playerbet = 0;
                bets.SelectedIndex = 0;
                HitButton.Enabled = false;
                StandButton.Enabled = false;
                if (PlayerBalance < 5)
                {
                    MessageBox.Show("You are unable to make the minimum bet and must make room for another player.\nGoodbye.");
                }
            }
            else if (thePlayer.handvalue == 21)
            {
                MessageBox.Show("Blackjack!");
                PlayerBalance += (int)(playerbet * 2.5);
                bets.SelectedIndex = 0;
                HitButton.Enabled = false;
                StandButton.Enabled = false;
            }
            PlayerBalanceLabel.Text = string.Format("Your balance is {0}", PlayerBalance.ToString("C0"));
        }

        private void stand_Click(object sender, EventArgs e)
        {
            bets.Enabled = false;
            //change second dealer card to show card front instead of back
            Dealercards[Dealercardvisible].Image = theDealer.getonedealercard().CardFront();
            Dealercardvisible++;
            //player chooses to stand. Start dealer functions
            while (!isgameover)
            {
                theDealer.dealeraction(thePlayer.handvalue, playerbet);
                Dealercards[Dealercardvisible].Visible = true;
                Dealercards[Dealercardvisible].Image = theDealer.getdealerslastcard().CardFront();
                Dealercardvisible++;
                if (theDealer.handvalue < 17)
                { continue; }
                else
                { isgameover = true; }
            }
            //compare player and dealer hands
            if (theDealer.handvalue > 21)
            {
                MessageBox.Show("The dealer has busted.\nPlayer wins.");
                PlayerBalance += (playerbet * 2);
            }
            else if (theDealer.handvalue == thePlayer.handvalue)
            {
                //print push/tie game
                MessageBox.Show(string.Format("Push. You get your bet of ${0} back.", playerbet));
                //return player bet
                PlayerBalance += playerbet;
                //exit
            }
            else if (theDealer.handvalue > thePlayer.handvalue)
            {
                //print dealer wins
                MessageBox.Show(string.Format("Dealer Wins! You lose ${0}", playerbet));
                //exit
            }
            else if (theDealer.handvalue < thePlayer.handvalue)
            {//print player wins
                MessageBox.Show(string.Format("Player Wins! You win ${0}!", playerbet));
                //add bet to player balance
                PlayerBalance += (2 * playerbet);
                //exit
            }
            playerbet = 0;
            PlayerBalanceLabel.Text = string.Format("Your balance is {0}", PlayerBalance.ToString("C0"));
            bets.Enabled = true;
            bets.SelectedIndex = 0;
            if (PlayerBalance < 5)
            {
                MessageBox.Show(string.Format("You have {0} unable to make the minimum bet and must make room for another player.\nGoodbye.", PlayerBalance.ToString("C0")));
            }
        }

        private void betvalues_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bet values
        }

        private void Newgame_Click(object sender, EventArgs e)
        {
            theDeck.shuffledeck();
            Playercard1.Image = Card.GetBackImage();
            Playercard2.Image = Card.GetBackImage();
            Playercard1.Visible = true;
            Playercard2.Visible = true;
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
            Playercardvisible = 0;
            Dealercardvisible = 0;
            isgameover = false;
            Dealercards[Dealercardvisible].Visible = true;
            Dealercards[Dealercardvisible].Image = theDealer.getonedealercard().CardFront();
            Dealercardvisible++;
            HitButton.Enabled = true;
            StandButton.Enabled = true;
            Newgame.Enabled = false;
            _ = bets.Focus();
            bets.Enabled = true;
            bets.SelectedIndex = 0;
        }

        private void Form1_Closing(object sender, EventArgs e)
        {
            if (saveTheData)
            {
                StreamWriter writer = null;
                try
                {
                    writer = File.CreateText(Path.Combine(Application.UserAppDataPath, "BlackJack07", "Balance.sav"));
                }
                catch (DirectoryNotFoundException)
                {
                    Directory.CreateDirectory(Path.Combine(Application.UserAppDataPath, "BlackJack07"));
                    writer = File.CreateText(Path.Combine(Application.UserAppDataPath, "BlackJack07", "Balance.sav"));
                }
                finally
                {
                    writer.Write(PlayerBalance.ToString());
                    writer.Close();
                }
            }
            else
            {
                MessageBox.Show("Due to previously identified technical issues on your computer,\nwe cannot save your progrss. Goodbye.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // comboBox1.DataSource = betsList;
           // if (!hashit)
           //     playerbet = comboBox1.SelectedIndex;
        }
    }
}
