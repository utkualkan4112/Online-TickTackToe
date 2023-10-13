namespace TickTackToeClient
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
            this.BtnConnect = new System.Windows.Forms.Button();
            this.TxtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.log = new System.Windows.Forms.RichTextBox();
            this.box1 = new System.Windows.Forms.Button();
            this.box2 = new System.Windows.Forms.Button();
            this.box3 = new System.Windows.Forms.Button();
            this.box4 = new System.Windows.Forms.Button();
            this.box5 = new System.Windows.Forms.Button();
            this.box6 = new System.Windows.Forms.Button();
            this.box7 = new System.Windows.Forms.Button();
            this.box8 = new System.Windows.Forms.Button();
            this.box9 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.namebox = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(109, 75);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(76, 36);
            this.BtnConnect.TabIndex = 0;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // TxtIP
            // 
            this.TxtIP.Location = new System.Drawing.Point(47, 40);
            this.TxtIP.Name = "TxtIP";
            this.TxtIP.Size = new System.Drawing.Size(129, 20);
            this.TxtIP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port: ";
            // 
            // TxtPort
            // 
            this.TxtPort.Location = new System.Drawing.Point(48, 84);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(55, 20);
            this.TxtPort.TabIndex = 4;
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(12, 134);
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(173, 236);
            this.log.TabIndex = 5;
            this.log.Text = "";
            // 
            // box1
            // 
            this.box1.Enabled = false;
            this.box1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box1.Location = new System.Drawing.Point(242, 75);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(75, 75);
            this.box1.TabIndex = 6;
            this.box1.UseVisualStyleBackColor = true;
            this.box1.Click += new System.EventHandler(this.box1_Click);
            // 
            // box2
            // 
            this.box2.Enabled = false;
            this.box2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box2.Location = new System.Drawing.Point(323, 75);
            this.box2.Name = "box2";
            this.box2.Size = new System.Drawing.Size(75, 75);
            this.box2.TabIndex = 7;
            this.box2.UseVisualStyleBackColor = true;
            this.box2.Click += new System.EventHandler(this.box2_Click);
            // 
            // box3
            // 
            this.box3.Enabled = false;
            this.box3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box3.Location = new System.Drawing.Point(404, 75);
            this.box3.Name = "box3";
            this.box3.Size = new System.Drawing.Size(75, 75);
            this.box3.TabIndex = 8;
            this.box3.UseVisualStyleBackColor = true;
            this.box3.Click += new System.EventHandler(this.box3_Click);
            // 
            // box4
            // 
            this.box4.Enabled = false;
            this.box4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box4.Location = new System.Drawing.Point(242, 156);
            this.box4.Name = "box4";
            this.box4.Size = new System.Drawing.Size(75, 75);
            this.box4.TabIndex = 9;
            this.box4.UseVisualStyleBackColor = true;
            this.box4.Click += new System.EventHandler(this.box4_Click);
            // 
            // box5
            // 
            this.box5.Enabled = false;
            this.box5.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box5.Location = new System.Drawing.Point(323, 156);
            this.box5.Name = "box5";
            this.box5.Size = new System.Drawing.Size(75, 75);
            this.box5.TabIndex = 10;
            this.box5.UseVisualStyleBackColor = true;
            this.box5.Click += new System.EventHandler(this.box5_Click);
            // 
            // box6
            // 
            this.box6.Enabled = false;
            this.box6.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box6.Location = new System.Drawing.Point(404, 156);
            this.box6.Name = "box6";
            this.box6.Size = new System.Drawing.Size(75, 75);
            this.box6.TabIndex = 11;
            this.box6.UseVisualStyleBackColor = true;
            this.box6.Click += new System.EventHandler(this.box6_Click);
            // 
            // box7
            // 
            this.box7.Enabled = false;
            this.box7.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box7.Location = new System.Drawing.Point(242, 237);
            this.box7.Name = "box7";
            this.box7.Size = new System.Drawing.Size(75, 75);
            this.box7.TabIndex = 12;
            this.box7.UseVisualStyleBackColor = true;
            this.box7.Click += new System.EventHandler(this.box7_Click);
            // 
            // box8
            // 
            this.box8.Enabled = false;
            this.box8.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box8.Location = new System.Drawing.Point(323, 237);
            this.box8.Name = "box8";
            this.box8.Size = new System.Drawing.Size(75, 75);
            this.box8.TabIndex = 13;
            this.box8.UseVisualStyleBackColor = true;
            this.box8.Click += new System.EventHandler(this.box8_Click);
            // 
            // box9
            // 
            this.box9.Enabled = false;
            this.box9.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.box9.Location = new System.Drawing.Point(404, 237);
            this.box9.Name = "box9";
            this.box9.Size = new System.Drawing.Size(75, 75);
            this.box9.TabIndex = 14;
            this.box9.UseVisualStyleBackColor = true;
            this.box9.Click += new System.EventHandler(this.box9_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(242, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Join";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Name:";
            // 
            // namebox
            // 
            this.namebox.Location = new System.Drawing.Point(48, 9);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(100, 20);
            this.namebox.TabIndex = 17;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(363, 30);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(116, 23);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "Re-match";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 382);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.namebox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.box9);
            this.Controls.Add(this.box8);
            this.Controls.Add(this.box7);
            this.Controls.Add(this.box6);
            this.Controls.Add(this.box5);
            this.Controls.Add(this.box4);
            this.Controls.Add(this.box3);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.box1);
            this.Controls.Add(this.log);
            this.Controls.Add(this.TxtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtIP);
            this.Controls.Add(this.BtnConnect);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Tick Tack Toe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.TextBox TxtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.RichTextBox log;
        private System.Windows.Forms.Button box1;
        private System.Windows.Forms.Button box2;
        private System.Windows.Forms.Button box3;
        private System.Windows.Forms.Button box4;
        private System.Windows.Forms.Button box5;
        private System.Windows.Forms.Button box6;
        private System.Windows.Forms.Button box7;
        private System.Windows.Forms.Button box8;
        private System.Windows.Forms.Button box9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.Button btnRefresh;
    }
}

