using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

/*
 * name: Manuel Lind
 * class: 5AHIF
 * number: i16022
*/

namespace NetShare
{
    public partial class Form1 : Form
    {
        public static bool Deactivated = false;
        bool isClicked = false;
        string chosenServer = "";
        bool isClickedOnArrow = false;

        ConnectButton connectButton = new ConnectButton();
        ListBox serverList = new ListBox();
        PictureBox loadingAnimation = new PictureBox();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn (int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public Form1()
        {
            // ServerList Settings
            serverList.Width = 250;
            serverList.Height = 110;
            serverList.Location = new Point(50, 318);
            serverList.Font = new Font("Century Gothic", 12, FontStyle.Regular);

            serverList.DrawMode = DrawMode.OwnerDrawFixed;
            serverList.DrawItem += new DrawItemEventHandler(listBox_DrawItem);
            serverList.DrawMode = DrawMode.OwnerDrawVariable;
            serverList.ItemHeight = 35;

            // Manually fill the ListBox for Demo
            for (int i = 0; i < 10; i++)
            {
                serverList.Items.Add("127.100.100.10" + i);
                serverList.Items.Add("127.0.0." + i);
            }

            serverList.SelectedIndexChanged += serverList_SelectedIndexChanged;

            Controls.Add(serverList);
            serverList.Hide();

            // ConnectButton Settings
            connectButton.List = serverList;

            connectButton.Location = new Point(50, 430);
            connectButton.Size = new Size(250, 40);
            connectButton.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            connectButton.Text = "Select Server";

            connectButton.FlatStyle = FlatStyle.Flat;
            connectButton.FlatAppearance.BorderSize = 0;

            connectButton.ButtonColor = Color.FromArgb(129, 191, 132);
            connectButton.TextColor = Color.White;

            connectButton.MouseUp += connectButton_MouseUp;
            connectButton.MouseDown += connectButton_MouseDown;

            Controls.Add(connectButton);

            // Loading-Animation Settings
            loadingAnimation.BackColor = Color.White;
            loadingAnimation.Location = new Point(123, 112);
            loadingAnimation.Size = new Size(104, 105);
            loadingAnimation.Image = Image.FromFile("../../Resources/loading.gif");
            loadingAnimation.SizeMode = PictureBoxSizeMode.Zoom;

            Controls.Add(loadingAnimation);
            loadingAnimation.Hide();

            //
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            startClickEvent();
        }

        // Manually Draw of ListItems
        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (e.Index > -1)
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e = new DrawItemEventArgs(e.Graphics, new Font("Century Gothic", 12, FontStyle.Bold), e.Bounds, e.Index, e.State ^ DrawItemState.Selected, Color.FromArgb(67, 160, 71), Color.White);
                }     
                object item = list.Items[e.Index];
                e.DrawBackground();
                e.DrawFocusRectangle();
                Brush brush = new SolidBrush(e.ForeColor);
                SizeF size = e.Graphics.MeasureString(item.ToString(), e.Font);
                e.Graphics.DrawString(item.ToString(), e.Font, brush, e.Bounds.Left + (e.Bounds.Width / 2 - size.Width / 2) + 13, e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2));
            }
        }

        // Eventlistener for Selected Server in ListBox
        private void serverList_SelectedIndexChanged(object sender, EventArgs e)
        {
            serverList.Hide();
            chosenServer = serverList.GetItemText(serverList.SelectedItem);
            connectButton.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold);
            connectButton.Text = "Connect to " + chosenServer;
            connectButton.ButtonColor = Color.FromArgb(67, 160, 71);
            isClicked = false;
            connectButton.IsOpen = false;
        }

        // Eventlistener for Clicking on connectButton
        private void connectButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (!connectButton.IsConnected) // Check if Client is not Connected
            {
                isClickedOnArrow = false;

                if (e.Button == MouseButtons.Left)
                {
                    if (MousePosition.X > 1820)
                    {
                        if (!isClicked)
                        {
                            serverList.Show();
                            isClicked = true;
                            connectButton.IsOpen = true;
                        }
                        else
                        {
                            serverList.Hide();
                            isClicked = false;
                            connectButton.IsOpen = false;
                        }
                    }
                    else
                    {
                        // ClickEvent to Connect to Server
                        if (chosenServer.Length > 0)
                        {
                            connectButton.IsConnecting = true;
                            serverList.Hide();
                            isClicked = false;
                            connectButton.IsOpen = false;

                            // Change Button 
                            connectButton.ButtonColor = Color.FromArgb(176, 190, 197);
                            connectButton.Text = "Connecting to " + chosenServer;

                            // Set Blue-Background and Connecting-Animation
                            formBackground.Image = Image.FromFile("../../Resources/blue_background_rectangle.png");
                            connectionStatusPicture.Image = Image.FromFile("../../Resources/connecting_roundBackground.png");
                            connectionStatusText.Text = "Connecting...";

                            loadingAnimation.BringToFront();
                            loadingAnimation.Show();

                            // Set Blue Color at every Control
                            butOpenMenu.PressedColor = Color.FromArgb(60, 195, 248);
                            butOpenMenu.DefaultColor = Color.FromArgb(60, 195, 248);
                            butOpenMenu.HoverColor = Color.FromArgb(60, 195, 248);
                            butOpenMenu.BackColor = Color.FromArgb(60, 195, 248);

                            butShowInfos.PressedColor = Color.FromArgb(60, 195, 248);
                            butShowInfos.DefaultColor = Color.FromArgb(60, 195, 248);
                            butShowInfos.HoverColor = Color.FromArgb(60, 195, 248);
                            butShowInfos.BackColor = Color.FromArgb(60, 195, 248);

                            connectionStatusText.BackColor = Color.FromArgb(60, 195, 248);
                            connectionStatusPicture.BackColor = Color.FromArgb(60, 195, 248);

                            // Wait only for Demo-Purposes!
                            wait(2000);

                            // Call Function to Change Style to Connected
                            connectButton.IsConnected = true;
                            connectButton.IsConnecting = false;
                            changeFormStyleToConnected();
                        }
                    }
                }
            }
            else // Check if Client is Connected
            {
                if (e.Button == MouseButtons.Left)
                {
                    // ClickEvent to Disconnect from Server

                    // TODO!


                    // At Successfull Disconnect: 
                    //connectButton.IsConnected = false;
                }
            }
        }

        // Function to Change Style to Connected
        private void changeFormStyleToConnected()
        {
            // Change Button 
            connectButton.ButtonColor = Color.FromArgb(244, 67, 54);
            connectButton.Text = "Disconnect";

            // Set Green-Background, Connected-Image and Text
            formBackground.Image = Image.FromFile("../../Resources/green_background_rectangle.png");
            connectionStatusPicture.Image = Image.FromFile("../../Resources/connected_roundBackground.png");
            butShowInfos.Icon = Image.FromFile("../../Resources/con_full.png");

            if (chosenServer.Length > 9)
            {
                connectionStatusText.Width = 250;
                connectionStatusText.Location = new Point(50, 248);
            } 
            else
            {
                connectionStatusText.Width = 200;
                connectionStatusText.Location = new Point(75, 248);
            }

            connectionStatusText.ForeColor = Color.White;
            connectionStatusText.DefaultColor = Color.FromArgb(118, 210, 117);
            connectionStatusText.DisabledColor = Color.FromArgb(118, 210, 117);
            connectionStatusText.HoverColor = Color.FromArgb(118, 210, 117);
            connectionStatusText.PressedColor = Color.FromArgb(118, 210, 117);
            connectionStatusText.Text = "Connected to " + chosenServer;

            // Hide Loading-Animation
            loadingAnimation.Hide();

            // Set Green Color at every Control
            butOpenMenu.PressedColor = Color.FromArgb(81, 172, 82);
            butOpenMenu.DefaultColor = Color.FromArgb(81, 172, 82);
            butOpenMenu.HoverColor = Color.FromArgb(81, 172, 82);
            butOpenMenu.BackColor = Color.FromArgb(81, 172, 82);

            butShowInfos.PressedColor = Color.FromArgb(81, 172, 82);
            butShowInfos.DefaultColor = Color.FromArgb(81, 172, 82);
            butShowInfos.HoverColor = Color.FromArgb(81, 172, 82);
            butShowInfos.BackColor = Color.FromArgb(81, 172, 82);

            connectionStatusText.BackColor = Color.FromArgb(81, 172, 82);
            connectionStatusPicture.BackColor = Color.FromArgb(81, 172, 82);
        }

        // Wait-Function from Internet only for Demo-Purposes!
        private void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

        private void connectButton_MouseDown(object sender, MouseEventArgs e)
        {
            isClickedOnArrow = true;
        }

        // Set Location of Form depending on the Taskbar´s Location
        public void setLocation()
        {
            if (Screen.PrimaryScreen.WorkingArea.Top > 0)
            {
                //Taskbar top
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.X + Screen.PrimaryScreen.WorkingArea.Width - Width - 10,
                                   Screen.PrimaryScreen.WorkingArea.Y);
            }
            else if (Screen.PrimaryScreen.WorkingArea.Left != Screen.PrimaryScreen.Bounds.X)
            {
                //Taskbar left
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.X + 10,
                                      Screen.PrimaryScreen.WorkingArea.Y + Screen.PrimaryScreen.WorkingArea.Height - Height);
            }
            else if ((Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height) > 0)
            {
                //Taskbar bottom
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.X + Screen.PrimaryScreen.WorkingArea.Width - Width - 10,
                                      Screen.PrimaryScreen.WorkingArea.Y + Screen.PrimaryScreen.WorkingArea.Height - Height);
            }
            else if (Screen.PrimaryScreen.WorkingArea.Right != 0)
            {
                //Taskbar right
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.X + Screen.PrimaryScreen.WorkingArea.Width - Width - 10,
                                      Screen.PrimaryScreen.WorkingArea.Y + Screen.PrimaryScreen.WorkingArea.Height - Height);
            }
        }

        // Hide and Reset the Form by Clicking outside of the Form
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            serverList.Hide();
            isClicked = false;
            connectButton.IsOpen = false;

            Deactivated = true;
            Hide();
        }

        // Hide ListBox when Clicking outside of ListBox
        private void startClickEvent()
        {
            foreach (Control ctl in Controls)
            {
                ctl.MouseClick += new MouseEventHandler(Form1_Click);
            }
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            if (!isClickedOnArrow)
            {
                serverList.Hide();
                isClicked = false;
                connectButton.IsOpen = false;
            }
        }
    }
}