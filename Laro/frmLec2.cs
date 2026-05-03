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
    public partial class frmLec2 : Form
    {
        public frmLec2()
        {
            InitializeComponent();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            //Exit lec 2
            frmMainHall exitLec2 = new frmMainHall();
            exitLec2.Show();
            this.Close();
        }
    }
}
