namespace TikTakToServer
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
            this.TxtPrt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnLst = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.box1 = new System.Windows.Forms.Button();
            this.box2 = new System.Windows.Forms.Button();
            this.box3 = new System.Windows.Forms.Button();
            this.box4 = new System.Windows.Forms.Button();
            this.box5 = new System.Windows.Forms.Button();
            this.box6 = new System.Windows.Forms.Button();
            this.box7 = new System.Windows.Forms.Button();
            this.box8 = new System.Windows.Forms.Button();
            this.box9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtPrt
            // 
            this.TxtPrt.Location = new System.Drawing.Point(72, 54);
            this.TxtPrt.Name = "TxtPrt";
            this.TxtPrt.Size = new System.Drawing.Size(114, 20);
            this.TxtPrt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port: ";
            // 
            // BtnLst
            // 
            this.BtnLst.Location = new System.Drawing.Point(192, 54);
            this.BtnLst.Name = "BtnLst";
            this.BtnLst.Size = new System.Drawing.Size(75, 23);
            this.BtnLst.TabIndex = 2;
            this.BtnLst.Text = "listen";
            this.BtnLst.UseVisualStyleBackColor = true;
            this.BtnLst.Click += new System.EventHandler(this.BtnLst_Click_1);
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(41, 113);
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(383, 349);
            this.log.TabIndex = 3;
            this.log.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Logs:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Current Game:";
            // 
            // box1
            // 
            this.box1.Enabled = false;
            this.box1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box1.Location = new System.Drawing.Point(497, 113);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(75, 75);
            this.box1.TabIndex = 6;
            this.box1.UseVisualStyleBackColor = true;
            // 
            // box2
            // 
            this.box2.Enabled = false;
            this.box2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box2.Location = new System.Drawing.Point(578, 113);
            this.box2.Name = "box2";
            this.box2.Size = new System.Drawing.Size(75, 75);
            this.box2.TabIndex = 7;
            this.box2.UseVisualStyleBackColor = true;
            // 
            // box3
            // 
            this.box3.Enabled = false;
            this.box3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box3.Location = new System.Drawing.Point(659, 113);
            this.box3.Name = "box3";
            this.box3.Size = new System.Drawing.Size(75, 75);
            this.box3.TabIndex = 8;
            this.box3.UseVisualStyleBackColor = true;
            // 
            // box4
            // 
            this.box4.Enabled = false;
            this.box4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box4.Location = new System.Drawing.Point(497, 194);
            this.box4.Name = "box4";
            this.box4.Size = new System.Drawing.Size(75, 75);
            this.box4.TabIndex = 9;
            this.box4.UseVisualStyleBackColor = true;
            // 
            // box5
            // 
            this.box5.Enabled = false;
            this.box5.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box5.Location = new System.Drawing.Point(578, 194);
            this.box5.Name = "box5";
            this.box5.Size = new System.Drawing.Size(75, 75);
            this.box5.TabIndex = 10;
            this.box5.UseVisualStyleBackColor = true;
            // 
            // box6
            // 
            this.box6.Enabled = false;
            this.box6.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box6.Location = new System.Drawing.Point(659, 194);
            this.box6.Name = "box6";
            this.box6.Size = new System.Drawing.Size(75, 75);
            this.box6.TabIndex = 11;
            this.box6.UseVisualStyleBackColor = true;
            // 
            // box7
            // 
            this.box7.Enabled = false;
            this.box7.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box7.Location = new System.Drawing.Point(497, 275);
            this.box7.Name = "box7";
            this.box7.Size = new System.Drawing.Size(75, 75);
            this.box7.TabIndex = 12;
            this.box7.UseVisualStyleBackColor = true;
            // 
            // box8
            // 
            this.box8.Enabled = false;
            this.box8.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box8.Location = new System.Drawing.Point(578, 275);
            this.box8.Name = "box8";
            this.box8.Size = new System.Drawing.Size(75, 75);
            this.box8.TabIndex = 13;
            this.box8.UseVisualStyleBackColor = true;
            // 
            // box9
            // 
            this.box9.Enabled = false;
            this.box9.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box9.Location = new System.Drawing.Point(659, 275);
            this.box9.Name = "box9";
            this.box9.Size = new System.Drawing.Size(75, 75);
            this.box9.TabIndex = 14;
            this.box9.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 481);
            this.Controls.Add(this.box9);
            this.Controls.Add(this.box8);
            this.Controls.Add(this.box7);
            this.Controls.Add(this.box6);
            this.Controls.Add(this.box5);
            this.Controls.Add(this.box4);
            this.Controls.Add(this.box3);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.box1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.log);
            this.Controls.Add(this.BtnLst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtPrt);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtPrt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnLst;
        private System.Windows.Forms.RichTextBox log;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button box1;
        private System.Windows.Forms.Button box2;
        private System.Windows.Forms.Button box3;
        private System.Windows.Forms.Button box4;
        private System.Windows.Forms.Button box5;
        private System.Windows.Forms.Button box6;
        private System.Windows.Forms.Button box7;
        private System.Windows.Forms.Button box8;
        private System.Windows.Forms.Button box9;
    }
}

