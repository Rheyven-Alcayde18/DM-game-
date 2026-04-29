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
	partial class GameSelection
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button BckBtn;
		private System.Windows.Forms.Button NewGame;
		private System.Windows.Forms.Button Continue;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSelection));
			this.Continue = new System.Windows.Forms.Button();
			this.NewGame = new System.Windows.Forms.Button();
			this.BckBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Continue
			// 
			this.Continue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Continue.BackgroundImage")));
			this.Continue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.Continue.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Continue.FlatAppearance.BorderSize = 0;
			this.Continue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Continue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Continue.ForeColor = System.Drawing.Color.White;
			this.Continue.Location = new System.Drawing.Point(330, 309);
			this.Continue.Name = "Continue";
			this.Continue.Size = new System.Drawing.Size(284, 90);
			this.Continue.TabIndex = 2;
			this.Continue.Text = "Continue";
			this.Continue.UseVisualStyleBackColor = true;
			this.Continue.Click += new System.EventHandler(this.ContinueClick);
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
			this.NewGame.Location = new System.Drawing.Point(330, 193);
			this.NewGame.Name = "NewGame";
			this.NewGame.Size = new System.Drawing.Size(284, 89);
			this.NewGame.TabIndex = 1;
			this.NewGame.Text = "New Game";
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
			this.BckBtn.Location = new System.Drawing.Point(13, 13);
			this.BckBtn.Name = "BckBtn";
			this.BckBtn.Size = new System.Drawing.Size(130, 44);
			this.BckBtn.TabIndex = 0;
			this.BckBtn.Text = "BACK";
			this.BckBtn.UseVisualStyleBackColor = true;
			this.BckBtn.Click += new System.EventHandler(this.BckBtnClick);
			// 
			// GameSelection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
			this.ClientSize = new System.Drawing.Size(946, 547);
			this.Controls.Add(this.Continue);
			this.Controls.Add(this.NewGame);
			this.Controls.Add(this.BckBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "GameSelection";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Selection";
			this.ResumeLayout(false);

		}
	}
}
