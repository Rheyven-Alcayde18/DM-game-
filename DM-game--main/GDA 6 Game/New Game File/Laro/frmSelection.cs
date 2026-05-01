/*
 * Created by SharpDevelop.
 * User: CJ
 * Date: 4/24/2026
 * Time: 6:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laro
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class GameSelection : Form
	{
		public GameSelection()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BckBtnClick(object sender, EventArgs e)
		{
			//Back to Main Menu
			Form MainForm = new MainForm();
			MainForm.Show();
			this.Close();
		}
		void NewGameClick(object sender, EventArgs e)
		{
			//Game Start Form Generate
			Form Form2 = new frmLobby();
			Form2.Show();
			this.Close();
		}
		void ContinueClick(object sender, EventArgs e)
		{
	
		}

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult quit = MessageBox.Show("Are you sure you want to quit?", "Yes, Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (quit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
	}
}
