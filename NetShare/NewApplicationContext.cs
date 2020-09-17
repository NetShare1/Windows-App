using NetShare.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetShare
{
    public class NewApplicationContext : ApplicationContext
    {
        private Form1 Form = new Form1();
        private NotifyIcon trayIcon;

        public NewApplicationContext()
        {
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.Icon1,
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Exit", Exit)
            }),
                Visible = true
            };

            this.trayIcon.Text = "NetShare";
            this.trayIcon.Click += new System.EventHandler(this.notifyIcon_Click);
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            Application.Exit();
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            var eventArgs = e as MouseEventArgs;
            if (eventArgs.Button == MouseButtons.Left)
            {
                if (Form.Visible == true)
                {
                    Form.Hide();
                }
                else
                {
                    //Application.OpenForms[Form].Focus();
                    Form.Activate();
                    Form.Focus();
                    Form.Show();
                }
            }
        }
    }
}
