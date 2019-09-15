namespace WindowsFormsApplication3
{
    partial class RGB_Change
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
            this.Blue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Green = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Red = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Blue
            // 
            this.Blue.Location = new System.Drawing.Point(79, 104);
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(100, 20);
            this.Blue.TabIndex = 26;
            this.Blue.Text = "textBox3";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(23, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Blue";
            // 
            // Green
            // 
            this.Green.Location = new System.Drawing.Point(79, 72);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(100, 20);
            this.Green.TabIndex = 24;
            this.Green.Text = "textBox2";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Green";
            // 
            // Red
            // 
            this.Red.Location = new System.Drawing.Point(79, 40);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(100, 20);
            this.Red.TabIndex = 22;
            this.Red.Text = "textBox1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(23, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Red";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Enter values between 0 and 255";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(64, 152);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 19;
            this.OK.Text = "OK";
            // 
            // RGB_Change
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 187);
            this.Controls.Add(this.Blue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Green);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Red);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OK);
            this.Name = "RGB_Change";
            this.Text = "RGB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Blue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Green;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Red;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OK;
    }
}