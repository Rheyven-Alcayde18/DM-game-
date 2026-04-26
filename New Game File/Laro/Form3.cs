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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
		void Lec4RoomClick(object sender, EventArgs e)
		{
			Form Form4 = new Form4();
			Form4.Show();
			this.Close();
		}
		void Lec5RoomClick(object sender, EventArgs e)
		{
			Form Form5 = new Form5();
			Form5.Show();
			this.Close();
		}
		void Form3Load(object sender, EventArgs e)
		{
	
		}
    }
}
