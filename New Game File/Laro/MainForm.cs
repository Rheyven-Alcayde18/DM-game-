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
			Form Form1 = new GameSelection();
			this.Hide();
			Form1.Show();
			
		}
		void QuitBtnClick(object sender, EventArgs e)
		{
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
            frmCredits frmCreditsPage = new frmCredits();
            this.Hide();
            frmCreditsPage.Show();
        }
		
	}
}
