namespace Puzlle_Solver
{
    partial class sudokuSolver
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
            this.button1 = new System.Windows.Forms.Button();
            this.ldEasy = new System.Windows.Forms.Button();
            this.ldMedium = new System.Windows.Forms.Button();
            this.ldHard = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TakeNextStep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button1.Location = new System.Drawing.Point(536, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 84);
            this.button1.TabIndex = 0;
            this.button1.Text = "Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ldEasy
            // 
            this.ldEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ldEasy.Location = new System.Drawing.Point(536, 17);
            this.ldEasy.Name = "ldEasy";
            this.ldEasy.Size = new System.Drawing.Size(107, 84);
            this.ldEasy.TabIndex = 1;
            this.ldEasy.Text = "Load Easy";
            this.ldEasy.UseVisualStyleBackColor = true;
            this.ldEasy.Click += new System.EventHandler(this.ldEasy_Click);
            // 
            // ldMedium
            // 
            this.ldMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ldMedium.Location = new System.Drawing.Point(536, 107);
            this.ldMedium.Name = "ldMedium";
            this.ldMedium.Size = new System.Drawing.Size(107, 82);
            this.ldMedium.TabIndex = 2;
            this.ldMedium.Text = "Load Medium";
            this.ldMedium.UseVisualStyleBackColor = true;
            this.ldMedium.Click += new System.EventHandler(this.ldMedium_Click);
            // 
            // ldHard
            // 
            this.ldHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ldHard.Location = new System.Drawing.Point(536, 195);
            this.ldHard.Name = "ldHard";
            this.ldHard.Size = new System.Drawing.Size(107, 81);
            this.ldHard.TabIndex = 3;
            this.ldHard.Text = "Load Hard";
            this.ldHard.UseVisualStyleBackColor = true;
            this.ldHard.Click += new System.EventHandler(this.ldHard_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(15, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 492);
            this.panel1.TabIndex = 4;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.richTextBox1.Location = new System.Drawing.Point(649, 18);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(273, 486);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // TakeNextStep
            // 
            this.TakeNextStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.TakeNextStep.Location = new System.Drawing.Point(536, 330);
            this.TakeNextStep.Name = "TakeNextStep";
            this.TakeNextStep.Size = new System.Drawing.Size(107, 84);
            this.TakeNextStep.TabIndex = 11;
            this.TakeNextStep.Text = "Solve Next Step";
            this.TakeNextStep.UseVisualStyleBackColor = true;
            this.TakeNextStep.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(473, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "       A                 B                C                D                E    " +
    "           F                G                 H               I";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(0, 465);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "9";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 414);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "8";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "7";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(928, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 255);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(928, 267);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(303, 237);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.richTextBox2.Location = new System.Drawing.Point(1237, 17);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(238, 487);
            this.richTextBox2.TabIndex = 42;
            this.richTextBox2.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(649, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Annotations";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(928, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Diagrams";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1237, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 45;
            this.label13.Text = "Explanations";
            // 
            // sudokuSolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 514);
            this.Controls.Add(this.ldEasy);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ldMedium);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.TakeNextStep);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ldHard);
            this.Name = "sudokuSolver";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ldEasy;
        private System.Windows.Forms.Button ldMedium;
        private System.Windows.Forms.Button ldHard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button TakeNextStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}