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

namespace NetShare
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            LostFocus += Form_LostFocus;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        /*private void Form1_Deactivate(object sender, EventArgs e)
        {
            // Hide();
            MessageBox.Show("outside");
        }*/

        private void Form_LostFocus(object sender, EventArgs e)
        {
            Hide();
        }

    }
}
