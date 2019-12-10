using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack_CSC470
{
    public partial class BlackJack : Form
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
        public List<User> users = new List<User>();
        private IFormatter formatter = new BinaryFormatter();
        public Guid LoggedInPlayer;
        private SaveData saveData = null;
        bool lockedbet = false;
        bool insurance = false;
        int insurancebet = 0;
        public BlackJack()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bets.Items.Add(10); //betsList.Items.Add("$10.00");
            bets.Items.Add(20); //betsList.Items.Add("$20.00");
            bets.Items.Add(30); //betsList.Items.Add("$30.00");
            bets.Items.Add(50);
            bets.Items.Add(100);
            bets.Items.Add(250);
            bets.Items.Add(500);
            bets.SelectedIndex = 0;
            _ = bets.Focus();

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
            //load player balance
            FileStream reader = null;
            try
            {
                reader = File.Open(Path.Combine(Application.UserAppDataPath, "BlackJack07", "Balance.sav"), FileMode.Open);
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
            catch (PathTooLongException)
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
                        saveData = (SaveData)formatter.Deserialize(reader);
                    }
                    catch (FormatException) { saveData = null; }
                    catch (SerializationException)
                    {
                        saveData = null;
                    }
                    catch (EndOfStreamException)
                    {
                        saveData = null;
                    }
                    catch (OverflowException)
                    { }
                    reader.Close();
                }
            }
            if (saveData != null)
            {
                users = saveData.userlist;
                PlayerBalance = saveData.balance;
                LoggedInPlayer = saveData.LoggedInPlayer;
                if (saveData.playStarted)
                {
                    theDeck = saveData.deck;
                    thePlayer = saveData.player;
                    theDealer = saveData.dealer;
                    bets.SelectedIndex = saveData.theBet;
                    insurancebet = saveData.insuranceBet;
                    lockedbet = saveData.lockedInBet;
                    insurance = saveData.insurance;
                    Playercardvisible = saveData.Playercardvisible;
                    Dealercardvisible = saveData.Dealercardvisible;
                    for (int counter = 0; counter < 7; counter++)
                    {
                        Playercards[counter].Visible = saveData.PlayerVisibleBools[counter];
                        Dealercards[counter].Visible = saveData.DealerVisibleBools[counter];
                        if (Playercards[counter].Visible)
                        { Playercards[counter].Image = thePlayer.PlayerHand.ElementAt(counter).CardFront(); }
                        if (Dealercards[counter].Visible)
                        {
                            if (counter == 0)
                            { Dealercards[counter].Image = theDealer.DealerHand.ElementAt(counter).CardFront(); }
                            else
                            { Dealercards[counter].Image = Card.GetBackImage(); }
                        }
                    }
                }
                else
                {
                        for (int counter = 0; counter < 2; counter++)
                        {
                            Playercards[counter].Visible = true;
                            Playercards[counter].Image = Card.GetBackImage();
                            Dealercards[counter].Visible = true;
                            Dealercards[counter].Image = Card.GetBackImage();
                        }
                }
            }
            else
            { 
                    for (int counter = 0; counter < 2; counter++)
                    {
                        Playercards[counter].Visible = true;
                        Playercards[counter].Image = Card.GetBackImage();
                        Dealercards[counter].Visible = true;
                        Dealercards[counter].Image = Card.GetBackImage();
                    }
            }
            for (int counter = 2; counter < 7; counter++)
            {
                Playercards[counter].Visible = false;
                Playercards[counter].Image = Card.GetBackImage();
                Dealercards[counter].Visible = false;
                Dealercards[counter].Image = Card.GetBackImage();
            }
            UManage UserManagement = new UManage(LoggedInPlayer, users);
            UserManagement.ShowDialog(this);
            if (UserManagement.DialogResult == DialogResult.OK)
            {
                LoggedInPlayer = UserManagement.LoggedInUser.guid;
                PlayerBalance += UserManagement.AddAmount;
                GetLoggedinUser();
            }
            UserManagement.Dispose();
            GetLoggedinUser();
            PlayerBalanceLabel.Text = string.Format("Your balance is {0}", PlayerBalance.ToString("C0"));
            if (PlayerBalance < 10)
            {
                MessageBox.Show("You must add more money before you can play");
                Application.Exit();
            }
        }

        private void hit_Click(object sender, EventArgs e)
        {
            if (Insurancebutton.Visible)
            {
                insuranceamountbox.Text = "0";
                insuranceamountbox.Enabled = false;
                Insurancebutton.Enabled = false;
            }
            Newgame.Enabled = true;
            if (!lockedbet)
            {
                MessageBox.Show("You have not placed your bet. Bet and then try again.");
                return;
            }
            PlayerBalanceLabel.Text = string.Format("Your balance is {0}", PlayerBalance.ToString("C0"));
            if ((Playercardvisible < 7) && (thePlayer.HardHandValue < 21))
            {
                //players new card is displayed
                Playercards[Playercardvisible].Visible = true;
                //player draws card, adds value to HardHandValue, and card to hand.
                Playercards[Playercardvisible].Image = thePlayer.playerhit().CardFront();
                Playercardvisible++;
                //assign card image to picturebox
            }
            else if (Playercardvisible >= 7)
            {
                MessageBox.Show("You have the max number of cards in hand.\nYou must stand.");
            }
            if (thePlayer.HardHandValue > 21)
            {
                MessageBox.Show("The player has busted!");
                playerbet = 0;
                bets.SelectedIndex = 0;
                HitButton.Enabled = false;
                StandButton.Enabled = false;
                _ = Newgame.Focus();
                if (PlayerBalance < 5)
                {
                    MessageBox.Show("You are unable to make the minimum bet and must make room for another player.\nGoodbye.");
                }
            }
            else if (thePlayer.HardHandValue == 21 || thePlayer.SoftHandValue == 21)
            {
                MessageBox.Show("You have 21!");
                PlayerBalance += (int)(playerbet * 2.5);
                bets.SelectedIndex = 0;
                HitButton.Enabled = false;
                StandButton.Enabled = false;
                _ = Newgame.Focus();
            }
            PlayerBalanceLabel.Text = string.Format("Your balance is {0}", PlayerBalance.ToString("C0"));
        }

        private void stand_Click(object sender, EventArgs e)
        {
            if (Insurancebutton.Visible)
            {
                insuranceamountbox.Text = "0";
                insuranceamountbox.Enabled = false;
                Insurancebutton.Enabled = false;
            }
            if (!lockedbet)
            {
                MessageBox.Show("You have not placed your bet. Bet and then try again.");
                return;
            }
            //player chooses to stand. Start dealer functions
            if (insurance)
                Dealercards[Dealercardvisible].Image = theDealer.getdealerslastcard().CardFront();
            while (!isgameover)
            {
                theDealer.dealeraction(thePlayer.HardHandValue, playerbet);
                Dealercards[Dealercardvisible].Visible = true;
                Dealercards[Dealercardvisible].Image = theDealer.getdealerslastcard().CardFront();
                Dealercardvisible++;
                if (theDealer.handvalue < 17)
                { continue; }
                else
                { isgameover = true; }
            }
            //Use soft hand value if hand has ace and is better than hardhand value
            if (thePlayer.SoftHandValue > thePlayer.HardHandValue && thePlayer.SoftHandValue <= 21)
                thePlayer.HardHandValue = thePlayer.SoftHandValue;

            //compare player and dealer hands
            if (theDealer.handvalue > 21)
            {
                MessageBox.Show("The dealer has busted.\nPlayer wins.");
                PlayerBalance += (playerbet * 2);
            }
            else if (theDealer.handvalue == thePlayer.HardHandValue)
            {
                //print push/tie game
                MessageBox.Show(string.Format("Push. You get your bet of ${0} back.", playerbet));
                //return player bet
                PlayerBalance += playerbet;
                //exit
            }
            else if (theDealer.handvalue > thePlayer.HardHandValue)
            {
                //print dealer wins
                MessageBox.Show(string.Format("Dealer Wins! You lost ${0}", playerbet));
                //exit
            }
            else if (theDealer.handvalue < thePlayer.HardHandValue)
            {//print player wins
                MessageBox.Show(string.Format("Player Wins! You win ${0}!", playerbet));
                //add bet to player balance
                PlayerBalance += (2 * playerbet);
                //exit
            }
            PlayerBalanceLabel.Text = string.Format("Your balance is {0}", PlayerBalance.ToString("C0"));
            if (PlayerBalance < 5)
            {
                MessageBox.Show(string.Format("You have {0} unable to make the minimum bet and must make room for another player.\nGoodbye.", PlayerBalance.ToString("C0")));
            }
            HitButton.Enabled = false;
            StandButton.Enabled = false;
            Newgame.Enabled = true;
            _ = Newgame.Focus();
            isgameover = false;
        }
        private void Newgame_Click(object sender, EventArgs e)
        {
            if (PlayerBalance < 10)
            {
                MessageBox.Show("You must add more money to play.");
                return;
            }
            theDeck.shuffledeck();
            HitButton.Enabled = true;
            StandButton.Enabled = true;
            Newgame.Enabled = false;
            _ = bets.Focus();
            bets.Enabled = true;
            bets.SelectedIndex = 0;
            playerbet = 0;
            theDealer.resetdealer();
            thePlayer.resetplayer();
            HitButton.Enabled = true;
            lockedbet = false;
            insuranceamountbox.Visible = false;
            Insurancebutton.Visible = false;
            insurance = false;
            Lockbetbutton.Enabled = true;
            insurancebet = 0;
            for (int counter = 0; counter < 2; counter++)
            {
                Playercards[counter].Visible = true;
                Playercards[counter].Image = Card.GetBackImage();
                Dealercards[counter].Visible = true;
                Dealercards[counter].Image = Card.GetBackImage();
            }
            for (int counter = 2; counter < 7; counter++)
            {
                Playercards[counter].Visible = false;
                Playercards[counter].Image = Card.GetBackImage();
                Dealercards[counter].Visible = false;
                Dealercards[counter].Image = Card.GetBackImage();
            }
        }

        private void Form1_Closing(object sender, EventArgs e)
        {
            
            if (saveTheData)
            {
                FileStream writer = null;
                try
                {
                    writer = File.OpenWrite(Path.Combine(Application.UserAppDataPath, "BlackJack07", "Balance.sav"));
                }
                catch (DirectoryNotFoundException)
                {
                    Directory.CreateDirectory(Path.Combine(Application.UserAppDataPath, "BlackJack07"));
                    writer = File.OpenWrite(Path.Combine(Application.UserAppDataPath, "BlackJack07", "Balance.sav"));
                }
                finally
                {
                    saveData = new SaveData
                    {
                        userlist = users,
                        balance = PlayerBalance,
                        LoggedInPlayer = LoggedInPlayer,
                        playStarted = !Newgame.Enabled
                    };
                    if (!Newgame.Enabled)
                    {
                        saveData.theBet = bets.SelectedIndex;
                        saveData.insuranceBet = insurancebet;
                        saveData.lockedInBet = lockedbet;
                        saveData.deck = theDeck;
                        saveData.dealer = theDealer;
                        saveData.player = thePlayer;
                        saveData.Playercardvisible = Playercardvisible;
                        saveData.Dealercardvisible = Dealercardvisible;
                        for (int counter = 0; counter < 7; counter++)
                        {
                            saveData.PlayerVisibleBools[counter] = Playercards[counter].Visible;
                            saveData.DealerVisibleBools[counter] = Dealercards[counter].Visible;
                        }
                    }
                    formatter.Serialize(writer, saveData);
                    writer.Close();
                }
            }
            else
            {
                MessageBox.Show("Due to previously identified technical issues on your computer,\nwe cannot save your progrss. Goodbye.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UManage UserManagement = new UManage(LoggedInPlayer, users);
            UserManagement.ShowDialog(this);
            if (UserManagement.DialogResult == DialogResult.OK)
            {
                LoggedInPlayer = UserManagement.LoggedInUser.guid;
                PlayerBalance += UserManagement.AddAmount;
                GetLoggedinUser();
            }
            UserManagement.Dispose();
        }
        private void NewGameMethod()
        {
            //make unneeded cards invisible
            for (int counter = 2; counter < 7; counter++ )
            {
                Playercards[counter].Visible = false;
                Playercards[counter].Image = Card.GetBackImage();
                Dealercards[counter].Visible = false;
                Dealercards[counter].Image = Card.GetBackImage();
            }
            //display first two cards for dealer like in normal gameplay
            for (int counter = 0; counter < 2; counter++)
            {
                Dealercards[counter].Visible = true;
                Playercards[counter].Visible = true;
                Playercards[counter].Image = thePlayer.playerhit().CardFront();
            }
            Dealercards[0].Image = theDealer.getonedealercard().CardFront();
            //_ = theDealer.getonedealercard();
            Dealercard2.Image = Card.GetBackImage();
            Dealercardvisible = 1;
            Playercardvisible = 2;
            Newgame.Enabled = false;
            //if statement for insurance
            if (theDealer.getdealerslastcard().Face == 1)
            {
                //display insurance button
                Insurancebutton.Visible = true;
                insuranceamountbox.Visible = true;
                insurance = true;
            }
        }
        private void GetLoggedinUser()
        {
            if (LoggedInPlayer == Guid.Empty)
            {
                LoggedInPlayerLabel.Text = "No one is currently logged in.";
                return;
            }
            else
            {
                if (users.Where(a => a.guid == LoggedInPlayer).Any())
                {
                    switch (users.Where(a => a.guid == LoggedInPlayer).Count())
                    {
                        case 1:
                            {
                                LoggedInPlayerLabel.Text = users.Where(a => a.guid == LoggedInPlayer).Single().DisplayName;
                                break;
                            }
                        default:
                            {
                                LoggedInPlayerLabel.Text = "There was an error determining who is logged in.";
                                break;
                            }
                    }
                }
                else
                { LoggedInPlayerLabel.Text = "An unknown user is logged in."; }
            }
            return;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "This game has been created by\nJustin Gyolai\nErik Jepsen\nDanial Madson\nEthan Masching\nKira Lange\nfor the Software Engineering class at Dakota State University.",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void Lockbetbutton_Click(object sender, EventArgs e)
        {
            if (int.Parse(bets.SelectedIndex.ToString()) < PlayerBalance)
                bets.Enabled = false;
            else
            {
                MessageBox.Show("You can't bet more than you have");
                return;
            }
            lockedbet = true;
            playerbet = int.Parse(bets.SelectedItem.ToString());
            PlayerBalance -= playerbet;
            Newgame.Enabled = false;
            NewGameMethod();
            if (thePlayer.HardHandValue == 21 || thePlayer.SoftHandValue == 21 && !insurance)
            {
                MessageBox.Show("You have Blackjack!");
                PlayerBalance += (int)(playerbet * 2.5);
                bets.SelectedIndex = 0;
                HitButton.Enabled = false;
                StandButton.Enabled = false;
                Newgame.Enabled = true;
                _ = Newgame.Focus();
            }
            else
                Lockbetbutton.Enabled = false;
        }

        private void Insurancebutton_Click(object sender, EventArgs e)
        {
            insurancebet = int.Parse(insuranceamountbox.Text);
            if (insurancebet == 0)
            {
                MessageBox.Show("You must place a minimum bet of $1");
                return;
            }
            if (insurancebet > (playerbet / 2))
                insurancebet = playerbet / 2;
            insuranceamountbox.Text = insurancebet.ToString();
            PlayerBalance -= insurancebet;
            PlayerBalanceLabel.Text = string.Format("Your balance is {0}", PlayerBalance.ToString("C0"));
            Card temp = theDealer.getonedealercard();
            if (temp.Face == 10 || temp.ValueOf == 10)
            {
                Dealercards[Dealercardvisible].Image = theDealer.getdealerslastcard().CardFront();
                MessageBox.Show("The dealer has Blackjack. You get your insurance payout");
                PlayerBalance += insurancebet * 2;
                PlayerBalanceLabel.Text = string.Format("Your balance is {0}", PlayerBalance.ToString("C0"));
                Newgame.Enabled = true;
            }
            else
            {
                MessageBox.Show("The dealer does not have Blackjack. You lose your insurance.");
                HitButton.Enabled = true;
                StandButton.Enabled = true;
                HitButton.Enabled = true;
            }
            if (thePlayer.SoftHandValue == 21 && insurance)
            {
                MessageBox.Show("Push. You get your main bet back");
                PlayerBalance += playerbet;
            }
            if (thePlayer.HardHandValue == 21 || thePlayer.SoftHandValue == 21 && !insurance)
            {
                MessageBox.Show("You have Blackjack!");
                PlayerBalance += (int)(playerbet * 2.5);
                bets.SelectedIndex = 0;
                HitButton.Enabled = false;
                StandButton.Enabled = false;
                Newgame.Enabled = true;
                _ = Newgame.Focus();
            }
        }
    }
}
