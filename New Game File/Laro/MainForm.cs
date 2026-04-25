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
			Form Form1 = new Form1();
			this.Hide();
			Form1.Show();
			
		}
		void QuitBtnClick(object sender, EventArgs e)
		{
            DialogResult quit = MessageBox.Show("Are you sure you want to quit?", "Yes, Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            frmCredits frmCreditsPage = new frmCredits();
            this.Hide();
            frmCreditsPage.Show();
        }
		
	}
}
