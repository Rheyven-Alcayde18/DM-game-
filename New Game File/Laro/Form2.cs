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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
		void ClassHallClick(object sender, EventArgs e)
		{
			Form Form3 = new Form3();
			Form3.Show();
			this.Close();
		}
		
    }
}
