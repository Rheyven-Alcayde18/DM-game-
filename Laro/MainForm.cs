using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Laro
{
	public partial class MainForm : Form
	{
		public MainForm()
		{

			InitializeComponent();

		}
		void StrtButtonClick(object sender, EventArgs e)
		{
			//Start Button creates a new form for creating a new game or continuing the old one
			SoundManager.ButtonSound();
			Form name = new frmName();
			name.Show();
			this.Hide();
			
		}
		void QuitBtnClick(object sender, EventArgs e)
		{
			SoundManager.ButtonSound();
			//Quit Button shows dialog box that confirms whether the player wants to quit or not
            DialogResult quit = MessageBox.Show("Are you sure you want to quit?", "Yes, Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //Selecting yes closes the application
			if(quit == DialogResult.Yes)
			{
				Application.Exit();
			}
			
		}
		void MainFormLoad(object sender, EventArgs e)
		{
		}

        private void CrdtsBtn_Click(object sender, EventArgs e)
        {
        	//Button for credit section
        	SoundManager.ButtonSound();
            frmCredits frmCreditsPage = new frmCredits();
            this.Hide();
            frmCreditsPage.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult quit = MessageBox.Show("Are you sure you want to quit?", "Yes, Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (quit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if (MusicPlayer.Checked)
			{
				MusicPlayer.ImageIndex = 0;
				AudioManager.isMuted = true;
			}
			else if (!MusicPlayer.Checked)
			{
				MusicPlayer.ImageIndex = 1;
				AudioManager.isMuted = false;
			}
		}
		
	}
}
