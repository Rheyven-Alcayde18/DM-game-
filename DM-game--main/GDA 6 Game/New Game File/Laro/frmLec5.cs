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
    public partial class frmLec5 : Form
    {
        public frmLec5()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        	//Exit lec 5
            frmMainHall exitLec5 = new frmMainHall();
            exitLec5.Show();
            this.Close();
        }
    }
}
