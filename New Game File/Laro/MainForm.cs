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
			StrtButton.BackColor = Color.GreenYellow;
			QuitBtn.BackColor = Color.Red;
		}
		void StrtButtonMouseHover(object sender, EventArgs e)
		{
			StrtButton.Font = new Font(StrtButton.Font.FontFamily, 20f);
		}
		void StrtButtonMouseLeave(object sender, EventArgs e)
		{
			StrtButton.Font = new Font(StrtButton.Font.FontFamily, 8.25f);
		}
		void QuitBtnMouseHover(object sender, EventArgs e)
		{
			QuitBtn.Font = new Font(QuitBtn.Font.FontFamily, 20f);
		}
		void QuitBtnMouseLeave(object sender, EventArgs e)
		{
			QuitBtn.Font = new Font(QuitBtn.Font.FontFamily, 8.25f);
		}

        private void CrdtsBtn_Click(object sender, EventArgs e)
        {
            frmCredits frmCreditsPage = new frmCredits();
            this.Hide();
            frmCreditsPage.Show();
        }
		
	}
}
