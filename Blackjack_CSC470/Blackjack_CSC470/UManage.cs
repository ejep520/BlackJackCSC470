using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack_CSC470
{
    public partial class UManage : Form
    {
        private bool PrevCCImageState;
        public UManage()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            CCVImage.Visible = false;
            CCImage.Visible = false;
            CenterToScreen();
            Enabled = true;
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            //log in button
            /*
            * relative text box names
            * Username text box: Usernamebox
            * Password text box: Passwordbox
            * Start amount text box: Startamountbox
            */
            //get username
            string loginname = Usernamebox.Text;
            //get password
            string loginpassword = Passwordbox.Text;
            //get starting amount
            int startingamount = Int32.Parse(Startamountbox.Text);
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
            bool isValid = true;
            string Username = Createusernamebox.Text;
            string Password = string.Empty;
            string Firstname = string.Empty;
            string Lastname = Lastnamebox.Text;
            string Address = Address1box.Text;
            string Address2 = Address2box.Text;
            string City = Citybox.Text;
            string State = Statebox.Text;
            int zipcode = int.Parse(Zipbox.Text);
            string phonenumber = Phonenumberbox.Text;
            string Creditcard = Creditcardbox.Text;
            string CCV = CCVbox.Text;
            string expdate = Expdatebox.Text;
            string Securityquestion = Questionbox.Text;
            string Securityquestionanswer = Questionanswerbox.Text;

            if (isValid)
            {
                User User1 = new User(Firstname, Lastname, Address, Address2, City, State,
                                        zipcode, Password, Creditcard, CCV, expdate,
                                        Securityquestion, Securityquestionanswer);
                //write to user data file 
            }
        }
        private void ChangePassWdButton_Click(object sender, EventArgs e)
        {
            //change password button
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
                }
            }
            else
            { 
                CCErrorProvider.SetError(Creditcardbox, "Invalid credit card number.");
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
    }
}
