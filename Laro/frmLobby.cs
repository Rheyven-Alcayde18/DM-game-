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
    public partial class frmLobby : Form
    {
    	
    	string[] script = { " The school library was unsually quiet. ", "Only the sound of the electric fan and turning pages filled the room  ", "It was already past 11 PM Most students had gone home hours ago " +
    		"But one student remained. " , "Books were scattered across the table. ", "His notebook was filled with scratched-out answers and question marks.", "His eyes grew heavier ", "The letters on the page began to blur.  ","And without realizing it…….Llamoso fell asleep."};//cutscene script
		int sceneIndex = 0;//cutscene index
		int charIndex = 0;//cutscene char index
		Timer timer = new Timer();
		string[] mcdialogue = { " *yawn* Aughhh …Why does Discrete Mathematics even exist?", "Propositions… truth tables… logical connectives…   ", "I swear these things are plotting against me " +
    		"Tomorrow is the final exam…  ", "…and I still feel like I understand absolutely nothing. ", "If I fail this subject, I’m finished. ", "Okay… one last review. "," If P then Q… ","…why does this sound like a threat?", "Maybe just five more minutes…  "};//cutscene script
		int mcIndex = 0;//cutscene index
		int mccharIndex = 0;//cutscene char index
		Timer mctimer = new Timer();
		
		
        public frmLobby()	
        {
            InitializeComponent();
            timer.Interval = 100; // Speed of text
		    timer.Tick += Timer_Tick;
		    timer.Start();
		    DialogueBox.Visible = false;
		    CharacterName.Visible = false;
		    CharacterPic.Visible = false;
        }
		public void Timer_Tick(object sender, EventArgs e)
		{
		    if (sceneIndex < script.Length)
		    {
		        if (charIndex < script[sceneIndex].Length)
		        {
		            Cutscene.AppendText(script[sceneIndex][charIndex].ToString());
		            charIndex++;
		        }
		        else
		        {
		            timer.Stop(); // Pause at end of line
		        }
		    }
		}

        private void frmLobby_Load(object sender, EventArgs e)
        {
		
        }

        private void btnLobby_Click(object sender, EventArgs e)
        {
        	//Go to Class Hall
            Form Form3 = new frmMainHall();
            Form3.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // allows the user to reopen the page from being minimized
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult quit = MessageBox.Show("Are you sure you want to quit?", "Yes, Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (quit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
		void FrmLobbyClick(object sender, EventArgs e)
		{
			if (timer.Enabled)
			{
				timer.Stop();
				Cutscene.Clear();
				Cutscene.Text = script[sceneIndex];
				charIndex = script[sceneIndex].Length;
			}
			else
			{
				if (sceneIndex < script.Length - 1)
			    {
			        sceneIndex++;
			        charIndex = 0;
			        Cutscene.Clear();
			        timer.Start();
			    }
				else
				{
					Cutscene.Hide();
					DialogueBox.Visible = true;
				    CharacterName.Visible = true;
				    CharacterPic.Visible = true;
				}
			}
			// Advance on click
		}
		void CharacterNameClick(object sender, EventArgs e)
		{
	        
		}
		
    }
}
