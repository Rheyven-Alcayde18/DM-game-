/*
 * Created by SharpDevelop.
 * User: CJ
 * Date: 5/4/2026
 * Time: 4:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laro
{
	/// <summary>
	/// Description of name.
	/// </summary>
	public partial class frmName : Form
	{
		public frmName()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			  this.WindowState = FormWindowState.Minimized; // allows the user to reopen the page from being minimized
		}
		void BtnCloseClick(object sender, EventArgs e)
		{
			DialogResult quit = MessageBox.Show("Are you sure you want to quit?", "Yes, Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (quit == DialogResult.Yes)
            {
                Application.Exit();
            }
		}
		void BtnSubmitClick(object sender, EventArgs e)
		{
			
			Form Selection = new frmSelection();
			Selection.Show();
			this.Hide();
			
		}
		void Label1Click(object sender, EventArgs e)
		{
	
		}
	}
}
