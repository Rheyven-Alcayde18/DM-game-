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
		void Lec4RoomClick(object sender, EventArgs e)
		{
			//Go to Lec 4
			frmLec4 Lec4 = new frmLec4();
			Lec4.Show();
			this.Close();
		}
		void Lec5RoomClick(object sender, EventArgs e)
		{
			//Go to Lec5
			Form Lec5 = new frmLec5();
			Lec5.Show();
			this.Close();
		}
		void Form3Load(object sender, EventArgs e)
		{
	
		}

        private void btnLobby_Click(object sender, EventArgs e)
        {
        	//Return to Lobby
            Form Lobby = new frmLobby();
            Lobby.Show();
            this.Close();
        }
    }
}
