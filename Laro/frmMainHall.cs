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
    public partial class frmMainHall : Form
    {
        public frmMainHall()
        {
            InitializeComponent();
        }
		void Form3Load(object sender, EventArgs e)
		{
	
		}
        private void lblLec4_Click_1(object sender, EventArgs e)
        {
            //Go to Lec 4
            frmLec4 Lec4 = new frmLec4();
            Lec4.Show();
            this.Close();
        }

        private void lblLec5_Click(object sender, EventArgs e)
        {
            //Go to Lec5
            Form Lec5 = new frmLec5();
            Lec5.Show();
            this.Close();
        }

        private void lblLec2_Click_1(object sender, EventArgs e)
        {
            Form Lec2 = new frmLec2();
            Lec2.Show();
            this.Close();
        }

        private void lblLab1_Click_1(object sender, EventArgs e)
        {
            Form Lab1 = new frmLab1();
            Lab1.Show();
            this.Close();
        }

        private void lblCCSFaculty_Click_1(object sender, EventArgs e)
        {
            Form CCSFaculty = new frmCCSFaculty();
            CCSFaculty.Show();
            this.Close();
        }

        private void lblLibrary_Click(object sender, EventArgs e)
        {
            Form Library = new frmLibrary();
            Library.Show();
            this.Close();
        }

        private void lblExit_Click_1(object sender, EventArgs e)
        {
            //Return to Lobby
            Form Lobby = new frmLobby();
            Lobby.Show();
            this.Close();
        }

    }
}
