using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Management;

/*
 * name: Manuel Lind
 * class: 5AHIF
 * number: i16022
*/

namespace NetShare
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        ConnectButton connectButton = new ConnectButton();
        ListBox serverList = new ListBox();
        PictureBox loadingAnimation = new PictureBox();
        PictureBox menuItems = new PictureBox();
        PictureBox menuItemHeader = new PictureBox();
        PictureBox performanceBasedText = new PictureBox();
        PictureBox addServerBack = new PictureBox();
        PictureBox listServerBack = new PictureBox();
        ListBox serverCheckList = new ListBox();
        PictureBox listNetDevBack = new PictureBox();
        ListBox netDevList = new ListBox();
        ServerSettings serverSettings;
        string AppPath;
        const string settingsFile = "serverSettings.json";

        public static bool Deactivated = false;
        bool isClicked = false;
        string chosenServer = "";
        bool isClickedOnArrow = false;

        public Form1()
        {
            AppPath = AppDomain.CurrentDomain.BaseDirectory;
            if (!AppPath.EndsWith("\\"))
            {
                AppPath += "\\";
            }

            // Read the ServerSettings from File
            try
            {
                string settings = File.ReadAllText(AppPath + settingsFile);
                serverSettings = JsonSerializer.Deserialize<ServerSettings>(settings);
            } catch (Exception)
            {
                serverSettings = new ServerSettings();
            }

            confControls();
            connectButton.Show();

            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10)); // rounded corners Form
            clickOutsideListBox();

            // Connection Info Demo
            textConInfos.Text = "10 ms\r\n1000 Mb/s";
        }

        private void confControls()
        {
            // ServerList Settings
            serverList.Width = 250;
            serverList.Height = 110;
            serverList.Location = new Point(50, 318);
            serverList.Font = new Font("Century Gothic", 12, FontStyle.Regular);

            serverList.DrawMode = DrawMode.OwnerDrawFixed;
            serverList.DrawItem += serverList_DrawItem;
            serverList.DrawMode = DrawMode.OwnerDrawVariable;
            serverList.ItemHeight = 35;

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
            connectButton.Hide();

            // Loading-Animation Settings
            loadingAnimation.BackColor = Color.White;
            loadingAnimation.Location = new Point(123, 112);
            loadingAnimation.Size = new Size(104, 105);
            loadingAnimation.Image = Image.FromFile("../../Resources/loading.gif");
            loadingAnimation.SizeMode = PictureBoxSizeMode.Zoom;

            Controls.Add(loadingAnimation);
            loadingAnimation.Hide();

            // Menu-Items Settings
            menuItems.BackColor = Color.White;
            menuItems.Location = new Point(10, 110);
            menuItems.Size = new Size(340, 250);
            menuItems.Image = Image.FromFile("../../Resources/menuItems.png");
            menuItems.SizeMode = PictureBoxSizeMode.Zoom;

            menuItems.Click += menuItems_Click;

            Controls.Add(menuItems);
            menuItems.Hide();

            // MenuItem-Header Settings
            menuItemHeader.BackColor = Color.White;
            menuItemHeader.Location = new Point(53, 3);
            menuItemHeader.Size = new Size(320, 50);
            menuItemHeader.SizeMode = PictureBoxSizeMode.Zoom;

            Controls.Add(menuItemHeader);
            menuItemHeader.Hide();

            // performanceBasedText Settings
            performanceBasedText.BackColor = Color.White;
            performanceBasedText.Location = new Point(15, 70);
            performanceBasedText.Size = new Size(320, 200);
            performanceBasedText.Image = Image.FromFile("../../Resources/performanceBasedText.png");
            performanceBasedText.SizeMode = PictureBoxSizeMode.Zoom;

            Controls.Add(performanceBasedText);
            performanceBasedText.Hide();

            // addServerBackground Settings
            addServerBack.BackColor = Color.White;
            addServerBack.Location = new Point(16, 70);
            addServerBack.Size = new Size(320, 160);
            addServerBack.Image = Image.FromFile("../../Resources/addServerBack.png");
            addServerBack.SizeMode = PictureBoxSizeMode.Zoom;

            Controls.Add(addServerBack);
            addServerBack.Hide();

            // listServerBackground Settings
            listServerBack.BackColor = Color.White;
            listServerBack.Location = new Point(18, 232);
            listServerBack.Size = new Size(320, 260);
            listServerBack.Image = Image.FromFile("../../Resources/listServerBack.png");
            listServerBack.SizeMode = PictureBoxSizeMode.Zoom;

            Controls.Add(listServerBack);
            listServerBack.Hide();

            //serverCheckedList Settings
            serverCheckList.BorderStyle = BorderStyle.None;
            serverCheckList.Font = new Font("Century Gothic", 12, FontStyle.Regular);
            serverCheckList.Location = new Point(40, 295);
            serverCheckList.Size = new Size(270, 130);

            serverCheckList.DrawMode = DrawMode.OwnerDrawFixed;
            serverCheckList.DrawItem += serverCheckList_DrawItem;
            serverCheckList.DrawMode = DrawMode.OwnerDrawVariable;
            serverCheckList.ItemHeight = 30;

            // Load saved ServerSettings
            for (int i = 0; i < serverSettings.serverList.Count; i++)
            {
                serverCheckList.Items.Add(serverSettings.serverList[i].name);
                serverList.Items.Add(serverSettings.serverList[i].name);
            }
            
            Controls.Add(serverCheckList);
            serverCheckList.Hide();

            // listNetDevBackground Settings
            listNetDevBack.BackColor = Color.White;
            listNetDevBack.Location = new Point(16, 70);
            listNetDevBack.Size = new Size(320, 400);
            listNetDevBack.Image = Image.FromFile("../../Resources/listNetDevBack.png");
            listNetDevBack.SizeMode = PictureBoxSizeMode.Zoom;

            Controls.Add(listNetDevBack);
            listNetDevBack.Hide();

            // listNetworkDevices Settings
            netDevList.BorderStyle = BorderStyle.None;
            netDevList.Font = new Font("Century Gothic", 12, FontStyle.Regular);
            netDevList.Location = new Point(38, 132);
            netDevList.Size = new Size(270, 310);
            netDevList.SelectionMode = SelectionMode.MultiSimple;

            netDevList.DrawMode = DrawMode.OwnerDrawFixed;
            netDevList.DrawItem += netDevList_DrawItem;
            netDevList.DrawMode = DrawMode.OwnerDrawVariable;
            netDevList.ItemHeight = 30;

            // Add all Active Network Devices to ListBox
            foreach (string device in GetNetworkDevices())
            {
                netDevList.Items.Add(device);
            }

            // Activate Horizontal Scrollbar if Entry is too large
            netDevList.HorizontalScrollbar = true;

            Graphics g = netDevList.CreateGraphics();

            int largestSize = 0;
            
            for (int i = 0; i < netDevList.Items.Count - 1; i++)
            {
                int tempSize = (int)g.MeasureString(netDevList.Items[i].ToString(), netDevList.Font).Width;
                if (tempSize > largestSize)
                {
                    largestSize = tempSize;
                }
            }

            if (largestSize == 0)
            {
                largestSize = (int)g.MeasureString(netDevList.Items[0].ToString(), netDevList.Font).Width;
            }

            netDevList.HorizontalExtent = largestSize;

            Controls.Add(netDevList);
            netDevList.Hide();
        }

        // Get all Active Network Devices
        public List<string> GetNetworkDevices()
        {
            List<string> netDevices = new List<string>();
            ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection instances = managementClass.GetInstances();

            foreach (ManagementObject managementObject in instances)
            {
                if ((bool)managementObject["ipEnabled"])
                {
                    netDevices.Add(managementObject["Caption"].ToString().Remove(0, 11));
                }
            }

            return netDevices;
        }

        // Manually Draw of ListItems of ServerList in Menu
        private void serverCheckList_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawItem(sender, e);
        }

        // Manually Draw of ListItems of NetworkDevicesList in Menu
        private void netDevList_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawItem(sender, e);
        }

        // Manually Draw of ListItems
        private void DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (e.Index > -1)
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e = new DrawItemEventArgs(e.Graphics, new Font("Century Gothic", 13, FontStyle.Bold), e.Bounds, e.Index, e.State ^ DrawItemState.Selected, Color.FromArgb(41, 182, 246), Color.White);
                }
                object item = list.Items[e.Index];
                e.DrawBackground();
                e.DrawFocusRectangle();
                Brush brush = new SolidBrush(e.ForeColor);
                SizeF size = e.Graphics.MeasureString(item.ToString(), e.Font);
                e.Graphics.DrawString(item.ToString(), e.Font, brush, e.Bounds.Left, e.Bounds.Top);
            }
        }

        // Manually Draw of ListItems of ServerList at ConnectButton
        private void serverList_DrawItem(object sender, DrawItemEventArgs e)
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
                e.Graphics.DrawString(item.ToString(), e.Font, brush, e.Bounds.Left + (e.Bounds.Width / 2 - size.Width / 2) + 6, e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2));
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

        private void connectButton_MouseDown(object sender, MouseEventArgs e)
        {
            isClickedOnArrow = true;
        }

        // Eventlistener for Clicking on connectButton

        private void connectButton_MouseUp(object sender, MouseEventArgs e)
        {
            // Check if Client is Connected
            if (connectButton.IsConnected)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // ClickEvent to Disconnect from Server
                    changeFormStyleToDisconnected();
                    return;
                }
            }
            // Check if Client is not Connected/Connecting
            if (!connectButton.IsConnected && !connectButton.IsConnecting) 
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
                            changeFormStyleToConnecting();

                            // Wait only for Demo-Purposes!
                            wait(2000);

                            changeFormStyleToConnected();
                        }
                    }
                }
            }
        }

        // Function to Change Style to Disconnected
        private void changeFormStyleToDisconnected()
        {
            serverList.ClearSelected();
            connectButton.IsConnected = false;

            // Change Button
            connectButton.ButtonColor = Color.FromArgb(129, 191, 132);
            connectButton.Text = "Select Server";

            // Set Red-Background, NoConnection-Image and Text
            formBackground.Image = Image.FromFile("../../Resources/red_background_rectangle.png");
            connectionStatusPicture.Image = Image.FromFile("../../Resources/disconnected_roundBackground.png");
            butShowInfos.Icon = Image.FromFile("../../Resources/no_internet.png");

            connectionStatusText.Width = 170;
            connectionStatusText.Location = new Point(90, 248);

            connectionStatusText.ForeColor = Color.Black;
            connectionStatusText.DefaultColor = Color.White;
            connectionStatusText.DisabledColor = Color.White;
            connectionStatusText.HoverColor = Color.White;
            connectionStatusText.PressedColor = Color.White;
            connectionStatusText.Text = "Not connected";

            // Set Red Color at every Control
            butOpenMenu.PressedColor = Color.FromArgb(243, 96, 91);
            butOpenMenu.DefaultColor = Color.FromArgb(243, 96, 91);
            butOpenMenu.HoverColor = Color.FromArgb(243, 96, 91);
            butOpenMenu.BackColor = Color.FromArgb(243, 96, 91);

            butShowInfos.PressedColor = Color.FromArgb(243, 96, 91);
            butShowInfos.DefaultColor = Color.FromArgb(243, 96, 91);
            butShowInfos.HoverColor = Color.FromArgb(243, 96, 91);
            butShowInfos.BackColor = Color.FromArgb(243, 96, 91);

            connectionStatusText.BackColor = Color.FromArgb(243, 96, 91);
            connectionStatusPicture.BackColor = Color.FromArgb(243, 96, 91);
        }

        // Function to Change Style to Connecting
        private void changeFormStyleToConnecting()
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
        }

        // Function to Change Style to Connected
        private void changeFormStyleToConnected()
        {
            connectButton.IsConnected = true;
            connectButton.IsConnecting = false;

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

            // Clear chosenServer after successfull Connection
            chosenServer = "";
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
        private void clickOutsideListBox()
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

        // HoverEventHandler to Show and Hide the current Network-Stats
        private void butShowInfos_MouseEnter(object sender, EventArgs e)
        {
            if (connectButton.IsConnected)
            {
                textConInfos.BackColor = Color.FromArgb(81, 172, 82);
                textConInfos.BorderColor = Color.FromArgb(81, 172, 82);
                textConInfos.DefaultColor = Color.FromArgb(81, 172, 82);
                textConInfos.DisabledColor = Color.FromArgb(81, 172, 82);
                textConInfos.HoverColor = Color.FromArgb(81, 172, 82);
                textConInfos.Show();
            }
            
        }
        private void butShowInfos_MouseLeave(object sender, EventArgs e)
        {
            if (connectButton.IsConnected)
            {
                textConInfos.Hide();
            }
        }

        // Hide whole Form
        private void hideForm()
        {
            formBackground.Hide();
            connectButton.Hide();
            connectionStatusText.Hide();
            connectionStatusPicture.Hide();
            butShowInfos.Hide();
            butOpenMenu.Hide();
        }

        // Show whole From again
        private void showForm()
        {
            formBackground.Show();
            connectButton.Show();
            connectionStatusText.Show();
            connectionStatusPicture.Show();
            butShowInfos.Show();
            butOpenMenu.Show();
        }

        // Show Menu
        private void showMenu()
        {
            menuItems.Show();
            butMenuClose.Visible = true;
        }

        // Hide Menu
        private void hideMenu()
        {
            menuItems.Hide();
            butMenuClose.Visible = false;
        }

        // Click to open Menu
        private void butOpenMenu_Click(object sender, EventArgs e)
        {
            if (!connectButton.IsConnecting)
            {
                hideForm();
                showMenu();
            }
        }

        // Click to Close Menu
        private void butMenuClose_Click(object sender, EventArgs e)
        {
            hideMenu();
            showForm();
        }

        // ClickEventHandler for MenuItems
        private void menuItems_Click(object sender, EventArgs e)
        {
            if (MousePosition.Y > 700 && MousePosition.Y < 740) // MenuItem: Mode
            {
                hideMenu();
                showMenuItemMode();
            }
            else if (MousePosition.Y > 750 && MousePosition.Y < 790) // MenuItem: Server
            {
                hideMenu();
                showMenuItemServer();
            }
            else if (MousePosition.Y > 805 && MousePosition.Y < 845) // MenuItem: Network Devices
            {
                hideMenu();
                showMenuItemNetworkDevices();
            }
        }

        // Button to get back to Menu-Items-Overview
        private void butMenuReturn_Click(object sender, EventArgs e)
        {
            hideMenuItemMode();
            hideMenuItemServer();
            hideMenuItemNetworkDevices();
            showMenu();
        }

        // Show Menu Item "Mode"
        private void showMenuItemMode()
        {
            butMenuReturn.Visible = true;
            menuItemHeader.Image = Image.FromFile("../../Resources/modeHeader.png");
            menuItemHeader.Show();
            performanceBasedText.Show();
            butPerfBased.IsRound = true;
            butPerfBased.RoundingArc = 10;
            butPerfBased.BringToFront();
            butPerfBased.Show();
        }

        // Hide Menu Item "Mode"
        private void hideMenuItemMode()
        {
            butMenuReturn.Visible = false;
            menuItemHeader.Image = null;
            menuItemHeader.Hide();
            performanceBasedText.Hide();
            butPerfBased.Hide();
        }

        // Show Menu Item "Server"
        private void showMenuItemServer()
        {
            butMenuReturn.Visible = true;
            menuItemHeader.Image = Image.FromFile("../../Resources/serverHeader.png");
            menuItemHeader.Show();

            addNameInput.BringToFront();
            addIPInput.BringToFront();
            addPortInput.BringToFront();

            addServerBack.Show();
            addNameInput.Show();
            addIPInput.Show();
            addPortInput.Show();

            butAddServer.IsRound = true;
            butAddServer.RoundingArc = 10;
            butAddServer.BringToFront();
            butAddServer.Show();

            listServerBack.Show();
            serverCheckList.BringToFront();
            serverCheckList.Show();

            butDeleteServer.IsRound = true;
            butDeleteServer.RoundingArc = 10;
            butDeleteServer.BringToFront();
            butDeleteServer.Show();
        }

        // Hide Menu Item "Server"
        private void hideMenuItemServer()
        {
            butMenuReturn.Visible = false;
            menuItemHeader.Image = null;
            menuItemHeader.Hide();

            addServerBack.Hide();
            addNameInput.Hide();
            addIPInput.Hide();
            addPortInput.Hide();

            butAddServer.Hide();

            listServerBack.Hide();
            serverCheckList.Hide();

            butDeleteServer.Hide();
        }

        // Show Menu Item "Network Devices"
        private void showMenuItemNetworkDevices()
        {
            butMenuReturn.Visible = true;
            menuItemHeader.Image = Image.FromFile("../../Resources/networkDevicesHeader.png");
            menuItemHeader.Show();
            listNetDevBack.Show();

            netDevList.BringToFront();
            netDevList.Show();
        }

        // Hide Menu Item "Network Devices"
        private void hideMenuItemNetworkDevices()
        {
            butMenuReturn.Visible = false;
            menuItemHeader.Image = null;
            menuItemHeader.Hide();
            listNetDevBack.Hide();
            netDevList.Hide();
        }

        private void butAddServer_Click(object sender, EventArgs e)
        {
            if (addNameInput.Text != "" && addIPInput.Text != "" && addPortInput.Text != "")
            {
                serverCheckList.Items.Add(addNameInput.Text);
                serverList.Items.Add(addNameInput.Text);

                // Save in Settings
                ServerObject serverObject = new ServerObject();
                serverObject.name = addNameInput.Text;
                serverObject.ip = addIPInput.Text;
                int port;
                int.TryParse(addPortInput.Text, out port);
                serverObject.port = port;

                serverSettings.serverList.Add(serverObject);

                addNameInput.Clear();
                addIPInput.Clear();
                addPortInput.Clear();
            }
        }

        private void butDeleteServer_Click(object sender, EventArgs e)
        {
            int selectedIndex;

            if ((selectedIndex = serverCheckList.SelectedIndex) != -1)
            {
                serverCheckList.Items.RemoveAt(selectedIndex);
                serverList.Items.RemoveAt(selectedIndex);

                // Remove in Settings-File
                serverSettings.serverList.RemoveAt(selectedIndex);
            }
        }

        // Save ServerList to File
        public void saveSettings()
        {
            try
            {
                string settings = JsonSerializer.Serialize(serverSettings);
                File.WriteAllText(AppPath + settingsFile, settings);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}