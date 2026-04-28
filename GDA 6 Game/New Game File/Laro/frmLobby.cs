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
            Form Form3 = new frmMainHall();
            Form3.Show();
            this.Close();
        }
		
    }
}
