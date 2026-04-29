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
			this.lblTitle = new System.Windows.Forms.Label();
			this.CrdtsBtn = new System.Windows.Forms.Button();
			this.QuitBtn = new System.Windows.Forms.Button();
			this.StrtButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(193)))), ((int)(((byte)(78)))));
			this.lblTitle.Location = new System.Drawing.Point(362, 115);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(439, 139);
			this.lblTitle.TabIndex = 2;
			this.lblTitle.Text = "GDA6\r\n(Discrete Math)";
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
			this.CrdtsBtn.Location = new System.Drawing.Point(471, 504);
			this.CrdtsBtn.Name = "CrdtsBtn";
			this.CrdtsBtn.Size = new System.Drawing.Size(179, 139);
			this.CrdtsBtn.TabIndex = 3;
			this.CrdtsBtn.Text = "CREDITS";
			this.CrdtsBtn.UseVisualStyleBackColor = true;
			this.CrdtsBtn.Click += new System.EventHandler(this.CrdtsBtn_Click);
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
			this.QuitBtn.Location = new System.Drawing.Point(471, 409);
			this.QuitBtn.Name = "QuitBtn";
			this.QuitBtn.Size = new System.Drawing.Size(179, 139);
			this.QuitBtn.TabIndex = 1;
			this.QuitBtn.Text = "QUIT";
			this.QuitBtn.UseVisualStyleBackColor = true;
			this.QuitBtn.Click += new System.EventHandler(this.QuitBtnClick);
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
			this.StrtButton.Location = new System.Drawing.Point(471, 313);
			this.StrtButton.Name = "StrtButton";
			this.StrtButton.Size = new System.Drawing.Size(179, 139);
			this.StrtButton.TabIndex = 0;
			this.StrtButton.Text = "START";
			this.StrtButton.UseVisualStyleBackColor = true;
			this.StrtButton.Click += new System.EventHandler(this.StrtButtonClick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(193)))), ((int)(((byte)(78)))));
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Location = new System.Drawing.Point(1, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1117, 39);
			this.panel1.TabIndex = 4;
			// 
			// button1
			// 
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(1022, 2);
			this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(45, 35);
			this.button1.TabIndex = 5;
			this.button1.Text = "-";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
			this.btnClose.Location = new System.Drawing.Point(1072, 2);
			this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(45, 35);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "X";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
			this.ClientSize = new System.Drawing.Size(1116, 667);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.CrdtsBtn);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.QuitBtn);
			this.Controls.Add(this.StrtButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Discrete Math";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClose;
	}
}
