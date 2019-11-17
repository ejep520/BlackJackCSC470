using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Blackjack_CSC470
{
    public partial class UManage : Form
    {
        private bool PrevCCImageState;
        public List<User> users;
        public User LoggedInUser;
        public int AddAmount;
        private int UserIndexNo = -1;
        private readonly SHA512 sHA = new SHA512Managed();
        private readonly UnicodeEncoding ue = new UnicodeEncoding();
        public UManage(Guid currentUser, List<User> GetUsers)
        {
            InitializeComponent();
            users = GetUsers;
            CCErrorProvider.Clear();
            UserLoginErrorProv.Clear();
            UserMaintErrorProv.Clear();
            if (currentUser == Guid.Empty)
            { }
            else
            {
                UserIndexNo = users.FindIndex(a => a.guid == currentUser);
                LoggedInUser = users[UserIndexNo];
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            CCVImage.Visible = false;
            CCImage.Visible = false;
            CenterToScreen();
            Enabled = true;
            if (LoggedInUser != null)
                UNameEnterbox.Text = LoggedInUser.UName;
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            //log in button
            /*
            * relative text box names
            * Username text box: UserNameEnterBox
            * Password text box: Passwordbox
            * Start amount text box: StartAmountBox
            */
            //get username
            string loginname = UNameEnterbox.Text;
            //get starting amount
            if ((LoggedInUser == null) && users.Where(a => a.UName == UNameEnterbox.Text).Any())
            {
                switch (users.Where(a => a.UName == UNameEnterbox.Text).Count())
                {
                    case 1:
                        {
                            User MaybeUser = users.Where(a => a.UName == UNameEnterbox.Text).Single();
                            byte[] MaybePass = sHA.ComputeHash(ue.GetBytes(Passwordbox.Text));
                            if (MaybeUser.PassWdMatch(MaybePass))
                            {
                                LoggedInUser = users.Where(a => a.UName == UNameEnterbox.Text).Single();
                                UserIndexNo = users.FindIndex(a => a.guid == LoggedInUser.guid);
                                AddAmount = 0;
                                _ = int.TryParse(Startamountbox.Text, out AddAmount);
                                DialogResult = DialogResult.OK;
                                Close();
                            }
                            else
                            {
                                UserMaintErrorProv.SetError(Passwordbox, "Invalid password!");
                            }
                            break;
                        }
                    default:
                        { throw new Exception("We found two users with the same user name!"); }
                }
            }
        }
        private void NewUserButton_Click(object sender, EventArgs e)
        {
            //create new user button
            /*relative text box names
             * Username text box: Createusernamebox
             * Password text box: Createpasswordbox
             * First name text box: Firstnamebox
             * Last name text box: Lastnamebox
             * Address name text box: Addressbox
             * Phone number text box: Phonenumberbox
             * Credit Card text box: Creditcardbox
             * Security question text box: Questionbox
             * Security question answer text box: Questionanswerbox
             */
            UserLoginErrorProv.Clear();
            User User1 = new User(CreateUserNameBox.Text, Firstnamebox.Text, Lastnamebox.Text, Address1box.Text,
                                  Address2box.Text, Citybox.Text, Statebox.Text, int.Parse(Zipbox.Text),
                                  sHA.ComputeHash(ue.GetBytes(CreatePasswordBox.Text)), sHA.ComputeHash(ue.GetBytes(Creditcardbox.Text)), sHA.ComputeHash(ue.GetBytes(CCVbox.Text)), sHA.ComputeHash(ue.GetBytes(Expdatebox.Text)),
                                  Questionbox.Text, sHA.ComputeHash(ue.GetBytes(Questionanswerbox.Text)), int.Parse(Creditcardbox.Text.Substring(Creditcardbox.Text.Length - 4)));
            if (!users.Where(a => a.UName == User1.UName).Any())
                users.Add(User1);
            else
                UserMaintErrorProv.SetError(CreateUserNameBox, "This user already exists.");
        }
        private void ChangePassWdButton_Click(object sender, EventArgs e)
        {
            UserMaintErrorProv.Clear();
            CCErrorProvider.Clear();
            if (string.IsNullOrEmpty(Passwordbox.Text))
            { UserMaintErrorProv.SetError(Passwordbox, "You must first enter your old password."); }
            else if (!LoggedInUser.PassWdMatch(sHA.ComputeHash(ue.GetBytes(Passwordbox.Text))))
            { UserMaintErrorProv.SetError(Passwordbox, "Your old password does not match!"); }
            else if (string.IsNullOrEmpty(CreatePasswordBox.Text))
            { UserMaintErrorProv.SetError(CreatePasswordBox, "You must enter a new password!"); }
            else
            {
                LoggedInUser.ChangePass(sHA.ComputeHash(ue.GetBytes(Passwordbox.Text)), sHA.ComputeHash(ue.GetBytes(CreatePasswordBox.Text)));
                UserMaintErrorProv.Clear();
                users.RemoveAt(UserIndexNo);
                users.Add(LoggedInUser);
                UserIndexNo = users.FindIndex(a => a.guid == LoggedInUser.guid);
                MessageBox.Show("Your password has been successfully changed!", "Password changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ForgotPassWdButton_Click(object sender, EventArgs e)
        {
            //forgot password button
        }

        private void CCVbox_Enter(object sender, EventArgs e)
        {
            CCVImage.Visible = true;
            PrevCCImageState = CCImage.Visible;
            CCImage.Visible = false;
        }

        private void CCVbox_Leave(object sender, EventArgs e)
        {
            CCVImage.Visible = false;
            CCImage.Visible = PrevCCImageState;
        }
        internal static bool CheckLuhn(string cardNo)
        {
            // Credit to https://www.geeksforgeeks.org/luhn-algorithm/ for
            // for this implementation of the Luhn algorithm.
            int nDigits = cardNo.Length;
            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {
                int d = cardNo[i] - '0';
                if (isSecond == true)
                    d *= 2;
                // We add two digits to handle 
                // cases that make two digits  
                // after doubling 
                nSum += d / 10;
                nSum += d % 10;
                isSecond = !isSecond;
            }
            return (nSum % 10 == 0);
        }
        private void Creditcardbox_Validated(object sender, EventArgs e)
        {
            if (CheckLuhn(Creditcardbox.Text))
            {
                CCErrorProvider.SetError(Creditcardbox, string.Empty);
                CCImage.Visible = true;
                if (Creditcardbox.Text == string.Empty)
                { CCImage.Visible = false; }
                else
                {
                    switch (Creditcardbox.Text.Substring(0, 1))
                    {
                        case "3":
                            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(@"Blackjack_CSC470.Images.american_express.gif"))
                            {
                                CCImage.Image = new Bitmap(Image.FromStream(stream), new Size(22, 22));
                            }
                            break;
                        case "4":
                            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(@"Blackjack_CSC470.Images.visa.gif"))
                            {
                                CCImage.Image = Image.FromStream(stream);
                            }
                            break;
                        case "5":
                            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(@"Blackjack_CSC470.Images.mastercard.gif"))
                            {
                                CCImage.Image = new Bitmap(Image.FromStream(stream), new Size(35, 22));
                            }
                            break;
                        case "6":
                            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(@"Blackjack_CSC470.Images.discover.jpg"))
                            {
                                CCImage.Image = new Bitmap(Image.FromStream(stream), new Size(35, 22));
                            }
                            break;
                        default:
                            CCImage.Visible = false;
                            break;
                    }
                    NewUserButton.Enabled = true;
                    EditUserDataButton.Enabled = true;
                }
            }
            else
            { 
                CCErrorProvider.SetError(Creditcardbox, "Invalid credit card number.");
                NewUserButton.Enabled = false;
                EditUserDataButton.Enabled = false;
                CCImage.Visible = false;
            }
        }

        private void UManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private void Edituserdata_Click(object sender, EventArgs e)
        {
        }

        private void Startamountbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Zipbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
