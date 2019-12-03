using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
        private const string InvalPass = "Invalid password!";
        private const string NoSuchUsr = "There is no such user!";
        private const string UsrExists = "That user already exists!";
        private const string EditUser = "&Edit User Data";
        private const string SaveUser = "Save User";
        private const string CreateUser = "&Create New User";
        private const string Cancel = "Cancel";
        private const string UsrEmpty = "Please enter a user name!";
        private const string FourStars = "****";
        public UManage(Guid currentUser, List<User> GetUsers)
        {
            InitializeComponent();
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = culture.TextInfo;
            List<string> stateList = new List<string>();
            users = GetUsers;
            CCErrorProvider.Clear();
            UserLoginErrorProv.Clear();
            UserMaintErrorProv.Clear();
            if (currentUser != Guid.Empty)
            {
                UserIndexNo = users.FindIndex(a => a.guid == currentUser);
                LoggedInUser = users[UserIndexNo];
            }
            stateList.Add(string.Empty);
            stateList.AddRange(Enum.GetNames(typeof(User.StateEnum)));
            for (int counter = 0; counter < stateList.Count(); counter++)
            { stateList[counter] = textInfo.ToTitleCase(stateList[counter].Replace("_", " ")); }
            StateBox.Items.AddRange(stateList.ToArray());
            StateBox.SelectedIndex = 0;
        }
        private void UManage_Load(object sender, EventArgs e)
        {
            CCVImage.Visible = false;
            CCImage.Visible = false;
            CenterToScreen();
            Enabled = true;
            if (LoggedInUser != null)
            {
                UNameEnterbox.Text = LoggedInUser.UName;
                EditUserDataButton.Visible = true;
                EditUserDataButton.Enabled = true;
            }
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            //log in button
            /*
            * relative text box names
            * Username text box: UNameEnterBox
            * Password text box: Passwordbox
            * Start amount text box: StartAmountBox
            */
            //get starting amount
            if (users.Where(a => a.UName == UNameEnterbox.Text).Any())
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
                                UserMaintErrorProv.SetError(Passwordbox, InvalPass);
                            break;
                        }
                    default:
                        { throw new Exception("We found two (or more) users with the same user name!"); }
                }
            }
        }
        private void NewUserButton_Click(object sender, EventArgs e)
        {
            if (NewUserButton.Text == CreateUser)
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
                string NewUsrName = CreateUserNameBox.Text;
                string NewFName = Firstnamebox.Text;
                string NewLName = Lastnamebox.Text;
                string NewAddr0 = Address1box.Text;
                string NewAddr1 = Address2box.Text;
                string NewCity = Citybox.Text;
                string NewState = StateBox.SelectedItem.ToString();
                int NewZip = int.Parse(Zipbox.Text);
                long NewPhone = long.Parse(Phonenumberbox.Text);
                byte[] NewPass = sHA.ComputeHash(ue.GetBytes(CreatePasswordBox.Text));
                byte[] NewCCd = sHA.ComputeHash(ue.GetBytes(Creditcardbox.Text));
                byte[] NewCCV = sHA.ComputeHash(ue.GetBytes(CCVbox.Text));
                byte[] NewExpr = sHA.ComputeHash(ue.GetBytes(Expdatebox.Text));
                string NewQuest = Questionbox.Text;
                byte[] NewAnswr = sHA.ComputeHash(ue.GetBytes(Questionanswerbox.Text));
                int NewFour = Creditcardbox.Text.Length < 4 ? int.Parse(Creditcardbox.Text) : int.Parse(Creditcardbox.Text.Substring(Creditcardbox.Text.Length - 4)); 
                User User1 = new User(NewUsrName, NewFName, NewLName, NewAddr0,
                                      NewAddr1, NewCity, NewState, NewZip,
                                      NewPhone, NewPass, NewCCd, NewCCV, NewExpr,
                                      NewQuest, NewAnswr, NewFour);
                if (!users.Where(a => a.UName == User1.UName).Any())
                {
                    users.Add(User1);
                    MessageBox.Show(string.Format("User {0} has been created!", User1.UName), "User created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UNameEnterbox.Text = CreateUserNameBox.Text;
                    CreateUserNameBox.Text = string.Empty;
                    Firstnamebox.Text = string.Empty;
                    Lastnamebox.Text = string.Empty;
                    Address1box.Text = string.Empty;
                    Address2box.Text = string.Empty;
                    Citybox.Text = string.Empty;
                    StateBox.Text = string.Empty;
                    Zipbox.Text = string.Empty;
                    CreatePasswordBox.Text = string.Empty;
                    Creditcardbox.Text = string.Empty;
                    CCImage.Visible = false;
                    CCImage.Image = null;
                    CCVbox.Text = string.Empty;
                    Expdatebox.Text = string.Empty;
                    Questionbox.Text = string.Empty;
                    Questionanswerbox.Text = string.Empty;
                    _ = UNameEnterbox.Focus();
                }
                else
                    UserMaintErrorProv.SetError(CreateUserNameBox, UsrExists);
            }
            else if (NewUserButton.Text == SaveUser)
            {
                LoggedInUser.UName = CreateUserNameBox.Text;
                CreatePasswordBox.Enabled = true;
                LoggedInUser.FName = Firstnamebox.Text;
                LoggedInUser.LName = Lastnamebox.Text;
                LoggedInUser.AddrZero = Address1box.Text;
                LoggedInUser.AddrOne = Address2box.Text;
                LoggedInUser.City = Citybox.Text;
                LoggedInUser.State = StateBox.Text;
                LoggedInUser.ZipCode = Zipbox.Text;
                LoggedInUser.PhoneNo = long.Parse(Phonenumberbox.Text);
                if (long.TryParse(Creditcardbox.Text, out _))
                {
                    LoggedInUser.NewCC(
                        sHA.ComputeHash(ue.GetBytes(Creditcardbox.Text)),
                        int.Parse(Creditcardbox.Text.Length > 3 ?
                        Creditcardbox.Text.Substring(Creditcardbox.Text.Length - 4) :
                        Creditcardbox.Text),
                        sHA.ComputeHash(ue.GetBytes(CCVbox.Text)),
                        sHA.ComputeHash(ue.GetBytes(Expdatebox.Text)));
                }
                if ((Questionbox.Text != LoggedInUser.SecretQ) && (Questionanswerbox.Text != FourStars))
                {
                    LoggedInUser.NewSecQ(
                        Questionbox.Text,
                        sHA.ComputeHash(ue.GetBytes(Questionanswerbox.Text)));
                }
                NewUserButton.Text = CreateUser;
                EditUserDataButton.Text = EditUser;
                if (!users.Remove(users.Where(a => a.guid == LoggedInUser.guid).Single()))
                    throw new Exception("Unable to remove the logged in user for updating.");
                users.Add(LoggedInUser);
                MessageBox.Show("This user's information has been updated!", "User updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UNameEnterbox.Text = CreateUserNameBox.Text;
                CreateUserNameBox.Text = string.Empty;
                CreatePasswordBox.Text = string.Empty;
                Firstnamebox.Text = string.Empty;
                Lastnamebox.Text = string.Empty;
                Address1box.Text = string.Empty;
                Address2box.Text = string.Empty;
                Citybox.Text = string.Empty;
                StateBox.SelectedIndex = 0;
                Zipbox.Text = string.Empty;
                Phonenumberbox.Text = string.Empty;
                Creditcardbox.Text = string.Empty;
                CCVbox.Text = string.Empty;
                Expdatebox.Text = string.Empty;
                Questionbox.Text = string.Empty;
                Questionanswerbox.Text = string.Empty;
            }
        }
        private void ChangePassWdButton_Click(object sender, EventArgs e)
        {
            UserMaintErrorProv.Clear();
            CCErrorProvider.Clear();
            if (string.IsNullOrEmpty(Passwordbox.Text))
            { UserMaintErrorProv.SetError(Passwordbox, "You must first enter your old password."); }
            else if (!LoggedInUser.PassWdMatch(sHA.ComputeHash(ue.GetBytes(Passwordbox.Text))))
            { UserMaintErrorProv.SetError(Passwordbox, InvalPass); }
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
            if (string.IsNullOrEmpty(UNameEnterbox.Text))
            {
                UserMaintErrorProv.SetError(UNameEnterbox, "You must enter your username.");
                return;
            }
            string Username = UNameEnterbox.Text;
            //Get user's security question and put it in the security question box
            if (!users.Where(a => a.UName == Username).Any())
            {
                UserMaintErrorProv.SetError(UNameEnterbox, "You must enter a valid username.");
                return;
            }
            User MaybeUser = users.Where(a => a.UName == Username).Single();
            Questionbox.Text = MaybeUser.SecretQ;
            //require input into question answer box
            if (string.IsNullOrEmpty(Questionanswerbox.Text))
            {
                UserMaintErrorProv.SetError(Questionanswerbox, "You must enter an answer.");
                return;
            }
            string Answer = Questionanswerbox.Text;
            if (!LoggedInUser.SecretAnsMatch(sHA.ComputeHash(ue.GetBytes(Answer))))
            {
                UserMaintErrorProv.SetError(Questionanswerbox, "Incorrect answer.");
                return;
            }
            //check answer against stored data
            //take in password from data edit field
            if (string.IsNullOrEmpty(CreatePasswordBox.Text))
            {
                UserMaintErrorProv.SetError(CreatePasswordBox, "You must enter a new password.");
                return;
            }
            string NewPasswd = CreatePasswordBox.Text;
            //set new password
            LoggedInUser.ChangePass(sHA.ComputeHash(ue.GetBytes(Answer)), sHA.ComputeHash(ue.GetBytes(NewPasswd)));
            users.RemoveAt(UserIndexNo);
            users.Add(LoggedInUser);
            UserIndexNo = users.FindIndex(a => a.guid == LoggedInUser.guid);
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
            // Credit to https://www.geeksforgeeks.org/luhn-algorithm/
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
            sHA.Dispose();
            Dispose();
        }
        private void Edituserdata_Click(object sender, EventArgs e)
        {
            if (EditUserDataButton.Text == EditUser)
            {
                if (string.IsNullOrEmpty(UNameEnterbox.Text))
                    UserMaintErrorProv.SetError(UNameEnterbox, UsrEmpty);
                else if (LoggedInUser.UName != UNameEnterbox.Text)
                    UserMaintErrorProv.SetError(UNameEnterbox, NoSuchUsr);
                else if (!LoggedInUser.PassWdMatch(sHA.ComputeHash(ue.GetBytes(Passwordbox.Text))))
                    UserMaintErrorProv.SetError(UNameEnterbox, InvalPass);
                else if (string.IsNullOrEmpty(CreateUserNameBox.Text)
                         && string.IsNullOrEmpty(Firstnamebox.Text)
                         && string.IsNullOrEmpty(Lastnamebox.Text)
                         && string.IsNullOrEmpty(Address1box.Text)
                         && string.IsNullOrEmpty(Address2box.Text)
                         && string.IsNullOrEmpty(Citybox.Text)
                         && string.IsNullOrEmpty(StateBox.Text)
                         && string.IsNullOrEmpty(Zipbox.Text)
                         && string.IsNullOrEmpty(Phonenumberbox.Text)
                         && string.IsNullOrEmpty(Creditcardbox.Text)
                         && string.IsNullOrEmpty(CCVbox.Text)
                         && string.IsNullOrEmpty(Expdatebox.Text)
                         && string.IsNullOrEmpty(Questionbox.Text)
                         && string.IsNullOrEmpty(Questionanswerbox.Text))
                {
                    CreateUserNameBox.Text = LoggedInUser.UName;
                    CreatePasswordBox.Enabled = false;
                    Firstnamebox.Text = LoggedInUser.FName;
                    Lastnamebox.Text = LoggedInUser.LName;
                    Address1box.Text = LoggedInUser.AddrZero;
                    Address2box.Text = LoggedInUser.AddrOne;
                    Citybox.Text = LoggedInUser.City;
                    StateBox.Text = LoggedInUser.State;
                    Zipbox.Text = LoggedInUser.ZipCode;
                    Phonenumberbox.Text = LoggedInUser.PhoneNo.ToString();
                    Creditcardbox.Text = string.Concat(FourStars, LoggedInUser.LastFour.ToString("0000"));
                    CCVbox.Text = FourStars;
                    Expdatebox.Text = "0000";
                    Questionbox.Text = LoggedInUser.SecretQ;
                    Questionanswerbox.Text = FourStars;
                    NewUserButton.Text = SaveUser;
                    EditUserDataButton.Text = Cancel;
                }
            }
            else if (EditUserDataButton.Text == Cancel)
            {
                UNameEnterbox.Text = CreateUserNameBox.Text;
                CreateUserNameBox.Text = string.Empty;
                CreatePasswordBox.Text = string.Empty;
                Firstnamebox.Text = string.Empty;
                Lastnamebox.Text = string.Empty;
                Address1box.Text = string.Empty;
                Address2box.Text = string.Empty;
                Citybox.Text = string.Empty;
                StateBox.SelectedIndex = 0;
                Zipbox.Text = string.Empty;
                Phonenumberbox.Text = string.Empty;
                Creditcardbox.Text = string.Empty;
                CCVbox.Text = string.Empty;
                Expdatebox.Text = string.Empty;
                Questionbox.Text = string.Empty;
                Questionanswerbox.Text = string.Empty;
                NewUserButton.Text = CreateUser;
                EditUserDataButton.Text = EditUser;
            }
        }
        private void Zipbox_Validated(object sender, EventArgs e)
        {
            int MaybeZip;
            if (!int.TryParse(Zipbox.Text, out MaybeZip) || (MaybeZip < 10000) || (MaybeZip > 999999999))
            {
                UserMaintErrorProv.SetError(Zipbox, "The zip is not valid.");
                NewUserButton.Enabled = false;
                return;
            }
            UserMaintErrorProv.Clear();
        }
    }
}
