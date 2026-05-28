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
			// Check if name is empty
		    if (string.IsNullOrWhiteSpace(txtName.Text)||txtName.Text == "Enter character name here...")
		    {
		        MessageBox.Show("Please enter your character name.", "Missing Name", 
		                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
		        return;
		    }
		    // Check if no gender is selected
		    if (string.IsNullOrEmpty(Gender.value))
		    {
		        MessageBox.Show("Please select a gender.", "Missing Gender", 
		                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
		        return;
		    }
		
		    // All fields filled — proceed
		    SoundManager.ButtonSound();
		    MessageBox.Show("Username: " + User.name, "Username");
		    Form Selection = new frmSelection();
		    Selection.Show();
		    this.Hide();
		}
		void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			Gender.value = "Male";
		}
		void FemaleCheckedChanged(object sender, EventArgs e)
		{
			Gender.value = "Female";
		}
		void TxtNameTextChanged(object sender, EventArgs e)
		{
			User.name = txtName.Text;
		}
		void FrmNameLoad(object sender, EventArgs e)
		{
			if(txtName.Text=="")
			{
				txtName.Text = "Enter character name here...";
			}
		}
		void TxtNameEnter(object sender, EventArgs e)
		{
			if(txtName.Text == "Enter character name here...")
				txtName.Text = "";
		}
		void TxtNameLeave(object sender, EventArgs e)
		{
			if(txtName.Text=="")
				txtName.Text = "Enter character name here...";
		}
		
	}
}
