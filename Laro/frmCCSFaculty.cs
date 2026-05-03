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
    public partial class frmCCSFaculty : Form
    {
        public frmCCSFaculty()
        {
            InitializeComponent();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            //Exit Lec 4
            frmMainHall exitFaculty = new frmMainHall();
            exitFaculty.Show();
            this.Close();
        }
    }
}
