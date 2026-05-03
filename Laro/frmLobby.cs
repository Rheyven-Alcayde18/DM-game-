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
    public partial class frmLobby : Form
    {
        public frmLobby()
        {
            InitializeComponent();
        }
		

        private void frmLobby_Load(object sender, EventArgs e)
        {

        }

        private void btnLobby_Click(object sender, EventArgs e)
        {
        	//Go to Class Hall
            Form Form3 = new frmMainHall();
            Form3.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // allows the user to reopen the page from being minimized
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult quit = MessageBox.Show("Are you sure you want to quit?", "Yes, Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (quit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
		
    }
}
