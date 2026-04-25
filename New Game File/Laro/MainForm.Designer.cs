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
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button StrtButton;
		private System.Windows.Forms.Button QuitBtn;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Button CrdtsBtn;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.StrtButton = new System.Windows.Forms.Button();
			this.QuitBtn = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
			this.CrdtsBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// StrtButton
			// 
			this.StrtButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.StrtButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StrtButton.BackgroundImage")));
			this.StrtButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.StrtButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.StrtButton.FlatAppearance.BorderSize = 0;
			this.StrtButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.StrtButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StrtButton.ForeColor = System.Drawing.Color.White;
			this.StrtButton.Location = new System.Drawing.Point(52, 276);
			this.StrtButton.Name = "StrtButton";
			this.StrtButton.Size = new System.Drawing.Size(152, 41);
			this.StrtButton.TabIndex = 0;
			this.StrtButton.Text = "START";
			this.StrtButton.UseVisualStyleBackColor = true;
			this.StrtButton.Click += new System.EventHandler(this.StrtButtonClick);
			// 
			// QuitBtn
			// 
			this.QuitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.QuitBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("QuitBtn.BackgroundImage")));
			this.QuitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.QuitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.QuitBtn.FlatAppearance.BorderSize = 0;
			this.QuitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.QuitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.QuitBtn.ForeColor = System.Drawing.Color.White;
			this.QuitBtn.Location = new System.Drawing.Point(52, 372);
			this.QuitBtn.Name = "QuitBtn";
			this.QuitBtn.Size = new System.Drawing.Size(152, 48);
			this.QuitBtn.TabIndex = 1;
			this.QuitBtn.Text = "QUIT";
			this.QuitBtn.UseVisualStyleBackColor = true;
			this.QuitBtn.Click += new System.EventHandler(this.QuitBtnClick);
			// 
			// lblTitle
			// 
			this.lblTitle.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(193)))), ((int)(((byte)(78)))));
			this.lblTitle.Location = new System.Drawing.Point(320, 82);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(439, 139);
			this.lblTitle.TabIndex = 2;
			this.lblTitle.Text = "Game Title\r\n(Discrete Math)";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// CrdtsBtn
			// 
			this.CrdtsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.CrdtsBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CrdtsBtn.BackgroundImage")));
			this.CrdtsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.CrdtsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CrdtsBtn.FlatAppearance.BorderSize = 0;
			this.CrdtsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CrdtsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CrdtsBtn.ForeColor = System.Drawing.Color.White;
			this.CrdtsBtn.Location = new System.Drawing.Point(52, 467);
			this.CrdtsBtn.Name = "CrdtsBtn";
			this.CrdtsBtn.Size = new System.Drawing.Size(152, 51);
			this.CrdtsBtn.TabIndex = 3;
			this.CrdtsBtn.Text = "CREDITS";
			this.CrdtsBtn.UseVisualStyleBackColor = true;
			this.CrdtsBtn.Click += new System.EventHandler(this.CrdtsBtn_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(193)))), ((int)(((byte)(78)))));
			this.label1.Location = new System.Drawing.Point(210, 238);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(313, 112);
			this.label1.TabIndex = 2;
			this.label1.Text = "Start";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(193)))), ((int)(((byte)(78)))));
			this.label2.Location = new System.Drawing.Point(210, 442);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(353, 112);
			this.label2.TabIndex = 2;
			this.label2.Text = "Credits";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(193)))), ((int)(((byte)(78)))));
			this.label3.Location = new System.Drawing.Point(210, 341);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(313, 112);
			this.label3.TabIndex = 2;
			this.label3.Text = "Quit";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
			this.ClientSize = new System.Drawing.Size(1116, 667);
			this.Controls.Add(this.CrdtsBtn);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.QuitBtn);
			this.Controls.Add(this.StrtButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "MainForm";
			this.Text = "Discrete Math";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);

		}

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
	}
}
