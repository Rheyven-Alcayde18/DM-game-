/*
 * Created by SharpDevelop.
 * User: CJ
 * Date: 4/24/2026
 * Time: 6:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Laro
{
	partial class frmSelection
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button BckBtn;
		private System.Windows.Forms.Button NewGame;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelection));
			this.NewGame = new System.Windows.Forms.Button();
			this.BckBtn = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// NewGame
			// 
			this.NewGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NewGame.BackgroundImage")));
			this.NewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.NewGame.Cursor = System.Windows.Forms.Cursors.Hand;
			this.NewGame.FlatAppearance.BorderSize = 0;
			this.NewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.NewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NewGame.ForeColor = System.Drawing.Color.White;
			this.NewGame.Location = new System.Drawing.Point(964, 566);
			this.NewGame.Name = "NewGame";
			this.NewGame.Size = new System.Drawing.Size(99, 46);
			this.NewGame.TabIndex = 1;
			this.NewGame.Text = "NewGame";
			this.toolTip1.SetToolTip(this.NewGame, "Start a new game!");
			this.NewGame.UseVisualStyleBackColor = true;
			this.NewGame.Click += new System.EventHandler(this.NewGameClick);
			// 
			// BckBtn
			// 
			this.BckBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BckBtn.BackgroundImage")));
			this.BckBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.BckBtn.FlatAppearance.BorderSize = 0;
			this.BckBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BckBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BckBtn.ForeColor = System.Drawing.Color.White;
			this.BckBtn.Location = new System.Drawing.Point(10, 566);
			this.BckBtn.Name = "BckBtn";
			this.BckBtn.Size = new System.Drawing.Size(130, 44);
			this.BckBtn.TabIndex = 0;
			this.BckBtn.Text = "BACK";
			this.toolTip1.SetToolTip(this.BckBtn, "Return to the main menu.");
			this.BckBtn.UseVisualStyleBackColor = true;
			this.BckBtn.Click += new System.EventHandler(this.BckBtnClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox1.Location = new System.Drawing.Point(332, 44);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(392, 579);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(382, 132);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(307, 460);
			this.textBox1.TabIndex = 7;
			this.textBox1.Text = resources.GetString("textBox1.Text");
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// frmSelection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
			this.ClientSize = new System.Drawing.Size(1116, 667);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.NewGame);
			this.Controls.Add(this.BckBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmSelection";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Selection";
			this.Load += new System.EventHandler(this.FrmSelectionLoad);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolTip toolTip1;
	}
}
