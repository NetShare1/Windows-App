﻿using NetShare.Properties;
using System;
using System.Windows.Forms;

/*
 * name: Grafl Martin
 * class: 5AHIF
*/

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
                Icon = Resources.Tasktrayicon,
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Close", Exit)
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
            Form.saveSettings();
            Form.Close();
            Form.Dispose();
            Application.Exit();
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            var eventArgs = e as MouseEventArgs;
            if (eventArgs.Button == MouseButtons.Left)
            {
                if (!Form1.Deactivated)
                {
                    Form.setLocation();
                    try
                    {
                        Form.ShowDialog();
                    }
                    catch(Exception)
                    {
                    }
                }
                else
                {
                    Form1.Deactivated = false;
                }
            }
        }
    }
}
