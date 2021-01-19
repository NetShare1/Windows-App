namespace NetShare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.butConnect = new MetroSuite.MetroButton();
            this.red_background_rectangle = new System.Windows.Forms.PictureBox();
            this.lock_open = new System.Windows.Forms.PictureBox();
            this.butMenu = new MetroSuite.MetroButton();
            this.butStats = new MetroSuite.MetroButton();
            this.butStatus = new MetroSuite.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.red_background_rectangle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lock_open)).BeginInit();
            this.SuspendLayout();
            // 
            // butConnect
            // 
            this.butConnect.AutoStyle = false;
            this.butConnect.BackColor = System.Drawing.Color.Transparent;
            this.butConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butConnect.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.butConnect.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.butConnect.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(160)))), ((int)(((byte)(71)))));
            this.butConnect.DisabledColor = System.Drawing.Color.Gray;
            this.butConnect.DrawBorder = false;
            this.butConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butConnect.ForeColor = System.Drawing.Color.White;
            this.butConnect.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.butConnect.IsRound = true;
            this.butConnect.Location = new System.Drawing.Point(38, 312);
            this.butConnect.Margin = new System.Windows.Forms.Padding(0);
            this.butConnect.Name = "butConnect";
            this.butConnect.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.butConnect.RoundingArc = 32;
            this.butConnect.Size = new System.Drawing.Size(200, 32);
            this.butConnect.Style = MetroSuite.Design.Style.Custom;
            this.butConnect.TabIndex = 1;
            this.butConnect.Text = "Connect";
            this.butConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // red_background_rectangle
            // 
            this.red_background_rectangle.Image = ((System.Drawing.Image)(resources.GetObject("red_background_rectangle.Image")));
            this.red_background_rectangle.Location = new System.Drawing.Point(0, 0);
            this.red_background_rectangle.Margin = new System.Windows.Forms.Padding(2);
            this.red_background_rectangle.Name = "red_background_rectangle";
            this.red_background_rectangle.Size = new System.Drawing.Size(276, 295);
            this.red_background_rectangle.TabIndex = 2;
            this.red_background_rectangle.TabStop = false;
            // 
            // lock_open
            // 
            this.lock_open.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.lock_open.Image = ((System.Drawing.Image)(resources.GetObject("lock_open.Image")));
            this.lock_open.Location = new System.Drawing.Point(88, 71);
            this.lock_open.Margin = new System.Windows.Forms.Padding(2);
            this.lock_open.Name = "lock_open";
            this.lock_open.Size = new System.Drawing.Size(100, 97);
            this.lock_open.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lock_open.TabIndex = 3;
            this.lock_open.TabStop = false;
            // 
            // butMenu
            // 
            this.butMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butMenu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butMenu.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butMenu.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butMenu.DrawBorder = false;
            this.butMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.butMenu.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butMenu.Icon = ((System.Drawing.Image)(resources.GetObject("butMenu.Icon")));
            this.butMenu.Location = new System.Drawing.Point(8, 8);
            this.butMenu.Margin = new System.Windows.Forms.Padding(2);
            this.butMenu.Name = "butMenu";
            this.butMenu.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butMenu.RoundingArc = 19;
            this.butMenu.Size = new System.Drawing.Size(20, 19);
            this.butMenu.TabIndex = 4;
            // 
            // butStats
            // 
            this.butStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butStats.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butStats.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butStats.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butStats.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butStats.DrawBorder = false;
            this.butStats.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.butStats.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butStats.Icon = ((System.Drawing.Image)(resources.GetObject("butStats.Icon")));
            this.butStats.Location = new System.Drawing.Point(244, 8);
            this.butStats.Margin = new System.Windows.Forms.Padding(2);
            this.butStats.Name = "butStats";
            this.butStats.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butStats.RoundingArc = 19;
            this.butStats.Size = new System.Drawing.Size(24, 19);
            this.butStats.TabIndex = 5;
            // 
            // butStatus
            // 
            this.butStatus.AutoStyle = false;
            this.butStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butStatus.BorderColor = System.Drawing.Color.White;
            this.butStatus.DefaultColor = System.Drawing.Color.White;
            this.butStatus.DisabledColor = System.Drawing.Color.White;
            this.butStatus.DrawBorder = false;
            this.butStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butStatus.ForeColor = System.Drawing.Color.Black;
            this.butStatus.HoverColor = System.Drawing.Color.White;
            this.butStatus.IsRound = true;
            this.butStatus.Location = new System.Drawing.Point(81, 175);
            this.butStatus.Margin = new System.Windows.Forms.Padding(2);
            this.butStatus.Name = "butStatus";
            this.butStatus.PressedColor = System.Drawing.Color.White;
            this.butStatus.RoundingArc = 19;
            this.butStatus.Size = new System.Drawing.Size(113, 19);
            this.butStatus.Style = MetroSuite.Design.Style.Custom;
            this.butStatus.TabIndex = 6;
            this.butStatus.Text = "Not Connected";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(276, 367);
            this.Controls.Add(this.butStatus);
            this.Controls.Add(this.butStats);
            this.Controls.Add(this.butMenu);
            this.Controls.Add(this.lock_open);
            this.Controls.Add(this.butConnect);
            this.Controls.Add(this.red_background_rectangle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.red_background_rectangle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lock_open)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroSuite.MetroButton butConnect;
        private System.Windows.Forms.PictureBox red_background_rectangle;
        private System.Windows.Forms.PictureBox lock_open;
        private MetroSuite.MetroButton butMenu;
        private MetroSuite.MetroButton butStats;
        private MetroSuite.MetroButton butStatus;
    }
}

