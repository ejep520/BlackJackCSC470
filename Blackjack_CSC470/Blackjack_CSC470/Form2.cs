using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack_CSC470
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }


        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
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
            //get username from Createusernamebox
            string Username = Createusernamebox.Text;
            // password from Createpasswordbox
            string Password = Createpasswordbox.Text;
            //get First name from Firstnamebox
            string Firstname = Firstnamebox.Text;
            //get Last name from Lastnamebox
            string Lastname = Lastnamebox.Text;
            //get address from Addressbox
            string Address = Address1box.Text;
            //city
            string City = Citybox.Text;
            //state
            string State = Statebox.Text;
            //zip
            int zipcode = Int32.Parse(Zipbox.Text);
            //parse phone # from Phonenumberbox
            string phonenumber = Phonenumberbox.Text;
            //get creditcard from Creditcardbox
            string Creditcard = Creditcardbox.Text;
            //ccv
            int CCV = Int32.Parse(CCVbox.Text);
            //expdate
            string expdate = Expdatebox.Text;
            //get security question from Questionbox
            string Securityquestion = Questionbox.Text;
            //get security answer from Questionanswerbox
            string Securityquestionanswer = Questionanswerbox.Text;

            User User1 = new User(Firstname, Lastname, Address, , City, State, 
                                    Zipcode, Password, Creditcard, CCV, ExpDate,
                                    Securityquestion, Securityquestionanswer); 
        }




        private void button3_Click(object sender, EventArgs e)
        {
            //change password button
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //forgot password button
        }
    }
}
