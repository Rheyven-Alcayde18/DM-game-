using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading.Tasks;

namespace Laro
{
    public partial class frmMainHall : Form
    {
        public frmMainHall()
        {
            InitializeComponent();
        }
        private async void lblLec4_Click_1(object sender, EventArgs e)
        {
        	
            //Go to Lec 4
            SoundManager.PlayDoorSound();
            await Task.Delay(500);
            frmLec4 Lec4 = new frmLec4();
            Lec4.Show();
            this.Close();
        }

        private async void lblLec5_Click(object sender, EventArgs e)
        {
        	if (GameState.IsLocked("Lec5"))
		    {
		        MessageBox.Show("This room is locked!", "Locked", 
		                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
		        return;
		    }
            //Go to Lec5
            SoundManager.PlayDoorSound();
            await Task.Delay(500);
            Form Lec5 = new frmLec5();
            Lec5.Show();
            this.Close();
        }

        private async void lblLec2_Click_1(object sender, EventArgs e)
        {
        	if (GameState.IsLocked("Lec2"))
		    {
		        MessageBox.Show("This room is locked!", "Locked", 
		                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
		        return;
		    }
        	
        	SoundManager.PlayDoorSound();
            await Task.Delay(500);
            Form Lec2 = new frmLec2();
            Lec2.Show();
            this.Close();
        }

        private async void lblLab1_Click_1(object sender, EventArgs e)
        {
        	if (GameState.IsLocked("Lab1"))
		    {
		        MessageBox.Show("This room is locked!", "Locked", 
		                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
		        return;
		    }
        	SoundManager.PlayDoorSound();
        	await Task.Delay(500);
            Form Lab1 = new frmLab1();
            Lab1.Show();
            this.Close();
        }

        private async void lblCCSFaculty_Click_1(object sender, EventArgs e)
        {
        	if (GameState.IsLocked("CCSFaculty"))
		    {
		        MessageBox.Show("This room is locked!", "Locked", 
		                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
		        return;
		    }
        	SoundManager.PlayDoorSound();
        	await Task.Delay(500);
            Form CCSFaculty = new frmCCSFaculty();
            CCSFaculty.Show();
            this.Close();
        }

        private async void lblLibrary_Click(object sender, EventArgs e)
        {
        	SoundManager.PlayDoorSound();
        	await Task.Delay(500);
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
