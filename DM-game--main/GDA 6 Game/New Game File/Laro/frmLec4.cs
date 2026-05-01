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
    public partial class frmLec4 : Form
    {
        public frmLec4()
        {
            InitializeComponent();
        }
		void Form4Load(object sender, EventArgs e)
		{
	
		}

 

        private void label2_Click(object sender, EventArgs e)
        {
        	//Exit Lec 4
            frmMainHall exitLec4 = new frmMainHall();
            exitLec4.Show();
            this.Close();
        }
    }
}
