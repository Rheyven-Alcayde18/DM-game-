using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Laro
{
    public partial class frmCredits : Form
    {
        public frmCredits()
        {
            InitializeComponent();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult quit = MessageBox.Show("Are you sure you want to quit?", "Yes, Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (quit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMinimze_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // allows the user to reopen the page from being minimized
        }

        private void label29_Click(object sender, EventArgs e)
        {
            MainForm frmmain = new MainForm();
            this.Close();
            frmmain.Show(); // why label? hinamit ko na label to be clickable to be much presentable, it acts like a button and allows you to go back to the main form.
            
        }
    }
}
