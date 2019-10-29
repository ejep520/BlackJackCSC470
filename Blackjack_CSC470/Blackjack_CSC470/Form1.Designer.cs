namespace Blackjack_CSC470
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Playercard1 = new System.Windows.Forms.PictureBox();
            this.Playercard2 = new System.Windows.Forms.PictureBox();
            this.Dealercard1 = new System.Windows.Forms.PictureBox();
            this.Dealercard2 = new System.Windows.Forms.PictureBox();
            this.HitButton = new System.Windows.Forms.Button();
            this.StandButton = new System.Windows.Forms.Button();
            this.Playercard3 = new System.Windows.Forms.PictureBox();
            this.Dealercard3 = new System.Windows.Forms.PictureBox();
            this.Playercard4 = new System.Windows.Forms.PictureBox();
            this.Dealercard4 = new System.Windows.Forms.PictureBox();
            this.Playercard5 = new System.Windows.Forms.PictureBox();
            this.Dealercard5 = new System.Windows.Forms.PictureBox();
            this.Playercard6 = new System.Windows.Forms.PictureBox();
            this.Dealercard6 = new System.Windows.Forms.PictureBox();
            this.Playercard7 = new System.Windows.Forms.PictureBox();
            this.Dealercard7 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.betvalues = new System.Windows.Forms.ListBox();
            this.Newgame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Playercard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Playercard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dealercard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dealercard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Playercard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dealercard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Playercard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dealercard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Playercard5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dealercard5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Playercard6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dealercard6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Playercard7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dealercard7)).BeginInit();
            this.SuspendLayout();
            // 
            // Playercard1
            // 
            this.Playercard1.AccessibleName = "Playercard1";
            this.Playercard1.Location = new System.Drawing.Point(355, 52);
            this.Playercard1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Playercard1.Name = "Playercard1";
            this.Playercard1.Size = new System.Drawing.Size(100, 127);
            this.Playercard1.TabIndex = 0;
            this.Playercard1.TabStop = false;
            this.Playercard1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Playercard2
            // 
            this.Playercard2.AccessibleName = "Playercard2";
            this.Playercard2.Location = new System.Drawing.Point(383, 79);
            this.Playercard2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Playercard2.Name = "Playercard2";
            this.Playercard2.Size = new System.Drawing.Size(100, 127);
            this.Playercard2.TabIndex = 1;
            this.Playercard2.TabStop = false;
            // 
            // Dealercard1
            // 
            this.Dealercard1.AccessibleName = "Dealercard1";
            this.Dealercard1.Location = new System.Drawing.Point(16, 52);
            this.Dealercard1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dealercard1.Name = "Dealercard1";
            this.Dealercard1.Size = new System.Drawing.Size(100, 127);
            this.Dealercard1.TabIndex = 2;
            this.Dealercard1.TabStop = false;
            // 
            // Dealercard2
            // 
            this.Dealercard2.AccessibleName = "Dealercard2";
            this.Dealercard2.Location = new System.Drawing.Point(37, 79);
            this.Dealercard2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dealercard2.Name = "Dealercard2";
            this.Dealercard2.Size = new System.Drawing.Size(100, 127);
            this.Dealercard2.TabIndex = 3;
            this.Dealercard2.TabStop = false;
            this.Dealercard2.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // HitButton
            // 
            this.HitButton.AccessibleName = "Hitbutton";
            this.HitButton.BackColor = System.Drawing.Color.ForestGreen;
            this.HitButton.Location = new System.Drawing.Point(653, 169);
            this.HitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HitButton.Name = "HitButton";
            this.HitButton.Size = new System.Drawing.Size(109, 37);
            this.HitButton.TabIndex = 4;
            this.HitButton.Text = "Hit";
            this.HitButton.UseVisualStyleBackColor = false;
            this.HitButton.Click += new System.EventHandler(this.hit_Click);
            // 
            // StandButton
            // 
            this.StandButton.AccessibleName = "Standbutton";
            this.StandButton.BackColor = System.Drawing.Color.ForestGreen;
            this.StandButton.Location = new System.Drawing.Point(653, 251);
            this.StandButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StandButton.Name = "StandButton";
            this.StandButton.Size = new System.Drawing.Size(109, 37);
            this.StandButton.TabIndex = 5;
            this.StandButton.Text = "Stand";
            this.StandButton.UseVisualStyleBackColor = false;
            this.StandButton.Click += new System.EventHandler(this.stand_Click);
            // 
            // Playercard3
            // 
            this.Playercard3.AccessibleName = "Playercard3";
            this.Playercard3.Location = new System.Drawing.Point(401, 101);
            this.Playercard3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Playercard3.Name = "Playercard3";
            this.Playercard3.Size = new System.Drawing.Size(100, 127);
            this.Playercard3.TabIndex = 6;
            this.Playercard3.TabStop = false;
            // 
            // Dealercard3
            // 
            this.Dealercard3.AccessibleName = "Dealercard3";
            this.Dealercard3.Location = new System.Drawing.Point(58, 101);
            this.Dealercard3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dealercard3.Name = "Dealercard3";
            this.Dealercard3.Size = new System.Drawing.Size(100, 127);
            this.Dealercard3.TabIndex = 7;
            this.Dealercard3.TabStop = false;
            // 
            // Playercard4
            // 
            this.Playercard4.AccessibleName = "Playercard2";
            this.Playercard4.Location = new System.Drawing.Point(422, 129);
            this.Playercard4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Playercard4.Name = "Playercard4";
            this.Playercard4.Size = new System.Drawing.Size(100, 127);
            this.Playercard4.TabIndex = 8;
            this.Playercard4.TabStop = false;
            // 
            // Dealercard4
            // 
            this.Dealercard4.AccessibleName = "Dealercard4";
            this.Dealercard4.Location = new System.Drawing.Point(75, 129);
            this.Dealercard4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dealercard4.Name = "Dealercard4";
            this.Dealercard4.Size = new System.Drawing.Size(100, 127);
            this.Dealercard4.TabIndex = 9;
            this.Dealercard4.TabStop = false;
            // 
            // Playercard5
            // 
            this.Playercard5.AccessibleName = "Playercard5";
            this.Playercard5.Location = new System.Drawing.Point(442, 151);
            this.Playercard5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Playercard5.Name = "Playercard5";
            this.Playercard5.Size = new System.Drawing.Size(100, 127);
            this.Playercard5.TabIndex = 10;
            this.Playercard5.TabStop = false;
            // 
            // Dealercard5
            // 
            this.Dealercard5.AccessibleName = "Dealercard5";
            this.Dealercard5.Location = new System.Drawing.Point(94, 151);
            this.Dealercard5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dealercard5.Name = "Dealercard5";
            this.Dealercard5.Size = new System.Drawing.Size(100, 127);
            this.Dealercard5.TabIndex = 11;
            this.Dealercard5.TabStop = false;
            // 
            // Playercard6
            // 
            this.Playercard6.AccessibleName = "Playercard6";
            this.Playercard6.Location = new System.Drawing.Point(461, 183);
            this.Playercard6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Playercard6.Name = "Playercard6";
            this.Playercard6.Size = new System.Drawing.Size(100, 127);
            this.Playercard6.TabIndex = 12;
            this.Playercard6.TabStop = false;
            this.Playercard6.Click += new System.EventHandler(this.pictureBox11_Click);
            // 
            // Dealercard6
            // 
            this.Dealercard6.AccessibleName = "Dealercard6";
            this.Dealercard6.Location = new System.Drawing.Point(111, 183);
            this.Dealercard6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dealercard6.Name = "Dealercard6";
            this.Dealercard6.Size = new System.Drawing.Size(100, 127);
            this.Dealercard6.TabIndex = 13;
            this.Dealercard6.TabStop = false;
            // 
            // Playercard7
            // 
            this.Playercard7.AccessibleName = "Playercard7";
            this.Playercard7.Location = new System.Drawing.Point(489, 203);
            this.Playercard7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Playercard7.Name = "Playercard7";
            this.Playercard7.Size = new System.Drawing.Size(100, 127);
            this.Playercard7.TabIndex = 14;
            this.Playercard7.TabStop = false;
            // 
            // Dealercard7
            // 
            this.Dealercard7.AccessibleName = "Dealercard7";
            this.Dealercard7.Location = new System.Drawing.Point(131, 203);
            this.Dealercard7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dealercard7.Name = "Dealercard7";
            this.Dealercard7.Size = new System.Drawing.Size(100, 127);
            this.Dealercard7.TabIndex = 15;
            this.Dealercard7.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.ForestGreen;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(355, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(51, 15);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "Player";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.ForestGreen;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(16, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(51, 15);
            this.textBox2.TabIndex = 17;
            this.textBox2.Text = "Dealer";
            // 
            // betvalues
            // 
            this.betvalues.BackColor = System.Drawing.SystemColors.Highlight;
            this.betvalues.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.betvalues.FormattingEnabled = true;
            this.betvalues.ItemHeight = 16;
            this.betvalues.Location = new System.Drawing.Point(653, 27);
            this.betvalues.Name = "betvalues";
            this.betvalues.Size = new System.Drawing.Size(109, 96);
            this.betvalues.TabIndex = 18;
            this.betvalues.SelectedIndexChanged += new System.EventHandler(this.betvalues_SelectedIndexChanged);
            // 
            // Newgame
            // 
            this.Newgame.BackColor = System.Drawing.Color.ForestGreen;
            this.Newgame.Location = new System.Drawing.Point(653, 401);
            this.Newgame.Name = "Newgame";
            this.Newgame.Size = new System.Drawing.Size(109, 37);
            this.Newgame.TabIndex = 19;
            this.Newgame.Text = "New Game";
            this.Newgame.UseVisualStyleBackColor = false;
            this.Newgame.Click += new System.EventHandler(this.Newgame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Newgame);
            this.Controls.Add(this.betvalues);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Dealercard7);
            this.Controls.Add(this.Playercard7);
            this.Controls.Add(this.Dealercard6);
            this.Controls.Add(this.Playercard6);
            this.Controls.Add(this.Dealercard5);
            this.Controls.Add(this.Playercard5);
            this.Controls.Add(this.Dealercard4);
            this.Controls.Add(this.Playercard4);
            this.Controls.Add(this.Dealercard3);
            this.Controls.Add(this.Playercard3);
            this.Controls.Add(this.StandButton);
            this.Controls.Add(this.HitButton);
            this.Controls.Add(this.Dealercard2);
            this.Controls.Add(this.Dealercard1);
            this.Controls.Add(this.Playercard2);
            this.Controls.Add(this.Playercard1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Playercard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Playercard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dealercard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dealercard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Playercard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dealercard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Playercard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dealercard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Playercard5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dealercard5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Playercard6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dealercard6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Playercard7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dealercard7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Playercard1;
        private System.Windows.Forms.PictureBox Playercard2;
        private System.Windows.Forms.PictureBox Dealercard1;
        private System.Windows.Forms.PictureBox Dealercard2;
        private System.Windows.Forms.Button HitButton;
        private System.Windows.Forms.Button StandButton;
        private System.Windows.Forms.PictureBox Playercard3;
        private System.Windows.Forms.PictureBox Dealercard3;
        private System.Windows.Forms.PictureBox Playercard4;
        private System.Windows.Forms.PictureBox Dealercard4;
        private System.Windows.Forms.PictureBox Playercard5;
        private System.Windows.Forms.PictureBox Dealercard5;
        private System.Windows.Forms.PictureBox Playercard6;
        private System.Windows.Forms.PictureBox Dealercard6;
        private System.Windows.Forms.PictureBox Playercard7;
        private System.Windows.Forms.PictureBox Dealercard7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox betvalues;
        private System.Windows.Forms.Button Newgame;
    }
}

