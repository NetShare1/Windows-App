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
            for (int i = 0; i < 20; i++)
            {
                serverList.Items.Add("Connect to 127.0.0." + i);
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

            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            startClickEvent();
        }

        // Manually Draw of ListItems
        void listBox_DrawItem(object sender, DrawItemEventArgs e)
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
            connectButton.Text = chosenServer;
            connectButton.ButtonColor = Color.FromArgb(67, 160, 71);
            isClicked = false;
            connectButton.IsOpen = false;
        }

        // Eventlistener for Clicking on connectButton
        private void connectButton_MouseUp(object sender, MouseEventArgs e)
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
                } else
                {
                    if (chosenServer.Length > 0)
                    {
                        connectButton.IsConnecting = true;
                        connectButton.ButtonColor = Color.FromArgb(176, 190, 197);
                        connectButton.Text = "Connecting to " + chosenServer.Substring(11);
                    }
                }
            }
        }

        private void connectButton_MouseDown(object sender, MouseEventArgs e)
        {
            isClickedOnArrow = true;
        }

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