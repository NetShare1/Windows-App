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
            this.formBackground = new System.Windows.Forms.PictureBox();
            this.butOpenMenu = new MetroSuite.MetroButton();
            this.butShowInfos = new MetroSuite.MetroButton();
            this.connectionStatusPicture = new System.Windows.Forms.PictureBox();
            this.connectionStatusText = new MetroSuite.MetroButton();
            this.textConInfos = new MetroSuite.MetroTextbox();
            this.butMenuClose = new MetroSuite.MetroButton();
            this.butMenuReturn = new MetroSuite.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.formBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionStatusPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // formBackground
            // 
            this.formBackground.Image = ((System.Drawing.Image)(resources.GetObject("formBackground.Image")));
            this.formBackground.Location = new System.Drawing.Point(0, 0);
            this.formBackground.MaximumSize = new System.Drawing.Size(350, 420);
            this.formBackground.MinimumSize = new System.Drawing.Size(350, 420);
            this.formBackground.Name = "formBackground";
            this.formBackground.Size = new System.Drawing.Size(350, 420);
            this.formBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.formBackground.TabIndex = 0;
            this.formBackground.TabStop = false;
            // 
            // butOpenMenu
            // 
            this.butOpenMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butOpenMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butOpenMenu.BorderColor = System.Drawing.Color.Transparent;
            this.butOpenMenu.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butOpenMenu.DisabledColor = System.Drawing.Color.Transparent;
            this.butOpenMenu.DrawBorder = false;
            this.butOpenMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.butOpenMenu.ForeColor = System.Drawing.Color.Transparent;
            this.butOpenMenu.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butOpenMenu.Icon = ((System.Drawing.Image)(resources.GetObject("butOpenMenu.Icon")));
            this.butOpenMenu.Location = new System.Drawing.Point(10, 12);
            this.butOpenMenu.Name = "butOpenMenu";
            this.butOpenMenu.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butOpenMenu.RoundingArc = 30;
            this.butOpenMenu.Size = new System.Drawing.Size(30, 30);
            this.butOpenMenu.TabIndex = 1;
            this.butOpenMenu.Click += new System.EventHandler(this.butOpenMenu_Click);
            // 
            // butShowInfos
            // 
            this.butShowInfos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butShowInfos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butShowInfos.BorderColor = System.Drawing.Color.Transparent;
            this.butShowInfos.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butShowInfos.DisabledColor = System.Drawing.Color.Transparent;
            this.butShowInfos.DrawBorder = false;
            this.butShowInfos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.butShowInfos.ForeColor = System.Drawing.Color.Transparent;
            this.butShowInfos.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butShowInfos.Icon = ((System.Drawing.Image)(resources.GetObject("butShowInfos.Icon")));
            this.butShowInfos.Location = new System.Drawing.Point(305, 10);
            this.butShowInfos.Name = "butShowInfos";
            this.butShowInfos.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.butShowInfos.RoundingArc = 30;
            this.butShowInfos.Size = new System.Drawing.Size(35, 30);
            this.butShowInfos.TabIndex = 2;
            this.butShowInfos.MouseEnter += new System.EventHandler(this.butShowInfos_MouseEnter);
            this.butShowInfos.MouseLeave += new System.EventHandler(this.butShowInfos_MouseLeave);
            // 
            // connectionStatusPicture
            // 
            this.connectionStatusPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.connectionStatusPicture.Image = ((System.Drawing.Image)(resources.GetObject("connectionStatusPicture.Image")));
            this.connectionStatusPicture.Location = new System.Drawing.Point(100, 90);
            this.connectionStatusPicture.Name = "connectionStatusPicture";
            this.connectionStatusPicture.Size = new System.Drawing.Size(150, 150);
            this.connectionStatusPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.connectionStatusPicture.TabIndex = 3;
            this.connectionStatusPicture.TabStop = false;
            // 
            // connectionStatusText
            // 
            this.connectionStatusText.AutoStyle = false;
            this.connectionStatusText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.connectionStatusText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.connectionStatusText.BorderColor = System.Drawing.Color.Transparent;
            this.connectionStatusText.DefaultColor = System.Drawing.Color.White;
            this.connectionStatusText.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.connectionStatusText.DrawBorder = false;
            this.connectionStatusText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionStatusText.HoverColor = System.Drawing.Color.White;
            this.connectionStatusText.IsRound = true;
            this.connectionStatusText.Location = new System.Drawing.Point(90, 248);
            this.connectionStatusText.Name = "connectionStatusText";
            this.connectionStatusText.PressedColor = System.Drawing.Color.White;
            this.connectionStatusText.RoundingArc = 25;
            this.connectionStatusText.Size = new System.Drawing.Size(170, 25);
            this.connectionStatusText.Style = MetroSuite.Design.Style.Custom;
            this.connectionStatusText.TabIndex = 4;
            this.connectionStatusText.Text = "Not Connected";
            // 
            // textConInfos
            // 
            this.textConInfos.AutoStyle = false;
            this.textConInfos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.textConInfos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textConInfos.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.textConInfos.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.textConInfos.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.textConInfos.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textConInfos.ForeColor = System.Drawing.Color.White;
            this.textConInfos.HideSelection = false;
            this.textConInfos.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(96)))), ((int)(((byte)(91)))));
            this.textConInfos.Location = new System.Drawing.Point(230, 4);
            this.textConInfos.Multiline = true;
            this.textConInfos.Name = "textConInfos";
            this.textConInfos.PasswordChar = '\0';
            this.textConInfos.Size = new System.Drawing.Size(75, 45);
            this.textConInfos.Style = MetroSuite.Design.Style.Custom;
            this.textConInfos.TabIndex = 5;
            this.textConInfos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // butMenuClose
            // 
            this.butMenuClose.BackColor = System.Drawing.Color.White;
            this.butMenuClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butMenuClose.BorderColor = System.Drawing.Color.Transparent;
            this.butMenuClose.DefaultColor = System.Drawing.Color.White;
            this.butMenuClose.DisabledColor = System.Drawing.Color.Transparent;
            this.butMenuClose.DrawBorder = false;
            this.butMenuClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.butMenuClose.ForeColor = System.Drawing.Color.Transparent;
            this.butMenuClose.HoverColor = System.Drawing.Color.White;
            this.butMenuClose.Icon = ((System.Drawing.Image)(resources.GetObject("butMenuClose.Icon")));
            this.butMenuClose.Location = new System.Drawing.Point(11, 15);
            this.butMenuClose.Name = "butMenuClose";
            this.butMenuClose.PressedColor = System.Drawing.Color.White;
            this.butMenuClose.RoundingArc = 20;
            this.butMenuClose.Size = new System.Drawing.Size(25, 20);
            this.butMenuClose.TabIndex = 6;
            this.butMenuClose.Visible = false;
            this.butMenuClose.Click += new System.EventHandler(this.butMenuClose_Click);
            // 
            // butMenuReturn
            // 
            this.butMenuReturn.BackColor = System.Drawing.Color.White;
            this.butMenuReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butMenuReturn.BorderColor = System.Drawing.Color.Transparent;
            this.butMenuReturn.DefaultColor = System.Drawing.Color.White;
            this.butMenuReturn.DisabledColor = System.Drawing.Color.Transparent;
            this.butMenuReturn.DrawBorder = false;
            this.butMenuReturn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.butMenuReturn.ForeColor = System.Drawing.Color.Transparent;
            this.butMenuReturn.HoverColor = System.Drawing.Color.White;
            this.butMenuReturn.Icon = ((System.Drawing.Image)(resources.GetObject("butMenuReturn.Icon")));
            this.butMenuReturn.Location = new System.Drawing.Point(11, 15);
            this.butMenuReturn.Name = "butMenuReturn";
            this.butMenuReturn.PressedColor = System.Drawing.Color.White;
            this.butMenuReturn.RoundingArc = 25;
            this.butMenuReturn.Size = new System.Drawing.Size(30, 25);
            this.butMenuReturn.TabIndex = 7;
            this.butMenuReturn.Visible = false;
            this.butMenuReturn.Click += new System.EventHandler(this.butMenuReturn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(350, 500);
            this.Controls.Add(this.butMenuReturn);
            this.Controls.Add(this.butMenuClose);
            this.Controls.Add(this.textConInfos);
            this.Controls.Add(this.connectionStatusText);
            this.Controls.Add(this.connectionStatusPicture);
            this.Controls.Add(this.butShowInfos);
            this.Controls.Add(this.butOpenMenu);
            this.Controls.Add(this.formBackground);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Click += new System.EventHandler(this.Form1_Click);
            ((System.ComponentModel.ISupportInitialize)(this.formBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionStatusPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox formBackground;
        private MetroSuite.MetroButton butOpenMenu;
        private MetroSuite.MetroButton butShowInfos;
        private System.Windows.Forms.PictureBox connectionStatusPicture;
        private MetroSuite.MetroButton connectionStatusText;
        private MetroSuite.MetroTextbox textConInfos;
        private MetroSuite.MetroButton butMenuClose;
        private MetroSuite.MetroButton butMenuReturn;
    }
}

