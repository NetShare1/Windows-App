using NetShare.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;

namespace NetShare
{
    public partial class Form1 : Form
    {
        public static bool Deactivated = false; 

        public Form1()
        {
            InitializeComponent();
        }
        public void Start()
        {
            try
            {
                butConnect.Text = "Connecting";
                this.Refresh();
                TcpClient client = new TcpClient("localhost", 5260);
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("{\"type\":\"Put\",\"on\":\"driver.state\",\"data\":{ \"state\":\"running\"}}\n");
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                String responseData = String.Empty;
                int crashed = 0;

                while (true)
                {
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    if (responseData.Contains("startup"))
                    {
                        Debug.WriteLine("Connecting");
                    }
                    else if (responseData.Contains("crashed"))
                    {
                        Debug.WriteLine("Crashed");
                        if (crashed > 2)
                        {
                            Debug.WriteLine("Crashed More than 2 times");
                            return;
                        }
                        client = new TcpClient("localhost", 5260);
                        data = System.Text.Encoding.ASCII.GetBytes("{\"type\":\"Put\",\"on\":\"driver.state\",\"data\":{ \"state\":\"running\"}}\n");
                        stream = client.GetStream();
                        stream.Write(data, 0, data.Length);
                        responseData = String.Empty;
                        crashed++;
                    }
                    else if (responseData.Contains("running"))
                    {
                        Debug.WriteLine("Connected");
                        butConnect.Text = "Disconnect";
                        this.Refresh();
                        data = System.Text.Encoding.ASCII.GetBytes("{\"type\":\"Put\",\"on\":\"connection.state\",\"data\":{ \"state\":\"closed\"}}\n");
                        stream.Write(data, 0, data.Length);
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        public void Stop()
        {
            try
            {
                TcpClient client = new TcpClient("localhost", 5260);
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("{\"type\":\"Put\",\"on\":\"driver.state\",\"data\":{ \"state\":\"stopped\"}}\n");
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                String responseData = String.Empty;

                while (true)
                {
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

                    if (responseData.Contains("stopped"))
                    {
                        Debug.WriteLine("Disconnected");
                        butConnect.Text = "Connect";
                        this.Refresh();
                        data = System.Text.Encoding.ASCII.GetBytes("{\"type\":\"Put\",\"on\":\"connection.state\",\"data\":{ \"state\":\"closed\"}}\n");
                        stream.Write(data, 0, data.Length);
                        return;
                    }
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
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
            Deactivated = true;
            Hide();
        }

        private void butConnect_Click(object sender, EventArgs e)
        {
            if (butConnect.Text == "Connect")
            {
                Start();
            }
            else if (butConnect.Text == "Disconnect")
            {
                Stop();
            }
        }
    }
}
